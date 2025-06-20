using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamHadaLib
{
    public class Reclamacion
    {
        public string Titulo { get; set; }
        public string Cuerpo { get; set; }
        public DateTime Fecha { get; set; }
        public int Pedido { get; set; }

        public Reclamacion()
        {

        }
        public Reclamacion( string titulo, string cuerpo, DateTime fecha, int pedido)
        {
            Titulo = titulo;
            Cuerpo = cuerpo;
            Fecha = fecha;
            Pedido = pedido;
        }

        public Reclamacion(Reclamacion rec)
        {
            Titulo = rec.Titulo;
            Cuerpo = rec.Cuerpo;
            Fecha = rec.Fecha;
            Pedido = rec.Pedido;
        }
        
    }
}
