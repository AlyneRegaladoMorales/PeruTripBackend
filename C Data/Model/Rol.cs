using System.Text.Json.Serialization;

namespace C_Data.Model;

public class Rol
{
    public int id { get; set; }
    public string rol { get; set; }

    [JsonIgnore] 
    public List<Usuario> listaUsuarios { get; set; }

}