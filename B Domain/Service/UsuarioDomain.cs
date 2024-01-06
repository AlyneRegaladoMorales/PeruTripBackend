using B_Domain.Service.Interface;
using C_Data.Model;
using C_Data.Persistence.Interface;

namespace B_Domain.Service;

public class UsuarioDomain : IUsuarioDomain
{
    private readonly IUsuarioData  _usuarioData;
    public UsuarioDomain(IUsuarioData usuarioData)
    {
        _usuarioData = usuarioData;
    }
    
    public async Task<IEnumerable<Usuario>> ListAsync()
    {
        return await _usuarioData.ListAsync();
    }
    
    public async Task<Usuario> SaveAsync(Usuario usuario)
    {
        try
        {
            await _usuarioData.AddAsync(usuario);
            return usuario;
        }
        catch (Exception e)
        {
           throw new Exception(e.Message);
        }
        
    }

    public async Task<Usuario> existeUsuario(string usuario, string contrasena)
    {
        try
        {
            var usuarioExistente = await _usuarioData.ExisteUsuario(usuario, contrasena);
            if (usuarioExistente != null)
            {
                return usuarioExistente;
            }
            else
            {
                throw new Exception("No hay coincidencia");
            }
        }
        catch (Exception e)
        {
            throw new Exception($"Error al verificar la existencia del usuario: {e.Message}", e);
        }

    }
}