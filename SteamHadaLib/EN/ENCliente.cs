using System;
using System.Web;
using System.Collections.Generic;
using System.Data;

namespace SteamHadaLib
{
    public class ENCliente : Usuario
    {
        private double saldo;
        private List<ENJuego> juegosComprados;

        public double Saldo { get => saldo; set => saldo = value; }
        public List<ENJuego> JuegosComprados { get => juegosComprados; set => juegosComprados = value; }

        public ENCliente(){}


        public ENCliente(String correo, String contrasenya)
        {
            this.correo = correo;
            this.contrasenya = contrasenya;
        }

        public ENCliente(String correo, String nombre, String apellidos, String contrasenya, String biografia, String foto, String tel)
        {

            this.nombre = nombre;
            this.correo = correo;
            this.contrasenya = contrasenya;
            this.apellidos = apellidos;
            this.contrasenya = contrasenya;
            this.biografia = biografia;
            this.foto = foto;
            this.telefono = tel;
        }
        public ENCliente(ENCliente en)
        {
            this.nombre = en.nombre;
            this.correo = en.correo;
            this.contrasenya = en.contrasenya;
            this.apellidos = en.apellidos;
            this.contrasenya = en.contrasenya;
            this.biografia = en.biografia;
            this.foto = en.foto;
            this.telefono = en.telefono;
        }
        public bool createCliente()
        {
            return new CADCliente().createCliente(this);
        }
        public bool readCliente()
        {
             return new CADCliente().readCliente(this);
          
        }
        public bool updateCliente()
        {
            // return new CADCliente().updateCliente(this);
            return false;
        }
   

        public bool deleteCliente()
        {
            return false;
            // return new CADCliente().deleteCliente(this);
        }

        public bool readListaJuegos()
        {
            return new CADCliente().readListaJuegos();
        }
        public DataSet readListaJuegosDesarrollados()
        {
            return new CADCliente().readListaJuegosDesarrollados(this);
        }

        public bool biblioteca_cliente(System.Web.UI.WebControls.GridView gridView1)
        {
            CADCliente cliente = new CADCliente();

            if (cliente.biblioteca_cliente(this, gridView1))
            {
                return true;
            }
            return false;
        }

		public String gamesBought(String games, int numberOfGames)
		{
			return new CADCliente().gamesBought(this, games, numberOfGames);
		}


    }
}