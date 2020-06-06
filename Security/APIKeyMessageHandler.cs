using GroceryPR.EncryptionAndDecryption;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace GroceryPR.Security
{
    public class APIKeyMessageHandler : DelegatingHandler
    {
        [Obsolete]
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            bool validKey = false;
            string apiKey = EncryptDecryptPassword.EncryptPlainTextToCipherText(Convert.ToString(ConfigurationSettings.AppSettings["ApiKey"]));
            IEnumerable<string> requestHeaders;
            var checkApiKeyExists = request.Headers.TryGetValues("ApiKey", out requestHeaders);
            if (checkApiKeyExists)
            {
                if (requestHeaders.FirstOrDefault().Equals(apiKey))
                {
                    validKey = true;
                }
            }
            if (!validKey)
            {
                return new HttpResponseMessage(HttpStatusCode.Forbidden)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(new { message = "Invalid API Key" })),
                    ReasonPhrase = "Invalid API Key"
                };
            }
            var response = await base.SendAsync(request, cancellationToken);
            return response;
        }

    }
}