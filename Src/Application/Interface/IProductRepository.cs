using Application.Interface.Common;
using Domain.Entities.Products;



namespace Application.Interface
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}
