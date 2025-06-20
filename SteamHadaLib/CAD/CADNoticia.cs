
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

namespace library
{
    class CADNoticia
    {
        private string constring;
        public CADNoticia()
        {
            //constring = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
        }


        /// <summary>
        /// Crea un nuevo usuario en la BD con los datos de en
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public bool createNews(ENNoticia en)
        {
            bool ok = true;
            ENNoticia usu = en;
            SqlConnection c = new SqlConnection(constring);

            return ok;
        }

        /// <summary>
        /// Devuelve solo el usuario indicado leído de la BD
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public bool readNews(ENNoticia en)
        {
            bool ok = true;

            SqlConnection con = new SqlConnection(constring);

            return ok;
        }

        /// <summary>
        /// Devuelve solo el primer usuario de la BD. 
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public bool readAllNews(ENNoticia en)
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
        public bool readNextNews(ENNoticia en)
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
        public bool readPrevNews(ENNoticia en)
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
        public bool updateNews(ENNoticia en)
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
        public bool deleteNews(ENNoticia en)
        {
            bool respuesta = true;
            SqlConnection c = new SqlConnection(constring);


            return respuesta;
        }

    }
}
