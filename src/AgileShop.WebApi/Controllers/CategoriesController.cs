using AgileShop.DataAccess.Interfaces.Categories;
using AgileShop.DataAccess.Repositories.Categories;
using AgileShop.Domain.Entities.Categories;
using AgileShop.Service.Common.Helpers;
using AgileShop.Service.Dtos.Categories;
using AgileShop.Service.Interfaces.Categories;
using Microsoft.AspNetCore.Mvc;

namespace AgileShop.WebApi.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _service;
    public CategoriesController(ICategoryService service)
    {
        this._service = service;
    }

    [HttpGet]
    public async Task<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CategoryCreateDto dto)
        => Ok(await _service.CreateAsync(dto));

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(long categoryId)
        => Ok(await _service.DeleteAsync(categoryId));
}
