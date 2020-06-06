using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroceryPR.Models
{
    //[MetadataType(typeof(UserModel))]
    //public partial class UserTbl
    //{

    //}

    public class UserModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string MobileNumber { get; set; }

        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string WhatsAppNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 8 and 255 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 8 and 255 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please Enter valid CountryId")]
        public int CountryId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please Enter valid StateId")]
        public int StateId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please Enter valid CityId")]
        public long CityId { get; set; }
        public string Landmark { get; set; }
        public string SocityName { get; set; }
        public string WingName { get; set; }
        public string FlatNumber { get; set; }
        public Nullable<System.Guid> Token { get; set; }
        public System.DateTime DateAdded { get; set; }
        public System.DateTime DateModified { get; set; }

    }
}