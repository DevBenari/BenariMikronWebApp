using BenariMikronWebApp.Areas.UserManagement.Repositories;
using BenariMikronWebApp.Core.Repositories;

namespace BenariMikronWebApp.Areas.UserManagement.Data
{
    public interface IUnitOfWork
    {
        IUserManagementRepository User { get; }
        IRoleRepository Role { get; }
    }
}
