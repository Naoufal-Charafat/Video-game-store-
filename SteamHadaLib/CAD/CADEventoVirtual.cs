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
    class CADEventoVirtual : CADEvento
    {
        // falta la cadena de conexion
        private string constring;
        public CADEventoVirtual()
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }
       
        /// <summary>
        /// Crea un nuevo usuario en la BD con los datos de en
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public bool sendMessage(ENEventoVirtual en)
        {
            bool ok = true;
            ENEventoVirtual usu = en;
            SqlConnection c = new SqlConnection(constring);

            return ok;
        }

        public new bool createEvents(ENEventoVirtual en)
        {
            bool ok = true;
            ENEventoVirtual usu = en;
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Insert into Evento (cod) Values ('" + usu.codigo + "')", c);
                com.ExecuteNonQuery();

                SqlCommand com2 = new SqlCommand("Insert into Virtual (evento, autor, url, Juego)" +
                    "Values ('" + usu.codigo + "', '" + usu.autor + "', '" + usu.url + "', '" + usu.juego + "')", c);
                if (com2.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex) { ok = false; }
            finally
            {
                c.Close();
            }
            return ok;
        }

        public bool showMessages(ENEventoVirtual en)
        {
            bool ok = true;
            ENEventoVirtual usu = en;
            SqlConnection c = new SqlConnection(constring);

            return ok;
        }

        public bool rateStream(ENEventoVirtual en)
        {
            bool ok = true;
            ENEventoVirtual usu = en;
            SqlConnection c = new SqlConnection(constring);

            return ok;
        }

        public bool sendGift(ENEventoVirtual en)
        {
            bool ok = true;
            ENEventoVirtual usu = en;
            SqlConnection c = new SqlConnection(constring);

            return ok;
        }

    }
}
