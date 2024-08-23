using BenariMikronWebApp.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BenariMikronWebApp.Areas.HealthManagement.Models
{
    [Table("HmnDoctorTitle", Schema = "dbo")]
    public class DoctorTitle : UserActivity //UserActivity Create on Repository
    {
        [Key]
        public Guid DoctorTitleId { get; set; }
        public string KodeGelar { get; set; }
        public string NamaGelar { get; set; }
        public string? Deskripsi { get; set; }
        public string LapRL1 { get; set; }
        public string LapRL2 { get; set; }
        public string Status { get; set; }
    }
}
