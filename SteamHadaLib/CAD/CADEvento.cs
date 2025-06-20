using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using System.Reflection.Emit;
using System.Collections;
using library.EN;

namespace SteamHadaLib
{
    class CADEvento
    {
        // falta la cadena de conexion
        private string constring;//= "Data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\SteamHadaBBDD.mdf; User Instance = true";
        public CADEvento()
        {
           constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }


        /// <summary>
        /// Crea un nuevo usuario en la BD con los datos de en
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public bool createEvents(ENEvento en)
        {
            bool ok = true;
            ENEvento usu = en;
            SqlConnection c = new SqlConnection(constring);

            return ok;
        }

        public bool createEvents(ENEventoVirtual en)
        {
            bool ok = true;
            ENEventoVirtual usu = en;
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand com2 = new SqlCommand("Insert into Virtual " +
                    "(evento, autor, url, Juego)" +
                    "Values ('" + usu.codigo + "', '" + usu.autor + "', '" + 
                    usu.url + "', '" + usu.juego + "')", c);

                com2.ExecuteNonQuery();
                
            }
            catch (Exception ex) {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                ok = false;
            }
            finally
            {
                c.Close();
            }
            return ok;
        }

        public bool createEvents(ENEventoFisico en)
        {
            bool ok = true;
            ENEventoFisico usu = en;
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Insert into Evento " +
                    "(cod, nombre, descripcion, fechaInicio, fechaFin, horaInicio ,horaFin)" +
                    "VALUES ('" + usu.codigo + "', '" + usu.nombre + "', '" + 
                    usu.descripcion + "', '" + usu.fecha_inicio + "', '" + usu.fecha_fin + "', '" +
                    usu.hora_inicio + "', '" + usu.hora_fin + "')", c);
                com.ExecuteNonQuery();

                SqlCommand com2 = new SqlCommand("Insert into Fisico" +
                    " (evento, localidad, provincia, precioEntrada, empresa, email)" +
                    "Values ('" + usu.codigo + "', '" + usu.localidad + "', '" + 
                    usu.provincia + "', '" + usu.precio + "', '" + usu.empresa + "', '" + 
                    usu.email + "')", c);
                com2.ExecuteNonQuery();
            }
            catch (Exception ex) {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                ok = false;
            }
            finally
            {
                c.Close();
            }
            return ok;
        }

        /// <summary>
        /// Devuelve solo el usuario indicado leído de la BD
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public bool readEvents(ENEvento en)
        {
            bool ok = true;

            SqlConnection con = new SqlConnection(constring);

            try
            {
                con.Open();

                SqlCommand c = new SqlCommand("SELECT * from Evento where Evento.cod like '%" + en.codigo + "%'", con);
                SqlDataReader dr = c.ExecuteReader();

                while (dr.Read())
                {
                    en.nombre = dr["nombre"].ToString();
                    en.descripcion = dr["descripcion"].ToString();      
                    en.fecha_fin = dr["fechaFin"].ToString();
                    en.fecha_inicio = dr["fechaInicio"].ToString();
                }

                dr.Close();

                c.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                ok = false;
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
            }
            finally { con.Close(); }
            return ok;
        }
        /// <summary>
        /// Devuelve solo el usuario indicado leído de la BD
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public bool readEvents(ENEventoFisico en)
        {
            bool ok = true;

            SqlConnection con = new SqlConnection(constring);

            try
            {
                con.Open();

                SqlCommand c = new SqlCommand("SELECT * from Fisico where Fisico.evento like '%" + en.codigo + "%'", con);
                SqlDataReader dr = c.ExecuteReader();

                while (dr.Read())
                {

                    en.empresa = dr["empresa"].ToString();
                    en.provincia = dr["provincia"].ToString();
                    en.localidad = dr["localidad"].ToString();
                    en.precio = int.Parse(dr["precioEntrada"].ToString());
                    en.telefono_empresa = int.Parse(dr["telefono"].ToString());
                    en.email = dr["email"].ToString();
                }

                dr.Close();

                return true;
            }
            catch (Exception ex)
            {
                ok = false;
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
            }
            finally { con.Close(); }
            return ok;
        }

        public DataSet readVideos(ENEventoVirtual en)
        {
            SqlConnection c = new SqlConnection(constring);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                SqlCommand command = new SqlCommand("select Juego,autor,url from Virtual where Juego='" + en.juego + "'", c);
                adapter.SelectCommand = command;
                adapter.Fill(ds, "Videos de:");
                adapter.Dispose();
                command.Dispose();
                c.Close();

            }
            catch (Exception ex)
            {
                return new DataSet();
            }
            finally { c.Close(); }
            return ds;
        }

        /// <summary>
        /// Devuelve solo el primer usuario de la BD. 
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public bool readAllEvents(ENEvento en)
        {
            bool respuesta = true;

            SqlConnection con = new SqlConnection(constring);


            return respuesta;
        }

        /// <summary>
        /// Devuelve solo el usuario siguiente al indicado
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public bool readNextEvents(ENEvento en)
        {
            bool respuesta = true;

            SqlConnection con = new SqlConnection(constring);

            return respuesta;
        }

        /// <summary>
        ///  Devuelve solo el usuario anterior al indicado.
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public bool readPrevEvents(ENEvento en)
        {
            bool respuesta = true;

            SqlConnection con = new SqlConnection(constring);


            return respuesta;
        }

        /// <summary>
        /// Actualiza los datos de un usuario en la BD con los datos del parámetro en​
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public bool updateEvents(ENEvento en)
        {
            bool respuesta = true;
            SqlConnection c = new SqlConnection(constring);


            return respuesta;
        }

        /// <summary>
        /// Borra el usuario representado en ​'en'​ de la BD
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public bool deleteEvents(ENEvento en)
        {
            bool respuesta = true;
            SqlConnection c = new SqlConnection(constring);


            return respuesta;
        }
    }
}
