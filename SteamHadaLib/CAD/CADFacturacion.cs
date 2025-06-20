using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamHadaLib
{
    public class CADFacturacion
    {
        private string constring;

        public CADFacturacion()
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }
        //Esto es por si necesitamos leer todas las facturas de todos los clientes:
        public bool readFacturacion(ENFacturacion en)
        {
            SqlConnection conn = null;
            string comando = "Select * from Pedido";
            try
            {
                conn = new SqlConnection(constring);
                conn.Open();
                SqlCommand cmd = new SqlCommand(comando, conn);
                cmd.ExecuteReader();
            } catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if(conn != null)
                {
                    conn.Close();
                }
            }
            return true;
        }

        public DataSet obtenerFacturasPorCliente(string cliente)
        {
            SqlConnection conn = null;
            DataSet dsFacturas = null;
            //Encapsula todo el acceso a datos dentro del try
            string comando = "Select * from Pedido where cliente = '"
                             + cliente + "'";
            try
            {
                conn = new SqlConnection(constring);
                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(comando, conn);
                dsFacturas = new DataSet();
                sqlAdaptador.Fill(dsFacturas);

                return dsFacturas;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if(conn != null)
                {
                    conn.Close();
                }
            }
        }

        public bool insertarFacturacion(ENFacturacion en)
        {
            bool insertar = true;
            ENFacturacion fact = en;
            SqlConnection c = new SqlConnection(constring);

            try
            {
                c.Open();
                SqlCommand cmd = new SqlCommand("Insert Into Pedido (fecha, importe, producto, cliente) " +
                                                "VALUES ('" + en.fechaFact + "', '" + en.importeFact + "', '" + 
                                                en.getCodeProducto() + "', '" + en.getCorreoCliente() + "')", c);
                cmd.ExecuteNonQuery();
            } catch(Exception ex)
            {
                Console.WriteLine("No se ha podido insertar una factura en el usuario", ex.Message);
                insertar = false;
            }
            finally
            {
                c.Close();
            }
            return insertar;
        }

        /*
        public bool updateFacturacion(ENFacturacion en)
        {
            return true;
        }*/

        public bool deleteFacturacion(ENFacturacion en)
        {
            bool delete;
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Pedido WHERE numPedido = '" + en.pedidoFact + "'", c);
                cmd.ExecuteNonQuery();
                delete = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido borrar la factura ", ex.Message);
                delete = false;
            }
            finally
            {
                c.Close();
            }
            return delete;
        }
        
        /*
        public bool createLinPed(ENFacturacion en)
        {
            return true;
        }
        
        public bool addLinPed(ENFacturacion en)
        {
            return true;
        }
        public bool updateLinPed(ENFacturacion en)
        {
            return true;
        }
        public bool deleteLinPed(ENFacturacion en)
        {
            return true;
        }
        public bool readLinPed(ENFacturacion en)
        {
            return true;
        }*/
        public bool readReclamacion(ENFacturacion en, string correo)
        {
            bool read;
            SqlConnection c = new SqlConnection(constring);
            
            try
            {
                c.Open();

                SqlCommand cmdselect = new SqlCommand("Select * From Pedido where numPedido = '" + en.pedidoFact + "' AND cliente = '" + correo + "' ", c);
                SqlDataReader dr = cmdselect.ExecuteReader();


                if (dr.Read() == true)
                {
                    c.Close();
                    c.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Reclamacion WHERE pedido = " + en.pedidoFact, c);
                    SqlDataReader dr2 = cmd.ExecuteReader();

                    if (dr2.Read())
                    {
                        Reclamacion reclamacion = new Reclamacion();
                        reclamacion.Cuerpo = dr2["cuerpo"].ToString();
                        reclamacion.Titulo = dr2["titulo"].ToString();
                        en.cambiarReclamacion(reclamacion);
                        en.setCuerpo(dr2["cuerpo"].ToString());
                        en.setTitulo(dr2["titulo"].ToString());
                        read = true;
                    }
                    else
                    {
                        read = false;
                    }
                }
                else
                {
                    read = false;
                }
                dr.Close();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido leer la reclamacion ", ex.Message);
                read = false;
            }
            finally
            {
                c.Close();
            }
            return read;
        }
        public bool updateReclamacion(ENFacturacion en, string correo)
        {
            bool update;
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                
                SqlCommand cmdselect = new SqlCommand("Select * From Pedido where numPedido = '" + en.pedidoFact + "' AND cliente = '" + correo + "' ", c);
                SqlDataReader dr = cmdselect.ExecuteReader();
                
                if (dr.Read() == true)
                {
                    c.Close();
                    c.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Reclamacion SET cuerpo = '" + en.getCuerpoReclamacion() + "', titulo = '" +
                                                   en.getTituloReclamacion() + "', fechaHora = '" + en.getFechaReclamacion()
                                                   + "' WHERE pedido = '" + en.pedidoFact + "'", c);
                    cmd.ExecuteNonQuery();
                    update = true;
                }
                else
                {
                    update = false;
                }
                

            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido modificar la reclamacion ", ex.Message);
                update = false;
            }
            finally
            {
                c.Close();
            }
            return update;
        }
        public bool createReclamacion(ENFacturacion en, string correo)
        {
            bool create;
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand cmdselect = new SqlCommand("Select * From Pedido where numPedido = '" + en.pedidoFact + "' AND cliente = '" + correo + "' ", c);
                SqlDataReader dr = cmdselect.ExecuteReader();
                
                if (dr.Read() == true)
                {
                    c.Close();
                    c.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Reclamacion (titulo, cuerpo, fechaHora, pedido) VALUES ('" + en.getTituloReclamacion() +
                                                "', '" + en.getCuerpoReclamacion() + "', '" + en.getFechaReclamacion() + "', '" +
                                                en.getPedidoReclamacion() + "')", c);
                    cmd.ExecuteNonQuery();
                    create = true;
                }
                else
                {
                    create = false;

                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido crear la reclamacion ", ex.Message);
                create = false;
            }
            finally
            {
                c.Close();
            }
            return create;
        }
        public bool deleteReclamacion(ENFacturacion en, string correo)
        {
            bool delete;
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand cmdselect = new SqlCommand("Select * From Pedido where numPedido = '" + en.pedidoFact + "' AND cliente = '" + correo + "' ", c);
                SqlDataReader dr = cmdselect.ExecuteReader();
                
                if (dr.Read() == true)
                {
                    c.Close();
                    c.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Reclamacion WHERE pedido = '" + en.pedidoFact + "'", c);
                    cmd.ExecuteNonQuery();
                    delete = true;
                }
                else
                {
                    delete = false;
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido eliminar la reclamacion ", ex.Message);
                delete = false;
            }
            finally
            {
                c.Close();
            }
            return delete;
        }


    }
}
