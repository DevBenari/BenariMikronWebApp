using BenariMikronWebApp.Areas.Identity.Data;

namespace BenariMikronWebApp.Areas.UserManagement.Repositories
{
    public interface IUserManagementRepository
    {
        ICollection<ApplicationUser> GetUsers();

        ApplicationUser GetUser(string id);
        ApplicationUser UpdateUser(ApplicationUser user);
    }
}
