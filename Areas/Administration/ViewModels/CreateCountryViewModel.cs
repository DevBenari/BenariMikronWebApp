using BenariMikronWebApp.Areas.Administration.Models;

namespace BenariMikronWebApp.Areas.Administration.ViewModels
{
    public class CreateCountryViewModel
    {
        public Guid CountryId { get; set; }
        public string KodeNegara { get; set; }
        public string NamaNegara { get; set; }        
    }
}
