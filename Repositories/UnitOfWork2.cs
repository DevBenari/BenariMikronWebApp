using BenariMikronWebApp.Core.Repositories;

namespace BenariMikronWebApp.Repositories
{
    public class UnitOfWork2 : IUnitOfWork2
    {
        public IUserRepository User { get; }
        public IRoleRepository Role { get; }

        public UnitOfWork2(IUserRepository user, IRoleRepository role)
        {
            User = user;
            Role = role;
        }
    }
}
