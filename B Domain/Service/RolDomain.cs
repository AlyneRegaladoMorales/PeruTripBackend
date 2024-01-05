using B_Domain.Service.Interface;
using C_Data.Model;
using C_Data.Persistence.Interface;

namespace B_Domain.Service;

public class RolDomain : IRolDomain
{
    private readonly IRolData _rolData;
    public RolDomain(IRolData rolData)
    {
        _rolData = rolData;
    }
    
    public async Task<IEnumerable<Rol>> ListAsync()
    {
        return await _rolData.ListAsync();
    }
    
    public async Task<Rol> SaveAsync(Rol rol)
    {
        await _rolData.AddAsync(rol);
        return rol;
    }
}