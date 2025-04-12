using System.ComponentModel.DataAnnotations;

namespace Eduaction.On.Web.ViewModel
{

    public class VMLogin
    {
        [Required(ErrorMessage = "Login id can not be blank")]
       // [StringLength(12, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 5)]
        public string LoginId { get; set; }
        [Required(ErrorMessage = "Password can not be blank")]
      //  [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        public string Password { get; set; }
        public bool KeepLoggedIn { get; set; }
    }

}
