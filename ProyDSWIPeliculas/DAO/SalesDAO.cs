using ProyDSWIPeliculas.Models;

namespace ProyDSWIPeliculas.DAO
{
    public class SalesDAO
    {
        private string cad_cn;
        private  CarritoDAO carritoDao;

        public SalesDAO(IConfiguration cfg)
        {
            cad_cn = cfg.GetConnectionString("cn2");
            carritoDao = new CarritoDAO(cfg);   

        }

        public List<CarritoItem> ListarCarrito()
        {
            var lista = new List<CarritoItem>();
            try
            {
                var dr = SqlHelper.ExecuteReader(cad_cn, "PA_LISTAR_CARRITO");
                while (dr.Read())
                {
                    lista.Add(new CarritoItem
                    {
                        CodPeli = dr.GetInt32(0),
                        Nombre = dr.GetString(1),
                        Cantidad = dr.GetInt32(2),
                        Precio = dr.GetDecimal(3)
                    });
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar el carrito: " + ex.Message);
            }
            return lista;
        }

        // Método para registrar ventas basadas en el carrito
        public string RegistrarVenta(List<CarritoItem> carrito, string firstName, string lastName, string cardNumber, DateTime cardExpiry, string cardCVV, string address)
        {
            try
            {
                // Generar número de orden aleatorio
                int orderNumber = new Random().Next(1000, 9999);

                foreach (var item in carrito)
                {
                    SqlHelper.ExecuteNonQuery(cad_cn, "PA_REGISTRAR_VENTA",
                        orderNumber,
                        item.CodPeli,
                        item.Cantidad,
                        firstName,
                        lastName,
                        cardNumber,
                        cardExpiry,
                        cardCVV,
                        address
                    );
                }
                carritoDao.EliminarTodoCarrito();
                return $"Venta registrada con éxito bajo el número de orden {orderNumber}.";
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar la venta: " + ex.Message);
            }
        }

        // Método para listar las ventas
        public List<Sale> ListarVentas()
        {
            var lista = new List<Sale>();

            try
            {
                var dr = SqlHelper.ExecuteReader(cad_cn, "PA_LISTAR_VENTAS");
                while (dr.Read())
                {
                    lista.Add(new Sale
                    {
                        SaleId = dr.GetInt32(0),
                        OrderNumber = dr.GetInt32(1),
                        CodPeli = dr.GetInt32(2),
                        Nombre = dr.GetString(3),
                        Cantidad = dr.GetInt32(4),
                        Precio = dr.GetDecimal(5),
                        FirstName = dr.GetString(6),
                        LastName = dr.GetString(7),
                        Address = dr.GetString(8),
                        SaleDate = dr.GetDateTime(9),
                    });
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las ventas: " + ex.Message);
            }

            return lista;
        }
    }
}
