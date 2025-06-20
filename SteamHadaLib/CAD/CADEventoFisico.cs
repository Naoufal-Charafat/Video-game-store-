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
    class CADEventFisico : CADEvento
    {
        // falta la cadena de conexion
        private string constring;//= "Data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\SteamHadaBBDD.mdf; User Instance = true";
        public CADEventFisico()
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }

        /// <summary>
        /// Crea un nuevo usuario en la BD con los datos de en
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public bool localReserve(ENEventoFisico en)
        {
            bool ok = true;
            ENEventoFisico usu = en;
            SqlConnection c = new SqlConnection(constring);

            return ok;
        }

        public bool buyTicket(ENEventoFisico en)
        {
            bool ok = true;
            ENEventoFisico usu = en;
            SqlConnection c = new SqlConnection(constring);

            return ok;
        }

    }
}
