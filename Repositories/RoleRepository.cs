using BenariMikronWebApp.Areas.Identity.Data;
using BenariMikronWebApp.Core.Repositories;
using Microsoft.AspNetCore.Identity;

namespace BenariMikronWebApp.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;
        public RoleRepository(ApplicationDbContext context) 
        { 
            _context = context;
        }

        public ICollection<IdentityRole> GetRoles() 
        { 
            return _context.Roles.ToList();
        }
    }
}
