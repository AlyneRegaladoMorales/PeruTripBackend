using Microsoft.Build.Framework;

namespace PeruTripBackend.Request;

public class RolRequest
{
    [Required]
    public string Rol { get; set; }
}