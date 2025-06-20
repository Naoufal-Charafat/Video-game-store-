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
    public class CADFaq
    {
        private string constring;
        public CADFaq()
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }
        public DataSet obtenerFaq()
        {
            SqlConnection conn = null;
            DataSet dsFaq = null;
            //Encapsula todo el acceso a datos dentro del try
            string comando = "Select * from Faqs";
            try
            {
                conn = new SqlConnection(constring);
                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(comando, conn);
                dsFaq = new DataSet();
                sqlAdaptador.Fill(dsFaq);

                return dsFaq;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public bool insertFaq(ENFaq en)
        {
            bool insertar = true;
            ENFaq faq = en;
            SqlConnection c = new SqlConnection(constring);

            try
            {
                c.Open();
                SqlCommand cmd = new SqlCommand("Insert Into Faqs (pregunta, respuesta) " +
                                                "VALUES ('" + en.Pregunta + "', '" + en.Respuesta + "')", c);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido insertar la pregunta y respuesta en el usuario", ex.Message);
                insertar = false;
            }
            finally
            {
                c.Close();
            }
            return insertar;
        }

        public bool deleteFaq(ENFaq en)
        {
            bool delete;
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Faqs WHERE cod = '" + en.Codigo + "'", c);
                cmd.ExecuteNonQuery();
                delete = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido borrar la pregunta y respuesta", ex.Message);
                delete = false;
            }
            finally
            {
                c.Close();
            }
            return delete;
        }

        public bool updateFaq(ENFaq en)
        {
            bool update;
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Faqs SET pregunta = '" + en.Pregunta + "', respuesta = '" +
                                                en.Respuesta + "' where cod = '" + en.Codigo + "'", c);
                cmd.ExecuteNonQuery();
                update = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido modificar la pregunta y respuesta ", ex.Message);
                update = false;
            }
            finally
            {
                c.Close();
            }
            return update;
        }
    }

   
}
