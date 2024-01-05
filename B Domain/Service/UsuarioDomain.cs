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

    public async Task<bool> existeUsuario(string usuario, string contrasena)
    {
        return _usuarioData.ExisteUsuario(usuario, contrasena).Result;
    }
}