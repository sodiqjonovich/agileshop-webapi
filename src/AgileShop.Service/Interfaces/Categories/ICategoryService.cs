using AgileShop.Service.Dtos.Categories;

namespace AgileShop.Service.Interfaces.Categories;

public interface ICategoryService
{
    public Task<bool> CreateAsync(CategoryCreateDto dto);

    public Task<bool> DeleteAsync(long categoryId);

    public Task<long> CountAsync();
}
