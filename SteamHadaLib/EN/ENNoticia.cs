using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.EN
{
    public class ENNoticia
    {
        private int ID = 1;
        private int cod;
        private string tl;
        private string descrp;
        private string fec;
        private double hor;
        private string URL;

        public string tittle
        {
            set { tl = value; }
            get => tl;
        }
        public string descripcion
        {
            set { descrp = value; }
            get => descrp;
        }

        public string fecha_publicacion
        {
            set { fec = value; }
            get => fec;
        }
        public double hora_publicacion
        {
            set { hor = value; }
            get => hor;
        }
        public int codigo
        {
            set { cod = value; }
            get => cod;
        }

        public ENNoticia()
        {

        }

        public ENNoticia(string titulo, string descripcion, string fecha, double hora)
        {
            this.codigo = ID;
            ID++;
            this.tittle = titulo;
            this.descripcion = descripcion;
            this.fecha_publicacion = fecha;
            this.hora_publicacion = hora;

        }

        /// <summary>
        /// Guarda este usuario en la BD. Para ello hará uso de los métodos apropiados de​ CADUsuario​. 
        /// Devuelve false si no se ha podido realizar la operación
        /// </summary>
        /// <returns></returns>
        public bool createNews()
        {
            bool crear;
            CADNoticia c = new CADNoticia();
            crear = c.createNews(this);

            if (crear == true)
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        ///  ​Recupera el usuario indicado de la BD
        /// </summary>
        /// <returns></returns>
        public bool readNews()
        {
            CADNoticia c = new CADNoticia();

            if (c.readNews(this) == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        ///  ​Recupera todos los usuarios de la BD y devuelve solo el primer usuario. 
        /// </summary>
        /// <returns></returns>
        public bool readAllNews()
        {
            CADNoticia c = new CADNoticia();

            if (c.readAllNews(this) == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        ///  ​Recupera todos los usuarios de la BD y devuelve solo el usuario siguiente al indicado.
        /// </summary>
        /// <returns></returns>
        public bool readNextNews()
        {
            CADNoticia c = new CADNoticia();

            if (c.readNextNews(this) == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        ///  ​Recupera todos los usuarios de la BD y devuelve solo el usuario anterior al indicado
        /// </summary>
        /// <returns></returns>
        public bool readPrevNews()
        {
            CADNoticia c = new CADNoticia();

            if (c.readPrevNews(this) == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        ///  ​Actualiza este usuario en la BD
        /// </summary>
        /// <returns></returns>
        public bool updateNews()
        {
            bool modificar;
            CADNoticia c = new CADNoticia();
            modificar = c.updateNews(this);

            if (modificar == true)
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Borra este usuario de la BD
        /// </summary>
        /// <returns></returns>
        public bool deleteNews()
        {
            bool borrar;
            CADNoticia c = new CADNoticia();
            borrar = c.deleteNews(this);

            if (borrar == true)
            {
                return true;
            }
            else
            {
                return false;

            }
        }
    }
}