using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamHadaLib
{
    public class ENHilo
    {
        private int numero;
		private string titulo;
		private string descripcion;
		private DateTime fechaInicio;
        private string usuario;
		//private List<Mensajes> mensajes;          -> TODAVÍA NO EXISTE


		public int numeroHilo { get => numero; set => numero = value; }
        public DateTime fechaInicioHilo { get => fechaInicio; set => fechaInicio = value; }
		public string usuarioHilo { get => usuario; set => usuario = value; }
		public string tituloHilo { get => titulo; set => titulo = value; }
		public string descripcionHilo { get => descripcion; set => descripcion = value; }
		//public string horaInicioHilo { get => horaInicio; set => horaInicio = value; }

		public ENHilo()
        {
			numero = 0;
			titulo = "";
			fechaInicio = DateTime.Now;
			usuario = "";
        }

        public ENHilo(int numero, string titulo, string descripcion, DateTime fechaInicio, string usuario)
        {
			this.numero = numero;
			this.titulo = titulo;
			this.fechaInicio = fechaInicio;
			this.usuario = usuario;
			this.descripcion = descripcion;

        }
        public bool readForo()
        {
            return true;
        }

        public bool readHilo(ref string correoAutor)
        {
			CADHilo c = new CADHilo();

            return c.readHilo(this, ref correoAutor);
        }

		public bool ultimoHilo()
		{
			CADHilo c = new CADHilo();

			return c.ultimoHilo(this);
		}

		public bool updateHilo()
        {
			CADHilo c = new CADHilo();
            return c.updateHilo(this);
        }

        public bool createHilo()
        {
			CADHilo c = new CADHilo();
			return c.createHilo(this);
        }

        public bool deleteHilo()
        {
			CADHilo c = new CADHilo();
            return c.deleteHilo(this);
        }

    }
}