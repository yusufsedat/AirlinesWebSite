using System.ComponentModel.DataAnnotations;

namespace WebProgramlama_Odev.Models
{
    public class GuzergahModel
    {
        [Key]
        public int UcusId { get; set; }

        [Display(Name = "Nereden?")]
        [Required(ErrorMessage = "Gerekli")]
        public string Nereden { get; set; }

        [Display(Name = "Nereye?")]
        [Required(ErrorMessage = "Gerekli")]
        public string Nereye { get; set; }

        [Required(ErrorMessage = "Gerekli")]
        [Display(Name = "Tarih")]
        public DateTime Tarih { get; set; }

        public IEnumerable<UcusModel>? Ucuss { get; set; }
    }

}
