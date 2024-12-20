﻿using System.Data.SqlClient;
using System.Data;
using ProyDSWIPeliculas.Models;

namespace ProyDSWIPeliculas.DAO
{
    public class PeliculasDAO
    {

        private string cad_cn;

        public PeliculasDAO(IConfiguration cfg)
        {
            cad_cn = cfg.GetConnectionString("cn2");

        }

        public List<Peliculas> ListarPeliculas()
        {
            var lista = new List<Peliculas>();
            //
            var dr =
                SqlHelper.ExecuteReader(cad_cn, "PA_LISTAR_PELICULAS");
            while (dr.Read())
            {
                lista.Add(new Peliculas()
                {
                    cod_peli = dr.GetInt32(0),
                    nom_peli=dr.GetString(1),
                    desc_peli=dr.GetString(2),
                    anio_peli=dr.GetInt32(3),
                    cod_idio=dr.GetInt32(4),
                    nom_idio=dr.GetString(5),
                    dur_peli=dr.GetInt32(6),
                    pre_peli=dr.GetDecimal(7),
                    stk_peli=dr.GetInt32(8)

                });
            }
            //
            return lista;
        }

        public Peliculas BuscarPelicula(int codigo)
        {
            var buscado = ListarPeliculas()
                .Find(p => p.cod_peli.Equals(codigo));
            //
            return buscado;
        }

        public List<Idiomas> traerIdiomas()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(cad_cn, "PA_LISTAR_IDIOMAS");
            List<Idiomas> lista = new List<Idiomas>();
            while (dr.Read())
            {
                lista.Add(new Idiomas()
                {
                    cod_idio = dr.GetInt32(0),
                    nom_idio = dr.GetString(1)
                }
                );

            }
            dr.Close();
            return lista;
        }


        public string GrabarPeliculas(Peliculas obj, int opc)
        {
            try
            {
                if (opc == 1)
                {
                    SqlHelper.ExecuteNonQuery(cad_cn, "PA_GRABAR_PELICULA",
                        obj.cod_peli, obj.nom_peli, obj.desc_peli,
                        obj.anio_peli, obj.cod_idio, obj.dur_peli,
                        obj.pre_peli, obj.stk_peli);

                    return $"La nueva película: {obj.nom_peli}\nha sido registrada con éxito.";
                }
                else if (opc == 2)
                {
                    SqlHelper.ExecuteNonQuery(cad_cn, "PA_ACTUALIZAR_PELICULA",
                        obj.cod_peli, obj.nom_peli, obj.desc_peli,
                        obj.anio_peli, obj.cod_idio, obj.dur_peli,
                        obj.pre_peli, obj.stk_peli);

                    return $"La película con el código: {obj.cod_peli}\nha sido actualizada con éxito.";
                }
                else
                {
                    return "Operación inválida. El valor de 'opc' debe ser 1 (registrar) o 2 (actualizar).";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public string EliminarPelicula(int codPeli)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cad_cn, "PA_ELIMINAR_PELICULA",
                   codPeli);
         
                
                return "Pelicula Eliminada";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

}

