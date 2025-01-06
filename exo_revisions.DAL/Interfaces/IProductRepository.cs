using exo_revisions.DAL.Entities;

namespace exo_revisions.DAL.Interfaces;

public interface IProductRepository
{
    public IEnumerable<Product> GetAll();
    public IEnumerable<Product> GetAllActive();
    public Product? GetById(int id);
    public int Create(Product product);
    public bool Update(Product product);
    public bool Delete(int id);
}