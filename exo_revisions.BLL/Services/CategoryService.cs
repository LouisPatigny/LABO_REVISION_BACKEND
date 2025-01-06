using exo_revisions.BLL.Interfaces;
using exo_revisions.BLL.Mappers;
using exo_revisions.BLL.Models;
using exo_revisions.DAL.Interfaces;

namespace exo_revisions.BLL.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public IEnumerable<Category> GetAll()
    {
        return _categoryRepository.GetAll().Select(c => c.ToModel());
    }

    public Category? GetById(int id)
    {
        return _categoryRepository.GetById(id)?.ToModel();
    }

    public int Create(Category category)
    {
        return _categoryRepository.Create(category.ToEntity());
    }

    public bool Update(Category category)
    {
        return _categoryRepository.Update(category.ToEntity());
    }

    public bool Delete(int id)
    {
        return _categoryRepository.Delete(id);
    }
}