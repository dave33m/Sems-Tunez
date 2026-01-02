using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SemsTunez.Application.DTOs.Artist;


[ApiController]
[Route("api/admin/artists")]
[Authorize(Roles = "Admin")]
public class AdminArtistsController : ControllerBase
{
    private readonly IArtistService _artists;

    public AdminArtistsController(IArtistService artists)
    {
        _artists = artists;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _artists.GetAllAsync());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
        => Ok(await _artists.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create(CreateArtistRequest request)
        => Ok(await _artists.CreateAsync(request));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateArtistRequest request)
        => Ok(await _artists.UpdateAsync(id, request));

    [HttpPost("{id:guid}/verify")]
    public async Task<IActionResult> Verify(Guid id)
    {
        await _artists.VerifyAsync(id);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _artists.DeleteAsync(id);
        return NoContent();
    }
}
