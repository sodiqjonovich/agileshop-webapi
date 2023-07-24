using AgileShop.DataAccess.Interfaces.Categories;
using AgileShop.DataAccess.Utils;
using AgileShop.Domain.Entities.Categories;
using AgileShop.Domain.Exceptions.Categories;
using AgileShop.Domain.Exceptions.Files;
using AgileShop.Service.Common.Helpers;
using AgileShop.Service.Dtos.Categories;
using AgileShop.Service.Interfaces.Categories;
using AgileShop.Service.Interfaces.Common;
using Microsoft.Extensions.Caching.Memory;

namespace AgileShop.Service.Services.Categories;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;
    private readonly IFileService _fileService;
    private readonly IMemoryCache _memoryCache;
    private readonly IPaginator _paginator;

    public CategoryService(ICategoryRepository categoryRepository,
        IFileService fileService,
        IMemoryCache memoryCache,
        IPaginator paginator)
    {
        this._repository = categoryRepository;
        this._fileService = fileService;
        this._memoryCache = memoryCache;
        this._paginator = paginator;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(CategoryCreateDto dto)
    {
        string imagepath = await _fileService.UploadImageAsync(dto.Image);
        Category category = new Category()
        {
            ImagePath = imagepath,
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime()
        };
        var result = await _repository.CreateAsync(category);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long categoryId)
    {
        var category = await _repository.GetByIdAsync(categoryId);
        if (category is null) throw new CategoryNotFoundException();

        var result = await _fileService.DeleteImageAsync(category.ImagePath);
        if (result == false) throw new ImageNotFoundException();

        var dbResult = await _repository.DeleteAsync(categoryId);
        return dbResult > 0;
    }

    public async Task<IList<Category>> GetAllAsync(PaginationParams @params)
    {
        var categories = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return categories;
    }

    public async Task<Category> GetByIdAsync(long categoryId)
    {
        var category = await _repository.GetByIdAsync(categoryId);
        if (category is null) throw new CategoryNotFoundException();
        return category;
    }

    public async Task<bool> UpdateAsync(long categoryId, CategoryUpdateDto dto)
    {
        var category = await _repository.GetByIdAsync(categoryId);
        if (category is null) throw new CategoryNotFoundException();

        // parse new items to category
        category.Name = dto.Name;
        category.Description = dto.Description;

        if (dto.Image is not null)
        {
            // delete old image
            var deleteResult = await _fileService.DeleteImageAsync(category.ImagePath);
            if (deleteResult is false) throw new ImageNotFoundException();

            // upload new image
            string newImagePath = await _fileService.UploadImageAsync(dto.Image);

            // parse new path to category
            category.ImagePath = newImagePath;
        }
        // else category old image have to save

        category.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(categoryId, category);
        return dbResult > 0;
    }
}
