
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamHadaLib
{
    class ENOfertas : ENProducto
    {
        private int codigoOferta;
        private string titulo;
        private int descuento;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private float precioFinal;

        public int CodigoOferta { get => codigoOferta; set => codigoOferta = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public int Descuento { get => descuento; set => descuento = value; }
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public float PrecioFinal { get => precioFinal; set => precioFinal = value; }


        public float precioConDescuento(float pvp, int descuento)
        {
            precioFinal = (pvp * descuento) / 100;
            return precioFinal;
        }
        public ENOfertas(int codigoOferta, int descuento, int codigoProducto, float precioProducto = 0)
        {
            this.codigoOferta = codigoOferta;
            precioProducto = Pvp; //se supone que es un atributo de producto
            precioFinal = precioConDescuento(precioProducto, descuento);
            codigoProducto = Code;  //se supone que es un atributo de producto
        }

        public bool crearProducto(ENJuego juego)
        {
            return false;
        }

        public bool leerProducto(ENJuego juego)
        {
            return false;
        }

        public bool modificarProducto(ENJuego juego)
        {
            return false;
        }

        public bool eliminarProducto(ENJuego juego)
        {
            return false;
        }
    }
}
