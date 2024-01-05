using Microsoft.Build.Framework;

namespace PeruTripBackend.Request;

public class UsuarioRequest
{
    [Required]
    public string correo { get; set; }
    [Required]
    public string contrasena  { get; set; }
    [Required]
    public int rolId { get; set; }
}