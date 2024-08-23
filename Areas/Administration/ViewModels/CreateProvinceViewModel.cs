using BenariMikronWebApp.Areas.Administration.Models;

namespace BenariMikronWebApp.Areas.Administration.ViewModels
{
    public class CreateProvinceViewModel
    {
        public Guid ProvinceId { get; set; }
        public string KodeProvinsi { get; set; }
        public string NamaProvinsi { get; set; }
        public Guid? CountryId { get; set; }
    }
}
