using System.ComponentModel.DataAnnotations;

public class Personas
    {
        [Key]
        public int PersonaId { get; set; }
        [Required]
        public String? Nombre { get; set; }
        public String? Telefono { get; set; }
        public String? Celular { get; set; }
        public String? Email { get; set; }
        public String? Direccion { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        public float TotalAportado { get; set; }


    }