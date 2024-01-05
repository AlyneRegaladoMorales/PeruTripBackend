using C_Data.Model;

namespace B_Domain.Service.Interface;

public interface IUsuarioDomain
{
    Task < IEnumerable < Usuario >> ListAsync();
    Task <Usuario> SaveAsync(Usuario usuario);
    Task<bool> existeUsuario(string usuario, string contrasena);
}