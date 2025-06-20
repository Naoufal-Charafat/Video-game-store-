using System;
using System.Data.SqlClient;

namespace SteamHadaLib
{
    public class CADDesarrollador
    {
        private string costring;
        public CADDesarrollador()
        {
        }
        public bool createDesarrollador()
        {
            //return new CADDesarrollador().createDesarrollador(this);
            return false;
        }
        public bool readDesarrollador()
        {
            // return new CADDesarrollador().readDesarrollador(this);
            return false;
        }
        public bool updateDesarrollador()
        {
            // return new CADDesarrollador().updateDesarrollador(this);
            return false;
        }
        public bool deleteDesarrollador()
        {
            return false;
            // return new CADDesarrollador().deleteDesarrollador(this);
        }

		public String gamesDeveloped(ENDesarrollador desarrollador, String games, int numberOfGames)
		{
			
			SqlConnection conn = null;
			// Encapsula todo el acceso a datos dentro del try

			try
			{
				conn = new SqlConnection(costring);
				//String comando = "select * from biblioteca where cliente = '" + cliente.Correo + "'";
				String comando = "select * from juegosdesarrollados, producto  where desarrollador = '" + desarrollador.Correo
				+ "' and juego in (select id from juegosdesarrollados where desarrollador = '" + desarrollador.Correo + "' )";
				conn.Open();
				SqlCommand cmd = new SqlCommand(comando, conn);
				SqlDataReader dr = cmd.ExecuteReader();

				while (dr.Read())
				{
					numberOfGames++;
					games += dr["nombre"].ToString() + " ";
				}

				conn.Close();
				return games;

			}
			catch (SqlException sqlex)
			{
				// Envuelve la excepción actual en una excepción mas relevante
				//throw new CADException("Error borrando el cliente: " + 2, sqlex );
				Console.WriteLine("User operation has failed.Error: {0} ", sqlex.Message.ToString());
				return null;
			}
			catch (Exception ex)
			{
				Console.WriteLine("User operation has failed.Error: {0} ", ex.Message);
				return null;
			}
			finally
			{
				if (conn != null) conn.Close(); // Se asegura de cerrar la conexión.
			}
			
		}


	}
}
