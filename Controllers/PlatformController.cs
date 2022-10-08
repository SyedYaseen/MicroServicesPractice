using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;

namespace PlatformService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PlatformController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IPlatformRepo _platformRepo;

    public PlatformController(IMapper mapper, IPlatformRepo platformRepo)
    {
        _mapper = mapper;
        _platformRepo = platformRepo;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetAllPlatforms()
    {
        var platforms = _platformRepo.GetAllPlatforms();
        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
    }
}