using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace C_Data.Model;

public class Usuario
{
    public int id { get; set; }
    public string correo { get; set; }
    public string contrasena { get; set; }
    public string estado { get; set; } = "activo";
    public DateTime fechaCreacion { get; set; }
    public int rolId { get; set; }
    [ForeignKey("rolId")] 
    public Rol rol { get; set; }
}