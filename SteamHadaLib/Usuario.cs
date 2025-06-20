using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace SteamHadaLib
{
	public class Usuario
	{
		private string costring;

		protected String correo, nombre, apellidos, contrasenya, biografia, foto, telefono;
		private int privilegio = 0;


		public string Correo { get => correo; set => correo = value; }
		public string Nombre { get => nombre; set => nombre = value; }
		public string Apellidos { get => apellidos; set => apellidos = value; }
		public string Contrasenya { get => contrasenya; set => contrasenya = value; }
		public string Biografia { get => biografia; set => biografia = value; }
		public string Foto { get => foto; set => foto = value; }
		public string Telefono { get => telefono; set => telefono = value; }
		public int Privilegio { get => privilegio; set => privilegio = value; }

		public Usuario(String correo, String contrasenya)
		{
			costring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
			this.correo = correo;
			this.contrasenya = contrasenya;

		}

		public Usuario(String correo, String nombre, String apellidos, String contrasenya, String biografia, String foto, string tel)
		{
			this.correo = correo;
			this.contrasenya = contrasenya;
			this.apellidos = apellidos;
			this.contrasenya = contrasenya;
			this.biografia = biografia;
			this.foto = foto;
			this.telefono = tel;
		}

		public Usuario()
		{
			costring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
		}

		public bool updateProfilePic(Usuario usu, String pictureRoute)
		{
			//String command = "update usuario set foto ='"+pictureRoute+"' where usuario ='"+cliente.Correo+"'  and contrasena='" + cliente.Contrasenya + "'";
			SqlConnection conn = null;
			// Encapsula todo el acceso a datos dentro del try
			String comando = "update usuario set foto ='" + pictureRoute + "' where correo ='" + usu.Correo + "'  and contrasena='" + usu.Contrasenya + "'";
			try
			{
				conn = new SqlConnection(costring);
				conn.Open();
				SqlCommand cmd = new SqlCommand(comando, conn);
				if (cmd.ExecuteNonQuery() > 0)
				{
					conn.Close();
					return true;
				}
				conn.Close();
				return false;

			}
			catch (SqlException sqlex)
			{
				// Envuelve la excepción actual en una excepción mas relevante
				//throw new CADException("Error borrando el cliente: " + 2, sqlex );
				Console.WriteLine("User operation has failed.Error: {0} ", sqlex.Message.ToString());
				return false;
			}
			catch (Exception ex)
			{
				Console.WriteLine("User operation has failed.Error: {0} ", ex.Message);
				return false;
			}
			finally
			{
				if (conn != null) conn.Close(); // Se asegura de cerrar la conexión.
			}
			//return true;
		}
		public bool changePassword(Usuario usu)
		{
			SqlConnection conn = null;
			// Encapsula todo el acceso a datos dentro del try
			String comando = "update usuario set contrasena ='" + usu.Contrasenya + "' where correo ='" + usu.Correo + "'";
			try
			{
				conn = new SqlConnection(costring);
				conn.Open();
				SqlCommand cmd = new SqlCommand(comando, conn);
				if (cmd.ExecuteNonQuery() > 0)
				{
					conn.Close();
					return true;
				}
				conn.Close();
				return false;

			}
			catch (SqlException sqlex)
			{
				// Envuelve la excepción actual en una excepción mas relevante
				//throw new CADException("Error borrando el cliente: " + 2, sqlex );
				Console.WriteLine("User operation has failed.Error: {0} ", sqlex.Message.ToString());
				return false;
			}
			catch (Exception ex)
			{
				Console.WriteLine("User operation has failed.Error: {0} ", ex.Message);
				return false;
			}
			finally
			{
				if (conn != null) conn.Close(); // Se asegura de cerrar la conexión.
			}
			//return true;
		}

		public bool updateEmail(Usuario origen, String newEmail)
		{
			SqlConnection conn = null;

			try
			{
				String commandoExisteUsuario = "select count(correo) cantidad from usuario where correo != '" + origen.Correo+
					"' and correo!= '"+ newEmail + "'";

				conn = new SqlConnection(costring);
				conn.Open();
				SqlCommand cmd = new SqlCommand(commandoExisteUsuario, conn);
				SqlDataReader dr = cmd.ExecuteReader();

				if(dr.Read())
				{
					if(int.Parse(dr["cantidad"].ToString())>0) //existe el usuario
					{
						conn.Close();
						return false;
					}
				}
				conn.Close();

				conn = new SqlConnection(costring);
				conn.Open();

				String comando = "update usuario set correo ='" + newEmail + "' where correo ='" + origen.Correo + "' ";

				SqlCommand cmdd = new SqlCommand(comando, conn);
				if (cmdd.ExecuteNonQuery() > 0)
				{
					conn.Close();
					return true;
				}
					
				
				conn.Close();
				return false;
			}
			catch (SqlException sqlex)
			{
				// Envuelve la excepción actual en una excepción mas relevante
				//throw new CADException("Error borrando el cliente: " + 2, sqlex );
				Console.WriteLine("User operation has failed.Error: {0} ", sqlex.Message.ToString());
				return false;
			}
			catch (Exception ex)
			{
				Console.WriteLine("User operation has failed.Error: {0} ", ex.Message);
				return false;
			}
			finally
			{
				if (conn != null) conn.Close(); // Se asegura de cerrar la conexión.
			}
		}

		public bool updateProfile(Usuario usu)
		{
			SqlConnection conn = null;

			try
			{
				conn = new SqlConnection(costring);
				conn.Open();

				String comando = "update usuario set nombre = '" + usu.Nombre + "', apellidos = '" + usu.Apellidos +
					"', telefono = '" + usu.Telefono + "', biografia = '" + usu.biografia + "' where correo = '" + usu.Correo + "'";

				SqlCommand cmdd = new SqlCommand(comando, conn);
				if (cmdd.ExecuteNonQuery() > 0)
				{
					conn.Close();
					return true;
				}

				conn.Close();
				return false;
			}
			catch (SqlException sqlex)
			{
				// Envuelve la excepción actual en una excepción mas relevante
				//throw new CADException("Error borrando el cliente: " + 2, sqlex );
				Console.WriteLine("User operation has failed.Error: {0} ", sqlex.Message.ToString());
				return false;
			}
			catch (Exception ex)
			{
				Console.WriteLine("User operation has failed.Error: {0} ", ex.Message);
				return false;
			}
			finally
			{
				if (conn != null) conn.Close(); // Se asegura de cerrar la conexión.
			}
		}
	}
}

