using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace SteamHadaLib
{
    public class CADMerch
    {
        private string constring;

        public CADMerch()
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }

        public bool insertMerch(ENMerch en)
        {
            SqlConnection conexion = new SqlConnection(constring);
            ENMerch merch = en;
            bool creado = false;

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("INSERT INTO Merchandising (producto, peso, volumen) VALUES ('" + merch.codeMerch + "', '" + merch.pesoMerch + "', '" + merch.volumenMerch + "')", conexion);
                comando.ExecuteNonQuery();
                creado = true;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Merchandising operation has failed. Error: " + e.Message);
                creado = false;
            }
            finally
            {
                conexion.Close();
            }
            return creado;
        }

        public bool deleteMerch(ENMerch en)
        {
            SqlConnection conexion = new SqlConnection(constring);
            ENMerch merch = en;
            bool actualizado = true;

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("DELETE FROM Merchandising WHERE producto = '" + en.codeMerch + "'", conexion);

                if (comando.ExecuteNonQuery() != 0) { actualizado = true; }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Fallo en la operación. Error: " + e.Message);
                actualizado = false;
            }
            finally
            {
                conexion.Close();

            }
            return actualizado;
        }

        public bool modifyMerch(ENMerch en)
        {
            SqlConnection conexion = new SqlConnection(constring);
            ENMerch merch = en;
            bool actualizado = true;

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("UPDATE Merchandising SET volumen = '" + en.volumenMerch + "', peso = '" + en.pesoMerch + "'  WHERE producto = '" + en.codeMerch + "'", conexion);

                if (comando.ExecuteNonQuery() != 0) { actualizado = true; }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Fallo en la operación. Error: " + e.Message);
                actualizado = false;
            }
            finally
            {
                conexion.Close();

            }
            return actualizado;
        }

        public bool readMerchFilter(ENMerch en)
        {
            SqlConnection conexion = new SqlConnection(constring);
            ENMerch merch = en;
            bool leido = true;

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT * FROM Producto, Merchandising WHERE nombre like '%" + merch.nameMerch + "%' and Producto.id = Merchandising.Producto", conexion);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    merch.codeMerch = int.Parse(lector["id"].ToString());
                    merch.nameMerch = lector["nombre"].ToString();
                    merch.descriptionMerch = lector["descripcion"].ToString();
                    merch.pvpMerch = float.Parse(lector["precio"].ToString());
                    merch.dataMerch = lector["fechaPublicacion"].ToString();
                    merch.imageMerch = lector["imagen"].ToString();
                    merch.pesoMerch = float.Parse(lector["peso"].ToString());
                    merch.volumenMerch = float.Parse(lector["volumen"].ToString());
                }
                lector.Close();

                if (merch.codeMerch == 0) { leido = false; }


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

        public ENMerch[] read5merch(ENMerch en)
        {
            SqlConnection conexion = new SqlConnection(constring);
            ENMerch[] merchArray = new ENMerch[5];
            int i = 0;



            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT * FROM Producto, Merchandising WHERE nombre like '%" + en.nameMerch + "%' and Producto.id = Merchandising.Producto", conexion);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read() && i < 5)
                {
                    ENMerch merch = new ENMerch();
                    merch.codeMerch = int.Parse(lector["id"].ToString());
                    merch.nameMerch = lector["nombre"].ToString();
                    merch.descriptionMerch = lector["descripcion"].ToString();
                    merch.pvpMerch = float.Parse(lector["precio"].ToString());
                    merch.dataMerch = lector["fechaPublicacion"].ToString();
                    merch.imageMerch = lector["imagen"].ToString();
                    merch.pesoMerch = float.Parse(lector["peso"].ToString());
                    merch.volumenMerch = float.Parse(lector["volumen"].ToString());

                    merchArray[i] = merch;
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
            return merchArray;
        }
    }
}