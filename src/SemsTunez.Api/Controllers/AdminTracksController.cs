using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SemsTunez.Application.DTOs.Tracks;
using SemsTunez.Application.Interfaces.Tracks;

namespace SemsTunez.Api.Controllers;

[ApiController]
[Route("api/admin/tracks")]
[Authorize(Roles = "Admin")]
public class AdminTracksController : ControllerBase
{
    private readonly ITrackService _trackService;

    public AdminTracksController(ITrackService trackService)
    {
        _trackService = trackService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _trackService.GetAllAsync());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
        => Ok(await _trackService.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTrackRequest request)
        => Ok(await _trackService.CreateAsync(request));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTrackRequest request)
        => Ok(await _trackService.UpdateAsync(id, request));

    [HttpPost("{id:guid}/publish")]
    public async Task<IActionResult> Publish(Guid id)
    {
        await _trackService.PublishAsync(id);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _trackService.DeleteAsync(id);
        return NoContent();
    }
}
