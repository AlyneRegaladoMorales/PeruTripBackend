using System.Runtime.InteropServices.JavaScript;

namespace PeruTripBackend.Response;

public class UsuarioResponse
{
    public string correo { get; set; }
    public string estado { get; set; }
    public DateTime fechaCreacion { get; set; }
    public int rolId { get; set; }
}