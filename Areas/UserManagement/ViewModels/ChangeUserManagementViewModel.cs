using BenariMikronWebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BenariMikronWebApp.Areas.UserManagement.ViewModels
{
    public class ChangeUserManagementViewModel
    {
        public ApplicationUser User { get; set; }
        public IList<SelectListItem> Roles { get; set; }
    }
}
