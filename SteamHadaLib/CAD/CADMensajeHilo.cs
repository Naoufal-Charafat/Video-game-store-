using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace SteamHadaLib
{
	public class CADMensajeHilo
	{
		private string constring;

		public CADMensajeHilo()
		{
			constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
		}

		public bool CreateMensaje(ENMensajeHilo en)
		{
			SqlConnection c = new SqlConnection(constring);
			bool correcto = true;
			try
			{
				c.Open();
				SqlCommand com = new SqlCommand("Insert into Mensaje(hiloForo, cod, mensaje, fechaHora, usuario) values (" +
					en.HiloForo.ToString() +
					", 1 + (select ISNULL(max(cod), 0) from Mensaje where hiloForo = " + en.HiloForo.ToString()+ "), '" +
					en.Mensaje + "', " +
					"CURRENT_TIMESTAMP, '" +
					en.Usuario + "')", c);
				com.ExecuteNonQuery();

			}
			catch (Exception ex)
			{
				//Console.WriteLine("", ex.Message);
				correcto = false;
			}
			finally
			{
				c.Close();
			}
			return correcto;
		}

		public bool UpdateMensaje(ENMensajeHilo en)
		{
			return true;
		}
		public bool DeleteMensaje(ENMensajeHilo en)
		{
			return true;
		}
		public bool ReadMensaje(ENMensajeHilo en)
		{
			return true;
		}

	}
}

