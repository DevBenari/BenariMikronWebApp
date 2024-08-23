using BenariMikronWebApp.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BenariMikronWebApp.Areas.Administration.Models
{
    [Table("AdmWorking", Schema = "dbo")]
    public class Working : UserActivity
    {
        [Key]
        public Guid WorkingId { get; set; }
        public string KodePekerjaan { get; set; }
        public string NamaPekerjaan { get; set; }
    }
}
