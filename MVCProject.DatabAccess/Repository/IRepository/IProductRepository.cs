using MVCProject.Models;

namespace MVCProject.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
        void Save();
    }
}
