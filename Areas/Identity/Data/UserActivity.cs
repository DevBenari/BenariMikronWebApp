using System.ComponentModel.DataAnnotations;

namespace BenariMikronWebApp.Areas.Identity.Data
{
    public class UserActivity
    {
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTimeOffset CreateDateTime { get; set; }
        public Guid CreateBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTimeOffset UpdateDateTime { get; set; }
        public Guid UpdateBy { get; set; }
        public bool IsDelete { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTimeOffset DeleteDateTime { get; set; }
        public Guid DeleteBy { get; set; }
    }
}
