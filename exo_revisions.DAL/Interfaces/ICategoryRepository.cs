using exo_revisions.DAL.Entities;

namespace exo_revisions.DAL.Interfaces;

public interface ICategoryRepository
{
    public IEnumerable<Category> GetAll();
    public Category? GetById(int id);
    public int Create(Category category);
    public bool Update(Category category);
    public bool Delete(int id);
}