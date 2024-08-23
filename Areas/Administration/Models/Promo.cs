using BenariMikronWebApp.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BenariMikronWebApp.Areas.Administration.Models
{
    [Table("AdmPromo", Schema = "dbo")]
    public class Promo : UserActivity
    {
        [Key]
        public Guid PromoId { get; set; }
        public string KodePromo { get; set; }
        public string NamaPromo { get; set; }
        public string? Keterangan { get; set; }
    }
}
