using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SteamHadaLib;
using System.Web.UI.WebControls;



namespace library.CAD
{
    class CADSorteo
    {
        // falta la cadena de conexion
        private string costring;
        public CADSorteo()
        {
            costring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }



        /// <summary>
        /// Devuelve solo el usuario indicado leído de la BD
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public bool readSorteo(ENSorteo en)
        {
            bool ok = true;

            SqlConnection con = new SqlConnection(costring);

            return ok;
        }

        /// <summary>
        /// Devuelve solo el primer usuario de la BD. 
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public bool readAllSorteo(ENSorteo en)
        {
            bool respuesta = true;

            SqlConnection con = new SqlConnection(costring);


            return respuesta;
        }

        /// <summary>
        /// Devuelve solo el usuario siguiente al indicado
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public bool readNextSorteo(ENSorteo en)
        {
            bool respuesta = true;

            SqlConnection con = new SqlConnection(costring);

            return respuesta;
        }

        /// <summary>
        ///  Devuelve solo el usuario anterior al indicado.
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public bool readPrevSorteo(ENSorteo en)
        {
            bool respuesta = true;

            SqlConnection con = new SqlConnection(costring);


            return respuesta;
        }

        /// <summary>
        /// Actualiza los datos de un usuario en la BD con los datos del parámetro en​
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public bool updateSorteo(ENSorteo en)
        {
            bool respuesta = true;
            SqlConnection c = new SqlConnection(costring);


            return respuesta;
        }

        /// <summary>
        /// Borra el usuario representado en ​'en'​ de la BD
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public bool deleteSorteo(ENSorteo en)
        {
            bool respuesta = true;
            SqlConnection c = new SqlConnection(costring);


            return respuesta;
        }








        /// <summary>
        /// Crea un nuevo usuario en la BD con los datos de en
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public bool createSorteo(ENSorteo sorteo)
        {

            string insertarSorteo = "insert into Sorteo(nombre,descripcion,imagen,fechaHora)" +
                "VALUES('" + sorteo.nombre + "','" + sorteo.descripcion + "','" + sorteo.imagen + "', CURRENT_TIMESTAMP )";

            SqlConnection bd = new SqlConnection(costring);
           try
           {
                bd.Open();
                SqlCommand comando = new SqlCommand(insertarSorteo, bd);
                //aqui auto se encrementa el id ya que se ejecuta el comando
                comando.ExecuteNonQuery();
                bd.Close();
                return true;
           }
           catch (Exception) { bd.Close(); return false; }
        }



        public bool Sorteo_principal(ENSorteo eNSorteo, FormView sorteoPrincipal)
        {

            //ESTA CONECTADO MEDIANTE {FormView ID="SorteoPrincipal"} EN SORTEO ASPX
            /*
            string sorteos_anteriores = "select imagen from Sorteo where fechaHora = (select max(fechaHora) from Sorteo)";
            SqlConnection bd = new SqlConnection(costring);
            try
            {
                DataTable dtbl = new DataTable();
                bd.Open();
                SqlCommand comando = new SqlCommand(sorteos_anteriores, bd);
                SqlDataAdapter bdd = new SqlDataAdapter();
                bdd.SelectCommand = comando;
                bdd.Fill(dtbl);

                if (dtbl.Rows.Count > 0)
                {
                    sorteoPrincipal.DataSource = dtbl;
                    sorteoPrincipal.DataBind();

                    
                    sorteoPrincipal.Row.Cells.Clear();
                    sorteoPrincipal.Row.Cells.Add(new System.Web.UI.WebControls.TableCell());
                    sorteoPrincipal.Row.Cells[0].ColumnSpan = dtbl.Columns.Count;
                    sorteoPrincipal.Row.Cells[0].Text = "NO HAY DATOS....XD";
                    sorteoPrincipal.Row.Cells[0].HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Center;
                }
                sorteoPrincipal.DataSource = dtbl;
                sorteoPrincipal.DataBind();
                bd.Close();
                return true;
            }
            catch (Exception) { bd.Close(); return false; }
            */
            return false;
        }


        public bool TablaSorteos_anteriores(ENSorteo eNSorteo, GridView tablaSorteosAnteriors)
        {
            string sorteos_anteriores = "select  nombre, imagen,descripcion from Sorteo where fechaHora " +
                "< (select max(fechaHora) from Sorteo) ORDER BY fechaHora DESC";
            SqlConnection bd = new SqlConnection(costring);
            try
            {
                DataTable dtbl = new DataTable();
                bd.Open();
                SqlCommand comando = new SqlCommand(sorteos_anteriores, bd);
                SqlDataAdapter bdd = new SqlDataAdapter();
                bdd.SelectCommand = comando;
                bdd.Fill(dtbl);

                if (dtbl.Rows.Count > 0)
                {
                    tablaSorteosAnteriors.DataSource = dtbl;
                    tablaSorteosAnteriors.DataBind();
                    tablaSorteosAnteriors.Rows[0].Cells.Clear();
                    tablaSorteosAnteriors.Rows[0].Cells.Add(new System.Web.UI.WebControls.TableCell());
                    tablaSorteosAnteriors.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                    tablaSorteosAnteriors.Rows[0].Cells[0].Text = "NO HAY DATOS....XD";
                    tablaSorteosAnteriors.Rows[0].Cells[0].HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Center;
                }
                tablaSorteosAnteriors.DataSource = dtbl;
                tablaSorteosAnteriors.DataBind();
                bd.Close();
                return true;
            }
            catch (Exception) { bd.Close(); return false; }
        }


    }
}