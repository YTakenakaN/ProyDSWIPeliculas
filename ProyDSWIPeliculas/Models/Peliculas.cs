using System.ComponentModel.DataAnnotations;

namespace ProyDSWIPeliculas.Models
{
    public class Peliculas
    {
        [Required]
        [Display(Name = "Código")]
        public int cod_peli { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre de la película es obligatorio.")]
        public string nom_peli { get; set; }

        [Display(Name = "Descripción")]
        public string desc_peli { get; set; }

        [Display(Name = "Año lanzamiento")]
        [Range(1900, 2100, ErrorMessage = "El año debe estar entre 1900 y 2100.")]
        public int anio_peli { get; set; }

        [Display(Name = "Código Idioma")]
        [Required(ErrorMessage = "El idioma es obligatorio.")]
        public int cod_idio { get; set; } 

        //Propiedad usada para el listado y detalle:

        [Display(Name = "Idioma")]
        public string nom_idio { get; set; } 

        [Display(Name = "Duración (min)")]
        [Range(1, 500, ErrorMessage = "La duración debe estar entre 1 y 500 minutos.")]
        public int dur_peli { get; set; }

        [Display(Name = "Precio Alquiler")]
        [Range(0.0, 100.0, ErrorMessage = "El precio debe ser un valor positivo menor a 100.")]
        public decimal pre_peli { get; set; }

        [Display(Name = "Stock")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock debe ser un valor positivo.")]
        public int stk_peli { get; set; }

    }
}
