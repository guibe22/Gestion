using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class AportesDetalle
    {
        [Key]
        public int Id { get; set; }
        public int TipoAporteId { get; set; }
        public float Valor { get; set; }
        public Personas? Persona { get; set; }

        [ForeignKey("TipoAporteId")]
        public int TiposAporteId { get; set; }


        
    }