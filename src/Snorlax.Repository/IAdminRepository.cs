using System.Threading.Tasks;

namespace Snorlax.Repository
{
    public interface IAdminRepository
        :IRepository<Model.Admin>
    {
        Task<Model.Admin> LoginAsync(string email,string password);
    }
}