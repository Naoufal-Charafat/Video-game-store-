using System;
using System.Web.UI.WebControls;
using library.CAD;

namespace SteamHadaLib
{
    public class ENSorteo
    {
        // Falta el cliente y el Admin, pero eso ya se hará para la proxima entrega
        private int ID = 1;
        private int cod;
        private string name;
        private string img;
        private string descrp;
        private string usrAdm;
        private string f_init;
        private string f_fin;
        private double h_init;
        private double h_fin;

        public string descripcion
        {
            set { descrp = value; }
            get => descrp;
        }

        public string nombre
        {
            set { name = value; }
            get => name;
        }
        public string fecha_inicio
        {
            set { f_init = value; }
            get => f_init;
        }
        public string fecha_fin
        {
            set { f_fin = value; }
            get => f_fin;
        }

        public string usr_Adm
        {
            set { usrAdm = value; }
            get => usrAdm;
        }
        public string imagen
        {
            set { img = value; }
            get => img;
        }


        public double hora_inicio
        {
            set { h_init = value; }
            get => h_init;
        }
        public double hora_fin
        {
            set { h_fin = value; }
            get => h_fin;
        }
        public int codigo
        {
            set { cod = value; }
            get => cod;
        }

        public ENSorteo()
        {

        }

        public ENSorteo(string nombre, string fec_init, string fec_fin, double h_init, double h_fin)
        {
            this.cod = ID;
            ID++;
            this.nombre = nombre;
            this.fecha_inicio = fec_init;
            this.fecha_fin = fec_fin;
            this.hora_fin = h_fin;
            this.hora_inicio = h_init;

        }

        
        /// <summary>
        ///  ​Recupera el usuario indicado de la BD
        /// </summary>
        /// <returns></returns>
        public bool readSorteo()
        {
            return false;
        }

        /// <summary>
        ///  ​Recupera todos los usuarios de la BD y devuelve solo el primer usuario. 
        /// </summary>
        /// <returns></returns>
        public bool readAllSorteo()
        {
           return false;
        }

        /// <summary>
        ///  ​Recupera todos los usuarios de la BD y devuelve solo el usuario siguiente al indicado.
        /// </summary>
        /// <returns></returns>
        public bool readNextSorteo()
        {
            return false;
        }

        /// <summary>
        ///  ​Recupera todos los usuarios de la BD y devuelve solo el usuario anterior al indicado
        /// </summary>
        /// <returns></returns>
        public bool readPrevSorteo()
        {
            return false;
        }

        /// <summary>
        ///  ​Actualiza este usuario en la BD
        /// </summary>
        /// <returns></returns>
        public bool updateSorteo()
        {
            return false;
        }

        /// <summary>
        /// Borra este usuario de la BD
        /// </summary>
        /// <returns></returns>
        public bool deleteSorteo()
        {
            return false;
        }






        /// <summary>
        /// Guarda este usuario en la BD. Para ello hará uso de los métodos apropiados de​ CADUsuario​. 
        /// Devuelve false si no se ha podido realizar la operación
        /// </summary>
        /// <returns></returns>
        public bool createSorteo()
        {
            CADSorteo creaSorteo = new CADSorteo(); 

            if (creaSorteo.createSorteo(this) )
            {
                return true;
            }
            else
                return false;
        }


        public bool  Sorteo_principal(FormView sorteoPrincipal)
        {
            CADSorteo sorteoprincip = new CADSorteo();
            if (sorteoprincip.Sorteo_principal(this, sorteoPrincipal))
            {
                return true;
            }
            return false;
        }



        public bool TablaSorteos_anteriores(GridView tablaSorteosAnteriors)
        {
            CADSorteo sorteosAnteriores = new CADSorteo();
            if (sorteosAnteriores.TablaSorteos_anteriores(this,tablaSorteosAnteriors))
            {
                return true;
            }
            return false;
        }

    }
}