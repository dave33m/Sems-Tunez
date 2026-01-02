using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SemsTunez.Application.DTOs.Albums;
using SemsTunez.Application.Interfaces.Albums;


[ApiController]
[Route("api/admin/albums")]
[Authorize(Roles = "Admin")]
public class AdminAlbumsController : ControllerBase
{
    private readonly IAlbumService _albums;

    public AdminAlbumsController(IAlbumService albums)
    {
        _albums = albums;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _albums.GetAllAsync());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
        => Ok(await _albums.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create(CreateAlbumRequest request)
        => Ok(await _albums.CreateAsync(request));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateAlbumRequest request)
        => Ok(await _albums.UpdateAsync(id, request));

    [HttpPost("{id:guid}/publish")]
    public async Task<IActionResult> Publish(Guid id)
    {
        await _albums.PublishAsync(id);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _albums.DeleteAsync(id);
        return NoContent();
    }
}
