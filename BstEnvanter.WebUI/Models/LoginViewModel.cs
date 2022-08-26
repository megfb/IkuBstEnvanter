using System.ComponentModel.DataAnnotations;

namespace BstEnvanter.WebUI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-Mail cannot be empty")]
        [DataType(DataType.EmailAddress)]
        public string EMail { get; set; }
        [Required(ErrorMessage = "E-Mail cannot be empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}