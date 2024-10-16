using NotificationService.data.Models;

namespace NotificationService.data.respositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(TmpContext tmpContext) : base(tmpContext)
        {
        }
    }
}
