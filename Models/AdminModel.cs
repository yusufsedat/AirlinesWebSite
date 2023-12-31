using System.ComponentModel.DataAnnotations;

namespace WebProgramlama_Odev.Models
{
    public class AdminModel
    {
        [Key]
        public int IdAdmin { get; set; }
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Display(Name = "Mail")]
        [Required]
        [EmailAddress(ErrorMessage ="Lütfen Geçerli Bir Mail Adresi Giriniz !")]
        public string email { get; set; }
        [Display(Name = "Şifreniz")]
        [Required]
        public string Password { get; set ; }
    }
}
