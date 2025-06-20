using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamHadaLib
{
    public class ENFacturacion
    {
        private ENProducto compra;
        private ENCliente cliente;
        private Reclamacion reclamacion = new Reclamacion();

        //private List<linPed> linped;   -> ESTO YA NO EXISTE ACTUALMENTE

        public int pedidoFact { get; set; }
        public DateTime fechaFact { get; set; }
        public float importeFact { get; set; }
        //public bool reclamacionFact { get; set; }
        public void setTitulo(string titulo)
        {
            reclamacion.Titulo = titulo;
        }
        public void setCuerpo(string cuerpo)
        {
            reclamacion.Cuerpo = cuerpo;
        }
        public string getCorreoCliente()
        {
            return cliente.Correo;
        }
        public int getCodeProducto()
        {
            return compra.Code;
        }
        public string getCuerpoReclamacion()
        {
            return reclamacion.Cuerpo;
        }
        public string getTituloReclamacion()
        {
            return reclamacion.Titulo;
        }
        public DateTime getFechaReclamacion()
        {
            return reclamacion.Fecha;
        }
        public int getPedidoReclamacion()
        {
            return reclamacion.Pedido;
        }
        public void cambiarReclamacion(Reclamacion reclamacion)
        {
            this.reclamacion = new Reclamacion(reclamacion);
            //this.reclamacionFact = true;
        }
        public ENFacturacion()
        {
            pedidoFact = -1;
        }
        public ENFacturacion(int numped, DateTime fecha, ENProducto producto, ENCliente cli, Reclamacion recla)
        {
            pedidoFact = numped;
            fechaFact = fecha;
            compra = new ENProducto(producto);
            cliente = new ENCliente(cli);
            reclamacion = new Reclamacion(recla);
            //reclamacionFact = true;
            
        }

        public DataSet obtenerFacturasPorCliente(string cliente)
        {
            CADFacturacion factura = new CADFacturacion();
            return factura.obtenerFacturasPorCliente(cliente);
        }
        

        public bool readFacturacion()
        {
            CADFacturacion cad = new CADFacturacion();
            return cad.readFacturacion(this);
        }

        /* NO SE NECESITA CAMBIAR LA FACTURA??
        public bool updateFacturacion()
        {
            return true;
        }
        */
        public bool insertarFacturacion()
        {
            CADFacturacion cad = new CADFacturacion();
            return cad.insertarFacturacion(this);
        }

        public bool deleteFacturacion()
        {
            CADFacturacion cad = new CADFacturacion();
            return cad.deleteFacturacion(this);

        }

        /*public bool createLinPed()
        {
            return true;
        }

        public bool addLinPed()
        {
            return true;
        }
        public bool updateLinPed()
        {
            return true;
        }
        public bool deleteLinPed()
        {
            return true;
        }
        public bool readLinPed()
        {
            return true;
        }*/
        public bool readReclamacion(string correo)
        {
  
            CADFacturacion cad = new CADFacturacion();
            return cad.readReclamacion(this, correo);
        }
        public bool updateReclamacion(string correo)
        {
            CADFacturacion cad = new CADFacturacion();
            return cad.updateReclamacion(this, correo);

        }
        public bool createReclamacion(string correo)
        {
            CADFacturacion cad = new CADFacturacion();
            bool creado = cad.createReclamacion(this, correo);
            return creado;                
            
        }
        public bool deleteReclamacion(string correo)
        {
            CADFacturacion cad = new CADFacturacion();
            bool borrado = cad.deleteReclamacion(this, correo);
            return borrado;
        }

    }
}
