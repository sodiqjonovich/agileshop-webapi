using AgileShop.DataAccess.Utils;
using AgileShop.Service.Dtos.Categories;
using AgileShop.Service.Interfaces.Categories;
using AgileShop.Service.Validators.Dtos.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgileShop.WebApi.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _service;
    private readonly int maxPageSize = 3;
    public CategoriesController(ICategoryService service)
    {
        this._service = service;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpGet("{categoryId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByIdAsync(long categoryId)
        => Ok(await _service.GetByIdAsync(categoryId));

    [HttpGet("count")]
    [AllowAnonymous]
    public async Task<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAsync([FromForm] CategoryCreateDto dto)
    {
        var createValidator = new CategoryCreateValidator();
        var result = createValidator.Validate(dto);
        if (result.IsValid) return Ok(await _service.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }

    [HttpPut("{categoryId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAsync(long categoryId, [FromForm] CategoryUpdateDto dto)
    {
        var updateValidator = new CategoryUpdateValidator();
        var validationResult = updateValidator.Validate(dto);
        if (validationResult.IsValid) return Ok(await _service.UpdateAsync(categoryId, dto));
        else return BadRequest(validationResult.Errors);
    }

    [HttpDelete("{categoryId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(long categoryId)
        => Ok(await _service.DeleteAsync(categoryId));
}
