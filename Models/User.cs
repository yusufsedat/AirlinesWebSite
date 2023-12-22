using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace WebProgramlama_Odev.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "Ad")]
        [Required(ErrorMessage ="Gerekli")]
        public string firstname { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Gerekli")]
        public string lastname { get; set; }

        
        [Display(Name = "Mail Adresi")]
        [Required]
        [EmailAddress(ErrorMessage = "Lütfen Geçerli Bir Mail Adresi Giriniz !")]
        public string email { get; set; }
        [Display(Name = "Telefon Numarası")]
        public long phone { get; set; }

        [Display(Name = "Şifreniz")]
        [Required(ErrorMessage = "Gerekli")]
        public string password { get; set; }

        [Display(Name = "Mesajınız")]
        [Required(ErrorMessage = "Gerekli")]
        public string message { get; set; }

      

        public IEnumerable<UserUcus> UserUcuss { get; set; }


        

    }

    public class UserUcus
    {
        [Key]
        public int UserUcusId { get; set; }

        public int PnrNo { get; set; }

        [ForeignKey("PnrNo")]
        public UcusModel Ucus { get; set; }
        

        public int UserId {get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
