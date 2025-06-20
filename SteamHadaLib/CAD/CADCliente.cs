using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SteamHadaLib
{
    public class CADCliente
    {
        private string costring;
        public CADCliente()
        {
            costring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();

        }
        public bool createCliente(ENCliente cliente)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(costring))
                {
                    using (SqlCommand cmd = new SqlCommand("insertaCliente", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = cliente.Nombre;
                        cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = cliente.Correo;
                        cmd.Parameters.Add("@apellidos", SqlDbType.VarChar).Value = cliente.Apellidos;
                        cmd.Parameters.Add("@contrasena", SqlDbType.VarChar).Value = cliente.Contrasenya;
                        cmd.Parameters.Add("@foto", SqlDbType.VarChar).Value = cliente.Foto;
                        cmd.Parameters.Add("@biografia", SqlDbType.VarChar).Value = cliente.Biografia;
                        cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = cliente.Telefono;
                        con.Open();
                        return cmd.ExecuteNonQuery() != 0;

                    }
                }
            }
            catch (SqlException e)
            {
                return false;
            }
        }
        public bool readCliente(ENCliente cliente)
        {
            SqlConnection conn = null;
            // Encapsula todo el acceso a datos dentro del try
           
            String comando = "select *,(select count(*) from Administrador where usuario = '"+cliente.Correo+"') as administrador,(select count(*) from Desarrollador where usuario = '"+cliente.Correo+"' ) as desarrollador  from Usuario, Cliente where usuario=correo and correo='" + cliente.Correo+"' and contrasena='"+cliente.Contrasenya+"'";
            try
            {
                conn = new SqlConnection(costring);
                conn.Open();
                SqlCommand cmd = new SqlCommand(comando, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (!dr.HasRows) return false;
                dr.Read();
                cliente.Nombre = dr["nombre"].ToString();
                cliente.Correo = dr["correo"].ToString();
                cliente.Foto = dr["foto"].ToString();
                cliente.Saldo =Int32.Parse( dr["saldo"].ToString());
                cliente.Apellidos = dr["apellidos"].ToString();
                cliente.Telefono = dr["telefono"].ToString();
                cliente.Biografia = dr["biografia"].ToString();
                if (dr["administrador"].ToString().Equals("1"))
                {
                    cliente.Privilegio = 2;
                }
                else if (dr["Desarrollador"].ToString().Equals("1")) {
                    cliente.Privilegio = 1;
                }
                dr.Close();
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
            return true;
        }
        public bool updateCliente()
        {
            // return new CADCliente().updateCliente(this);
            return false;
        }
        public bool deleteCliente()
        {

            return false;
        }

        public bool readListaJuegos()
        {
			return false;
            //que devuelve el número de juegos que un cliente tiene comprados

        }
        public DataSet readListaJuegosDesarrollados(ENCliente cliente)
        {
            SqlConnection c = new SqlConnection(costring);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                SqlCommand command = new SqlCommand("select nombre,descripcion,precio,categoria from Juego,Producto,JuegosDesarrollados where producto=juego and id=producto and desarrollador='"+cliente.Correo+"' ", c);
                adapter.SelectCommand = command;
                adapter.Fill(ds, "JuegosDesarrollados");
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

        public bool biblioteca_cliente(ENCliente cliente, System.Web.UI.WebControls.GridView gridView1)
        {
            //la referencia para esta parte :  https://www.youtube.com/watch?v=vuoJeQ4L3WI
            
            string productos_comprados = "select DISTINCT    pr.nombre, j.categoria, pr.descripcion, pr.imagen  " +
                "from Producto pr,  Juego j, Biblioteca b " +
                "where  b.cliente = @cliente  and b.juego = pr.id and pr.id = j.producto";
            SqlConnection bd = new SqlConnection(costring);
            try
            {
                DataTable dtbl = new DataTable();
                bd.Open();
               
                SqlCommand comando = new SqlCommand(productos_comprados, bd);
                comando.Parameters.AddWithValue("@cliente",cliente.Correo);  //sobra con ponerle cliente.Nombre ya escoje solo el cliente
                SqlDataAdapter bdd = new SqlDataAdapter();
                bdd.SelectCommand = comando;
                bdd.Fill(dtbl);

                if (dtbl.Rows.Count > 0)
                {
                    gridView1.DataSource = dtbl;
                    gridView1.DataBind();
                    gridView1.Rows[0].Cells.Clear();
                    gridView1.Rows[0].Cells.Add(new System.Web.UI.WebControls.TableCell());
                    gridView1.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                    gridView1.Rows[0].Cells[0].Text = "NO HAY DATOS";
                    gridView1.Rows[0].Cells[0].HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Center;
                }
                gridView1.DataSource = dtbl;
                gridView1.DataBind();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }            
        }

		public bool updateProfilePic(ENCliente cliente, String pictureRoute)
		{ 
			//String command = "update usuario set foto ='"+pictureRoute+"' where usuario ='"+cliente.Correo+"'  and contrasena='" + cliente.Contrasenya + "'";
			SqlConnection conn = null;
			// Encapsula todo el acceso a datos dentro del try
			String comando = "update usuario set foto ='" + pictureRoute + "' where correo ='" + cliente.Correo + "'  and contrasena='" + cliente.Contrasenya + "'";
			try
			{
				conn = new SqlConnection(costring);
				conn.Open();
				SqlCommand cmd = new SqlCommand(comando, conn);
				if(cmd.ExecuteNonQuery()>0)
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
			return true;
        }

		public String gamesBought(ENCliente cliente, String games, int numberOfGames)
		{
			SqlConnection conn = null;
			// Encapsula todo el acceso a datos dentro del try

			try
			{
				conn = new SqlConnection(costring);
				//String comando = "select * from biblioteca where cliente = '" + cliente.Correo + "'";
				String comando = "select * from biblioteca, producto  where cliente = '" + cliente.Correo 
				+ "' and juego in (select id from biblioteca where cliente = '" + cliente.Correo + "' )";
				conn.Open();
				SqlCommand cmd = new SqlCommand(comando, conn);
				SqlDataReader dr = cmd.ExecuteReader();

				while(dr.Read())
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