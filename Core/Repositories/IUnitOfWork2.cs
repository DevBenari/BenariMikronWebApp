namespace BenariMikronWebApp.Core.Repositories
{
    public interface IUnitOfWork2
    {
        IUserRepository User { get; }
        IRoleRepository Role { get; }
    }
}
