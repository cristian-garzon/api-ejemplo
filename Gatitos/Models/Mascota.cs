using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Gatitos.Models;

public class Mascota
{
    [Key] 
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MascotaId { get; set; }
    
    public string Nombre { get; set; }
    
    public int Años { get; set; }
    
    public string especie { get; set; }
    
    [JsonIgnore]
    public byte[]? Foto { get; set; }
    
    public int PersonaId { get; set; } 
    
    [JsonIgnore]
    public Persona? Persona { get; set; }

    [NotMapped]
    public int FotoHashCode
    {
        get
        {
            if(Foto != null)  return Foto.GetHashCode();
            return 0;
        }
    }
    
    public ICollection<vacuna>? Vacunas { get; set; }
    
    public Album? Album { get; set; }


}