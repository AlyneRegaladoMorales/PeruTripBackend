using AutoMapper;
using C_Data.Model;
using PeruTripBackend.Request;
using PeruTripBackend.Response;

namespace PeruTripBackend.Mapper;

public class ModelToResource: Profile
{
    public ModelToResource()
    {
        CreateMap<Rol, RolRequest>();
        CreateMap<Rol, RolResponse>();

        CreateMap<Usuario, UsuarioRequest>();
        CreateMap<Usuario, UsuarioResponse>();

    }
}