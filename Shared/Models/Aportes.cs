using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Aportes
    {
        [Key]
        
        public int AporteId { get; set; }
        public DateTime Fecha { get; set; }
        public int PersonaId { get; set; }
        public string? Concepto { get; set; }
        public float Monto { get; set; }

        [ForeignKey("AporteId")]
        public List<AportesDetalle> DetalleAporte { get; set; } = new List<AportesDetalle>();
    }