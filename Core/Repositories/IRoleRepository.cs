using BenariMikronWebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace BenariMikronWebApp.Core.Repositories
{
    public interface IRoleRepository
    {
        ICollection<IdentityRole> GetRoles();
    }
}
