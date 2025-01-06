using exo_revisions.BLL.Models;

namespace exo_revisions.BLL.Interfaces;

public interface IProductService
{
    public IEnumerable<Product> GetAll();
    public IEnumerable<Product> GetAllActive();
    public Product? GetById(int id);
    public int Create(Product product);
    public bool Update(Product product);
    public bool Delete(int id);
}