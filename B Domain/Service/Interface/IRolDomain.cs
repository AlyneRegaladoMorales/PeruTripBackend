using C_Data.Model;

namespace B_Domain.Service.Interface;

public interface IRolDomain
{
    Task<IEnumerable<Rol>> ListAsync();
    Task <Rol> SaveAsync(Rol rol);

}