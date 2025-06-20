using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SteamHadaLib
{
    class CADJuego //: CADProducto
    {
        private string constring;

        public CADJuego() {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }

        public bool crearJuego(ENJuego juego)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();
                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand("insertaJuego", con))
                    {
                        SqlCommand command = new SqlCommand("select nombre,descripcion,precio,categoria from Juego,Producto,JuegosDesarrollados where producto=juego and id=producto and desarrollador='"+juego.Usuario+"' ", con);
                        adapter.SelectCommand = command;
                        adapter.Fill(ds, "JuegosDesarrollados");
                        DataTable t = new DataTable();
                        t = ds.Tables["JuegosDesarrollados"];
                        DataRow nuevaFila = t.NewRow();
                        nuevaFila[0] = juego.Name;
                        nuevaFila[1] = juego.Description;
                        nuevaFila[2] = juego.Pvp;
                        nuevaFila[3] = juego.Categoria;
                        t.Rows.Add(nuevaFila);

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = juego.Name;
                        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = juego.Description;
                        cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = juego.Pvp;
                       // cmd.Parameters.Add("@contrasena", SqlDbType.VarChar).Value = cliente.Contrasenya;
                        cmd.Parameters.Add("@foto", SqlDbType.VarChar).Value = juego.Image;
                        cmd.Parameters.Add("@categoria", SqlDbType.VarChar).Value = juego.Categoria;
                        cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = juego.Usuario;
                        con.Open();
                        bool query = cmd.ExecuteNonQuery() != 0;
                        con.Close();
                        return query;

                    }
                }
            }
            catch (SqlException e)
            {
                return false;
            }
        }


        public bool modificarJuego(ENJuego juego)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();
                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand("actualizaJuego", con))
                    {
                        SqlCommand command = new SqlCommand("select nombre,descripcion,precio,categoria from Juego,Producto,JuegosDesarrollados where producto=juego and id=producto and desarrollador='"+juego.Usuario+"' ", con);
                        adapter.SelectCommand = command;
                        adapter.Fill(ds, "JuegosDesarrollados");
                        DataTable t = new DataTable();
                        t = ds.Tables["JuegosDesarrollados"];
                        for (int i = 0; i < t.Rows.Count; i++) {
                           
                            if (t.Rows[i][0].ToString()== juego.Name) {
                                t.Rows[i].BeginEdit();
                                t.Rows[i][1] = juego.Description;
                                t.Rows[i][2] = juego.Pvp;
                                t.Rows[i][3] = juego.Categoria;
                                t.Rows[i].EndEdit();
                            }
                        }
                       


                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = juego.Name;
                        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = juego.Description;
                        cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = juego.Pvp;
                        // cmd.Parameters.Add("@contrasena", SqlDbType.VarChar).Value = cliente.Contrasenya;
                        cmd.Parameters.Add("@foto", SqlDbType.VarChar).Value = juego.Image;
                        cmd.Parameters.Add("@categoria", SqlDbType.VarChar).Value = juego.Categoria;
                        con.Open();
                        bool query = cmd.ExecuteNonQuery() != 0;
                        con.Close();
                        return query;

                    }
                }
            }
            catch (SqlException e)
            {
                return false;
            }
        }
        public bool leerJuego(ENJuego en)
        {
            SqlConnection conexion = new SqlConnection(constring);
            ENJuego juego = en;
            bool leido = true;

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT * FROM Producto, Juego WHERE nombre like '%" + juego.nameGame + "%' and Producto.id = Juego.Producto", conexion);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    juego.codeGame = int.Parse(lector["id"].ToString());
                    juego.nameGame = lector["nombre"].ToString();
                    juego.descriptionGame = lector["descripcion"].ToString();
                    juego.Pvp = float.Parse(lector["precio"].ToString());
                    juego.dataGame = lector["fechaPublicacion"].ToString();
                    juego.Image = lector["imagen"].ToString();
                    juego.categoryGame = lector["categoria"].ToString();
                }
                lector.Close();

                if (juego.codeGame == 0) { leido = false; }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Fallo en la operación. Error: " + e.Message);
                leido = false;
            }
            finally
            {
                conexion.Close();

            }
            return leido;
        }

        public ENJuego[] read5juegoAccion(ENJuego en)
        {
            SqlConnection conexion = new SqlConnection(constring);
            ENJuego[] JuegoArray = new ENJuego[5];
            int i = 0;



            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT * FROM Producto, Juego WHERE nombre like '%" + en.nameGame + "%' and Producto.id = Juego.Producto and Juego.categoria = 'Acción'", conexion);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read() && i < 5)
                {
                    ENJuego Juego = new ENJuego();
                    Juego.codeGame = int.Parse(lector["id"].ToString());
                    Juego.nameGame = lector["nombre"].ToString();
                    Juego.descriptionGame = lector["descripcion"].ToString();
                    Juego.Pvp = float.Parse(lector["precio"].ToString());
                    Juego.dataGame = lector["fechaPublicacion"].ToString();
                    Juego.Image = lector["imagen"].ToString();
                    Juego.categoryGame = lector["categoria"].ToString();

                    JuegoArray[i] = Juego;
                    i++;
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine("Fallo en la operación. Error: " + e.Message);

            }
            finally
            {
                conexion.Close();

            }
            return JuegoArray;
        }

        public ENJuego[] read5juegoAventuras(ENJuego en)
        {
            SqlConnection conexion = new SqlConnection(constring);
            ENJuego[] JuegoArray = new ENJuego[5];
            int i = 0;



            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT * FROM Producto, Juego WHERE nombre like '%" + en.nameGame + "%' and Producto.id = Juego.Producto and Juego.categoria = 'Aventuras'", conexion);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read() && i < 5)
                {
                    ENJuego Juego = new ENJuego();
                    Juego.codeGame = int.Parse(lector["id"].ToString());
                    Juego.nameGame = lector["nombre"].ToString();
                    Juego.descriptionGame = lector["descripcion"].ToString();
                    Juego.Pvp = float.Parse(lector["precio"].ToString());
                    Juego.dataGame = lector["fechaPublicacion"].ToString();
                    Juego.Image = lector["imagen"].ToString();
                    Juego.categoryGame = lector["categoria"].ToString();

                    JuegoArray[i] = Juego;
                    i++;
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine("Fallo en la operación. Error: " + e.Message);

            }
            finally
            {
                conexion.Close();

            }
            return JuegoArray;
        }

        public ENJuego[] read5juegoDeportes(ENJuego en)
        {
            SqlConnection conexion = new SqlConnection(constring);
            ENJuego[] JuegoArray = new ENJuego[5];
            int i = 0;



            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT * FROM Producto, Juego WHERE nombre like '%" + en.nameGame + "%' and Producto.id = Juego.Producto and Juego.categoria = 'Deportes'", conexion);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read() && i < 5)
                {
                    ENJuego Juego = new ENJuego();
                    Juego.codeGame = int.Parse(lector["id"].ToString());
                    Juego.nameGame = lector["nombre"].ToString();
                    Juego.descriptionGame = lector["descripcion"].ToString();
                    Juego.Pvp = float.Parse(lector["precio"].ToString());
                    Juego.dataGame = lector["fechaPublicacion"].ToString();
                    Juego.Image = lector["imagen"].ToString();
                    Juego.categoryGame = lector["categoria"].ToString();

                    JuegoArray[i] = Juego;
                    i++;
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine("Fallo en la operación. Error: " + e.Message);

            }
            finally
            {
                conexion.Close();

            }
            return JuegoArray;
        }

        public ENJuego[] read5juegoDisparos(ENJuego en)
        {
            SqlConnection conexion = new SqlConnection(constring);
            ENJuego[] JuegoArray = new ENJuego[5];
            int i = 0;



            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT * FROM Producto, Juego WHERE nombre like '%" + en.nameGame + "%' and Producto.id = Juego.Producto and Juego.categoria = 'Disparos'", conexion);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read() && i < 5)
                {
                    ENJuego Juego = new ENJuego();
                    Juego.codeGame = int.Parse(lector["id"].ToString());
                    Juego.nameGame = lector["nombre"].ToString();
                    Juego.descriptionGame = lector["descripcion"].ToString();
                    Juego.Pvp = float.Parse(lector["precio"].ToString());
                    Juego.dataGame = lector["fechaPublicacion"].ToString();
                    Juego.Image = lector["imagen"].ToString();
                    Juego.categoryGame = lector["categoria"].ToString();

                    JuegoArray[i] = Juego;
                    i++;
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine("Fallo en la operación. Error: " + e.Message);

            }
            finally
            {
                conexion.Close();

            }
            return JuegoArray;
        }
        public bool eliminarJuegoo(ENJuego juego)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();
                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand("delete Producto where nombre='" + juego.Name + "'", con))
                    {
                        SqlCommand command = new SqlCommand("select nombre,descripcion,precio,categoria from Juego,Producto,JuegosDesarrollados where producto=juego and id=producto and desarrollador='" + juego.Usuario + "' ", con);
                        adapter.SelectCommand = command;
                        adapter.Fill(ds, "JuegosDesarrollados");
                        DataTable t = new DataTable();
                        t = ds.Tables["JuegosDesarrollados"];
                        for (int i = 0; i < t.Rows.Count; i++)
                        {
                            if (t.Rows[i][0].ToString() == juego.Name)
                            {
                                t.Rows[i].BeginEdit();
                                t.Rows[i].Delete();
                                t.Rows[i].EndEdit();
                                break;
                            }
                        }
                        con.Open();
                        bool query = cmd.ExecuteNonQuery() != 0;
                        con.Close();
                        return query;

                    }
                }
            }
            catch (SqlException e)
            {
                return false;
            }
        }
    }

}
