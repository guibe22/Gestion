using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Aportes
    {
        [Key]
        
        public int AporteId { get; set; }
        [Required(ErrorMessage = "La fecha es requerida")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "La persona es requerida")]
        [Range(0.01, double.MaxValue, ErrorMessage = "La persona es requerida")]
        public int PersonaId { get; set; }
        [Required(ErrorMessage = "El concepto es requerido")]
        public string? Concepto { get; set; }
        [Required(ErrorMessage = "El Monto es Requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El Monto debe ser mayor que cero")]
        public float Monto { get; set; }

        [ForeignKey("AporteId")]
        public List<AportesDetalle> DetalleAporte { get; set; } = new List<AportesDetalle>();
    }