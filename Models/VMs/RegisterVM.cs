using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _80_MVC_IdentityCustomize.Models.VMs
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        [DisplayName("Adınız")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad alanı zorunludur.")]
        [DisplayName("Soyadınız")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email alanı zorunludur.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Şifre")]
        [Required(ErrorMessage = "Şifre alanız zorunludur.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler tutarsız")]
        [DataType(dataType: DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
