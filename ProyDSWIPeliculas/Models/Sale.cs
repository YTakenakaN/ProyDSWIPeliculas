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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CardNumber { get; set; }
        public DateTime CardExpiry { get; set; }
        public string CardCVV { get; set; }
        public string Address { get; set; }

        public DateTime SaleDate { get; set; }
    }
}