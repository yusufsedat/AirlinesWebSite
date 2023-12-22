using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProgramlama_Odev.Models
{
    public class UcusModel
    {
        [Key]
        [Display(Name ="PNR Numarası")]
        public int PnrNo { get; set; }

        public ICollection<UserUcus> UserUcuss { get; set; }

        [ForeignKey("Guzergah")]
        public int UcusId { get; set; }

        public GuzergahModel Guzergah { get; set; } 
    }

   
}
