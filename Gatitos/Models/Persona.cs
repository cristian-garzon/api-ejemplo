using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Gatitos.Context;
using Gatitos.Migrations;

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
    
    
}