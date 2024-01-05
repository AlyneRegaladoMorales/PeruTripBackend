using C_Data.Context;
using C_Data.Model;
using C_Data.Persistence.Interface;
using Microsoft.EntityFrameworkCore;

namespace C_Data.Persistence;

public class RolData : IRolData
{
    private readonly AppDbContext _appDbContext;
    
    public RolData( AppDbContext appDbContext) 
    { 
        _appDbContext = appDbContext;
    }
    //CRUD
    public async Task AddAsync(Rol rol)
    {
       _appDbContext.Rols.AddAsync(rol);
       await _appDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Rol>> ListAsync()
    {
        return await _appDbContext.Rols.ToListAsync();
    }
}