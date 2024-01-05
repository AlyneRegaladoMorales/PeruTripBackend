using AutoMapper;
using B_Domain.Service.Interface;
using C_Data.Model;
using Microsoft.AspNetCore.Mvc;
using PeruTripBackend.Request;
using PeruTripBackend.Response;

namespace PeruTripBackend.Controllers;
[ApiController]
[Route("/api/v1/rol")]
public class RolController :ControllerBase
{
    private readonly IRolDomain _rolDomain;
    private readonly IMapper _mapper;
    
    public RolController(IRolDomain rolDomain, IMapper mapper)
    {
        _rolDomain = rolDomain;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<RolResponse>> GetAllAsync()
    {
        var rol = await _rolDomain.ListAsync();
        var response = _mapper.Map<IEnumerable<Rol>, IEnumerable<RolResponse>>(rol);
        return response;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] RolRequest resource)
    {
        try
        {
            var rol = _mapper.Map<RolRequest, Rol>(resource);
            await _rolDomain.SaveAsync(rol);
            return Ok(resource);
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }
    
}