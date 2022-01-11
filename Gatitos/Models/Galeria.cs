using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Gatitos.Models;

public class Galeria
{
    [Key] 
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public  int GaleriaId { get; set; }
    
    [JsonIgnore]
    public byte[]? Foto { get; set; }
    
    public DateTime Fecha { get; set; }
    
    public int AlbumId { get; set; }
    
    [JsonIgnore]
    public Album Album { get; set; }
    
    [NotMapped]
    public int HashCode {
        get
        {
            if(Foto != null) return Foto.GetHashCode();
            return 0;
        }}
}