using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Gatitos.Models;

public class Persona
{
    [Key] 
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PersonaId { get; set; }
    
    [MinLength(5)]
    public string Nombre { get; set; }
    
    [MaxLength(15)]
    public string Trabajo { get; set; }
    
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
    
}