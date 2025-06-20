using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace SteamHadaLib
{
    public class CADHilo
    {
        private string constring;

        public CADHilo()
        {
			constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
		}

        public bool readHilo(ENHilo en, ref string correoAutor)
        {
			SqlConnection c = new SqlConnection(constring);
			bool correcto = true;
			try
			{
				c.Open();

				SqlCommand com = new SqlCommand("select * from HiloForo, Usuario where correo = usuario and numero = "
					+ en.numeroHilo, c);
				SqlDataReader dr = com.ExecuteReader();
				if (dr.Read())
				{
					en.tituloHilo = dr["titulo"].ToString();
					en.descripcionHilo = dr["descripcion"].ToString();
					en.fechaInicioHilo = Convert.ToDateTime(dr["fechaInicio"]);
					en.usuarioHilo = dr["nombre"].ToString();
					correoAutor = dr["correo"].ToString();
				}
				else correcto = false;
			}
			catch (SqlException ex)
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

		public bool ultimoHilo(ENHilo en)
		{
			SqlConnection c = new SqlConnection(constring);
			bool correcto = true;
			try
			{
				c.Open();

				SqlCommand com = new SqlCommand("select max(numero) as numHilo from HiloForo", c);
				SqlDataReader dr = com.ExecuteReader();
				if (dr.Read())
				{
					en.numeroHilo = int.Parse(dr["numHilo"].ToString());
				}
				else correcto = false;
			}
			catch (SqlException ex)
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

		public bool updateHilo(ENHilo en)
        {
			SqlConnection c = new SqlConnection(constring);
			bool correcto = true;
			try
			{
				c.Open();

				SqlCommand com = new SqlCommand("update HiloForo set titulo='" +
					en.tituloHilo + "', descripcion = '" +
					en.descripcionHilo + "' where numero = " +
					en.numeroHilo, c);
				com.ExecuteNonQuery();
			}
			catch (SqlException ex)
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

        public bool createHilo(ENHilo en)
        {
			SqlConnection c = new SqlConnection(constring);
			bool correcto = true;
			try
			{
				c.Open();

				SqlCommand com = new SqlCommand("insert into HiloForo(titulo, descripcion, fechaInicio, usuario) values ('"
					+ en.tituloHilo + "', '"
					+ en.descripcionHilo
					+ "', CURRENT_TIMESTAMP, '"
					+ en.usuarioHilo + "')", c);
				com.ExecuteNonQuery();
			}
			catch (SqlException ex)
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

        public bool deleteHilo(ENHilo en)
		{
			SqlConnection c = new SqlConnection(constring);
			bool correcto = true;
			try
			{
				c.Open();

				SqlCommand deleteMensajes = new SqlCommand("delete from Mensaje where hiloForo = " +
					en.numeroHilo, c);
				deleteMensajes.ExecuteNonQuery();

				SqlCommand deleteHilo = new SqlCommand("delete from HiloForo where numero = " +
					en.numeroHilo, c);
				deleteHilo.ExecuteNonQuery();

			}
			catch (SqlException ex)
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

	}
}
