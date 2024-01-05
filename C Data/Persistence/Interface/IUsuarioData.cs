using C_Data.Model;

namespace C_Data.Persistence.Interface;

public interface IUsuarioData
{
    Task <IEnumerable<Usuario>> ListAsync();
    Task AddAsync(Usuario usuario);
}