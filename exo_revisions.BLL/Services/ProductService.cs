using exo_revisions.BLL.Interfaces;
using exo_revisions.BLL.Mappers;
using exo_revisions.BLL.Models;
using exo_revisions.DAL.Interfaces;

namespace exo_revisions.BLL.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IEnumerable<Product> GetAll()
    {
        return _productRepository.GetAll().Select(p => p.ToModel());
    }

    public IEnumerable<Product> GetAllActive()
    {
        return _productRepository.GetAllActive().Select(p => p.ToModel());
    }

    public Product? GetById(int id)
    {
        return _productRepository.GetById(id)?.ToModel();
    }

    public int Create(Product product)
    {
        return _productRepository.Create(product.ToEntity());
    }

    public bool Update(Product product)
    {
        return _productRepository.Update(product.ToEntity());
    }

    public bool Delete(int id)
    {
        return _productRepository.Delete(id);
    }
}