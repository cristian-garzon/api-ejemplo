using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Gatitos.Models;

public class Album
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AlbumId { get; set; }
    
    [DataType(DataType.DateTime)]
    public DateTime CreateAt { get; set; }

    public int MascotaId { get; set; }
    
    [JsonIgnore]
    public Mascota Mascota { get; set; }
    
    public List<Galeria>? Galerias { get; set; }

}