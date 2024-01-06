using C_Data.Model;

namespace C_Data.Persistence.Interface;

public interface IUsuarioData
{
    Task <IEnumerable<Usuario>> ListAsync();
    Task AddAsync(Usuario usuario);
    Task<Usuario> ExisteUsuario(string usuario, string contrasena);
    
}