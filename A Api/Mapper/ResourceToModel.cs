using AutoMapper;
using C_Data.Model;
using PeruTripBackend.Request;

namespace PeruTripBackend.Mapper;

public class ResourceToModel:Profile
{
    public ResourceToModel()
    {
        CreateMap<RolRequest,Rol>();
        CreateMap<UsuarioRequest, Usuario>();

    }
}