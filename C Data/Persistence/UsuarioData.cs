using C_Data.Context;
using C_Data.Model;
using C_Data.Persistence.Interface;
using Microsoft.EntityFrameworkCore;

namespace C_Data.Persistence;

public class UsuarioData : IUsuarioData
{
    private readonly AppDbContext _appDbContext;
    
    public UsuarioData(AppDbContext appDbContext) 
    { 
        _appDbContext = appDbContext;
    }
  

    public async Task<IEnumerable<Usuario>> ListAsync()
    {
        return await _appDbContext.Usuarios
            .ToListAsync();
    }

    public async Task AddAsync(Usuario usuario)
    {
        _appDbContext.Usuarios.AddAsync(usuario);
        await _appDbContext.SaveChangesAsync();
    }
}