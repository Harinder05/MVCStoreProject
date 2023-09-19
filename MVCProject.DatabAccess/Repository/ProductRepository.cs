using MVCProject.DataAccess.Data;
using MVCProject.DataAccess.Repository.IRepository;
using MVCProject.Models;

namespace MVCProject.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save() 
        {
            _db.SaveChanges();
        }

        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }
    }
}
