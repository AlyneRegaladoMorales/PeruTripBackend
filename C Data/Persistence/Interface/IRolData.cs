using C_Data.Model;

namespace C_Data.Persistence.Interface;

public interface IRolData
{
    Task AddAsync(Rol rol);
    Task <IEnumerable<Rol>> ListAsync();
}