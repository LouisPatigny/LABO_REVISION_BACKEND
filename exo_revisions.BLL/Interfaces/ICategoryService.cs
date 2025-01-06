using exo_revisions.BLL.Models;

namespace exo_revisions.BLL.Interfaces;

public interface ICategoryService
{
    public IEnumerable<Category> GetAll();
    public Category? GetById(int id);
    public int Create(Category category);
    public bool Update(Category category);
    public bool Delete(int id);
}