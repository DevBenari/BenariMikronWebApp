using BenariMikronWebApp.Areas.Administration.Models;

namespace BenariMikronWebApp.Areas.Administration.ViewModels
{
    public class CreateDistrictViewModel
    {
        public Guid DistrictId { get; set; }
        public string KodeKecamatan { get; set; }
        public string NamaKecamatan { get; set; }
        public Guid? CountryId { get; set; }
        public Guid? ProvinceId { get; set; }
        public Guid? CityId { get; set; }
    }
}
