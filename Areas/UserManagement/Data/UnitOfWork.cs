using BenariMikronWebApp.Areas.UserManagement.Repositories;
using BenariMikronWebApp.Core.Repositories;

namespace BenariMikronWebApp.Areas.UserManagement.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserManagementRepository User { get; }
        public IRoleRepository Role { get; }

        public UnitOfWork(IUserManagementRepository user, IRoleRepository role)
        {
            User = user;
            Role = role;
        }
    }
}
