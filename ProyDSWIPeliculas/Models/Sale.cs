using System.ComponentModel.DataAnnotations;

namespace ProyDSWIPeliculas.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public int OrderNumber { get; set; }
        public int CodPeli { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Total => Precio * Cantidad;

        // Información del comprador
        [Required(ErrorMessage ="El nombre es requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Debe tener como minimo 3 a 50 caracteres")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Debe tener como minimo 3 a 50 caracteres")]

        public string LastName { get; set; }

        [Required(ErrorMessage = "El numero de tarjeta es requerido")]
        [StringLength(16, MinimumLength = 12, ErrorMessage = "Debe tener como minimo 12 a 16 caracteres")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Solo números.")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "La fecha de expiración es requerido")]
        public DateTime CardExpiry { get; set; }


        [Required(ErrorMessage = "El CVV es requerido")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Debe tener 3 digitos")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Solo números.")]
        public string CardCVV { get; set; }

        [Required(ErrorMessage = "La dirección es requerido")]
        public string Address { get; set; }

        public DateTime SaleDate { get; set; }
    }
}