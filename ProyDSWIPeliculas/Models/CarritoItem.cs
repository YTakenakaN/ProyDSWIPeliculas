﻿namespace ProyDSWIPeliculas.Models
{
    public class CarritoItem
    {
        public int CodPeli { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal => Precio * Cantidad;
    }
}
