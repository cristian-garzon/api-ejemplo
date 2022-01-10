using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Gatitos.Models;

public class vacuna
{
    [Key] 
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int VacunaId { get; set; } 
    
    public string Nombre { get; set; }
    
    public double Peso { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime FechaProx { get; set; } 
    
    public int MascotaId { get; set; }
    
    [JsonIgnore]
    public Mascota? Mascota { get; set; }
    
}