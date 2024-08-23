using BenariMikronWebApp.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BenariMikronWebApp.Areas.HealthManagement.Models
{
    [Table("HmnDoctorType", Schema = "dbo")]
    public class DoctorType : UserActivity //UserActivity Create on Repository
    {
        [Key]
        public Guid DoctorTypeId { get; set; }
        public string KodeTipeDokter { get; set; }
        public string TipeDokter { get; set; }
        public string? Persentase { get; set; }
        public string Status { get; set; }
    }
}
