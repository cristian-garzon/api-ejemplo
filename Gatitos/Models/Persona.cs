using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Gatitos.Models;

public class Persona
{
    [Key] 
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PersonaId { get; set; }
    
    public string Nombre { get; set; }
    
    public string Apellido { get; set; }
    
    [MaxLength(30)]
    public string Trabajo { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
    
    public DateTime Nacimiento { get; set; }
    
    [JsonIgnore]
    public byte[]? Avatar { get; set; }
    
    [NotMapped]
    public int AvatarHashCode {
        get
        {
            if (Avatar != null) return Avatar.GetHashCode();
            return 0;
        }
    }
    
    public List<Mascota>? Mascotas { get; set; }

}