using library.CAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamHadaLib
{
    public class ENEvento
    {
        static private int ID = 1;
        private int cod;
        private string name;
        private string descrp;
        private string f_init;
        private string f_fin;
        private double h_init;
        private double h_fin;

        public string nombre
        {
            set { name = value; }
            get => name;
        }
        public string descripcion
        {
            set { descrp = value; }
            get => descrp;
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

        public ENEvento(int cod)
        {
            this.codigo = cod;
        }
        public ENEvento()
        {
            codigo = ID;
            ID++;
        }

        public ENEvento(string name, string descripcion, string f_i, string f_f, double h_i, double h_f)
        {
            // esto tiene que ser manual, pero de momento lo dejaremos asi para no complicar
            this.cod = ID;
            ID++;
            this.nombre = name;
            this.descripcion = descripcion;
            this.fecha_inicio = f_i;
            this.fecha_fin = f_f;
            this.hora_fin = h_f;
            this.hora_inicio = h_i;

        }

        /// <summary>
        /// Guarda este usuario en la BD. Para ello hará uso de los métodos apropiados de​ CADUsuario​. 
        /// Devuelve false si no se ha podido realizar la operación
        /// </summary>
        /// <returns></returns>
        public bool createEvents()
        {
            bool crear;
            CADEvento c = new CADEvento();
            crear = c.createEvents(this);

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
        public bool readEvents()
        {
            CADEvento c = new CADEvento();

            if (c.readEvents(this) == false)
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
        public bool readAllEvents()
        {
            CADEvento c = new CADEvento();

            if (c.readAllEvents(this) == false)
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
        public bool readNextEvents()
        {
            CADEvento c = new CADEvento();

            if (c.readNextEvents(this) == false)
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
        public bool readPrevEvents()
        {
            CADEvento c = new CADEvento();

            if (c.readPrevEvents(this) == false)
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
        public bool updateEvents()
        {
            bool modificar;
            CADEvento c = new CADEvento();
            modificar = c.updateEvents(this);

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
        public bool deleteEvents()
        {
            bool borrar;
            CADEvento c = new CADEvento();
            borrar = c.deleteEvents(this);

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
