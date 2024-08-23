using BenariMikronWebApp.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BenariMikronWebApp.Areas.HealthManagement.Models
{
    [Table("HmnBloodType", Schema = "dbo")]
    public class BloodType : UserActivity
    {
        [Key]
        public Guid BloodTypeId { get; set; }
        public string KodeGolonganDarah { get; set; }
        public string NamaGolonganDarah { get; set; }
        public string? Keterangan { get; set; }

    }
}
