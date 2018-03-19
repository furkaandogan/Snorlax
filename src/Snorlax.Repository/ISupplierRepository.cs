using System.Threading.Tasks;

namespace Snorlax.Repository
{
    public interface ISupplierRepository
        :IRepository<Model.Supplier>
    {
        Task<bool> ExistsByIdAsync(string id);
    }
}