using System.Data.SqlClient;
using ProyDSWIPeliculas.Models;

namespace ProyDSWIPeliculas.DAO
{
    public class CarritoDAO
    {
        private string cad_cn;

        public CarritoDAO(IConfiguration cfg)
        {
            cad_cn = cfg.GetConnectionString("cn2");
        }

        public void AgregarAlCarrito(int codPeli, int cantidad)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cad_cn, "PA_AGREGAR_AL_CARRITO",
                    codPeli, cantidad);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar al carrito: " + ex.Message);
            }
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

        public void EditarCantidadCarrito(int codPeli, int nuevaCantidad)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cad_cn, "PA_EDITAR_CANTIDAD_CARRITO",
                    codPeli, nuevaCantidad);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar cantidad en el carrito: " + ex.Message);
            }
        }

        public void EliminarDelCarrito(int codPeli)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cad_cn, "PA_ELIMINAR_DEL_CARRITO",
                    codPeli);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar del carrito: " + ex.Message);
            }
        }

        public void EliminarTodoCarrito()
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cad_cn, "PA_ELIMINAR_TODO_CARRITO", null);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar carrito: " + ex.Message);
            }
        }
    }
}