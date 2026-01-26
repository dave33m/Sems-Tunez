using Microsoft.AspNetCore.Mvc;
using SemsTunez.Application.Interfaces.Public;

namespace SemsTunez.Api.Controllers;

[ApiController]
[Route("api/artists/{artistId:guid}/albums")]
public class ArtistAlbumsController : ControllerBase
{
    private readonly IAlbumQueryService _service;

    public ArtistAlbumsController(IAlbumQueryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetByArtist(Guid artistId)
        => Ok(await _service.GetByArtistAsync(artistId));
}
