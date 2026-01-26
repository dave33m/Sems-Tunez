using Microsoft.AspNetCore.Mvc;
using SemsTunez.Application.Interfaces.Public;

namespace SemsTunez.Api.Controllers;

[ApiController]
[Route("api/albums")]
public class AlbumsController : ControllerBase
{
    private readonly IAlbumQueryService _service;

    public AlbumsController(IAlbumQueryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
        => Ok(await _service.GetByIdAsync(id));
}
