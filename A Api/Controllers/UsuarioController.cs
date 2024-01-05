using AutoMapper;
using B_Domain.Service.Interface;
using C_Data.Model;
using Microsoft.AspNetCore.Mvc;
using PeruTripBackend.Request;
using PeruTripBackend.Response;

namespace PeruTripBackend.Controllers;

[ApiController]
[Route("/api/v1/usuario")]
public class UsuarioController :ControllerBase
{
    private readonly IUsuarioDomain _usuarioDomain;
    private readonly IMapper _mapper;
    
    public UsuarioController(IUsuarioDomain usuarioDomain, IMapper mapper)
    {
        _usuarioDomain = usuarioDomain;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<UsuarioResponse>> GetAllAsync()
    {
        var usuario = await _usuarioDomain.ListAsync();
        var response = _mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioResponse>>(usuario);
        return response;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] UsuarioRequest resource)
    {
        try
        {
            
            Console.WriteLine(resource);
            var usuario = _mapper.Map<UsuarioRequest, Usuario>(resource);
            await _usuarioDomain.SaveAsync(usuario);
            return Ok(resource);
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }

    [HttpPost("acceso")]
    public async Task<IActionResult> AccesoAsync(string usuario, string contrasenia)
    {
        try
        {
            var usuarioResponse = await _usuarioDomain.existeUsuario(usuario, contrasenia);
            return Ok(usuarioResponse);
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }

}