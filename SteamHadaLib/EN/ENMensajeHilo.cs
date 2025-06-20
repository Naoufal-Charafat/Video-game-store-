using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamHadaLib
{


	public class ENMensajeHilo
	{
		private int hiloForo;
		private int cod;
		private string mensaje;
		private string usuario;
		private DateTime fechaHora;

		public int HiloForo { get => hiloForo; set => hiloForo = value; }
		public int Cod { get => cod; set => cod = value; }
		public string Mensaje { get => mensaje; set => mensaje = value; }
		public string Usuario { get => usuario; set => usuario = value; }
		public DateTime FechaHora { get => fechaHora; set => fechaHora = value; }

		public ENMensajeHilo() {
			hiloForo = 0;
			cod = 0;
			mensaje = "";
			usuario = "";
			FechaHora = DateTime.MinValue;
		}

		public ENMensajeHilo(int hilo, int c, string msg, string usr, DateTime fh) {
			hiloForo = hilo;
			cod = c;
			mensaje = msg;
			usuario = usr;
			fechaHora = fh;
		}

		public bool CreateMensaje() {
			CADMensajeHilo c = new CADMensajeHilo();

			return c.CreateMensaje(this);
		}

		public bool UpdateMensaje()
		{
			return true;
		}

		public bool DeleteMensaje()
		{
			return true;
		}

		public bool ReadMensaje()
		{
			return true;
		}
	}
}
