
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamHadaLib
{
    public class ENJuego : ENProducto
    {

        private String categoria;

        public string Categoria { get => categoria; set => categoria = value; }

        

        public int codeGame{get => this.Code;  set => Code = value;  }

        public string nameGame{get => Name;  set => Name = value;}
        public string dataGame { get => publicationData; set => publicationData = value; }
        public string imageGame { get => image; set => image = value; }
        public float pvpGame { get => pvp; set => pvp = value; }

        public ENJuego(string name, float pvp, string image, string description,string categoria,string usuario)
        {
            this.Name = name;
            this.Pvp = pvp;
            this.Image = image;
            this.Description = description;
            this.Categoria = categoria;
            this.Usuario = usuario;
        }


        public string descriptionGame{get => Description; set => Description = value;}


        public string categoryGame { get => categoria; set => categoria = value; }


        public ENJuego() { }

        public ENJuego(string n)
        {
            nameGame = n;
        }

        public ENJuego(string cat, int c, string n, float pv, string i, string d, string pd /*ENProducto pr*/)
        {
            categoryGame = cat;
            codeGame = c;
            nameGame = n;
            Pvp = pv;
            Image = i;
            descriptionGame = d;
            dataGame = pd;
        }

        public bool crearJuego()
        {
            return new CADJuego().crearJuego(this);
        }

        public bool leerJuego()
        {
            CADJuego merch = new CADJuego();
            return merch.leerJuego(this);
        }

        public bool modificarJuego()
        {
            return new CADJuego().modificarJuego(this);
        }

        public bool eliminarJuegoo()
        {
            return new CADJuego().eliminarJuegoo(this);
        }

        public ENJuego[] read5juegoAccion()
        {
            CADJuego juego = new CADJuego();
            return juego.read5juegoAccion(this);
        }

        public ENJuego[] read5juegoDeportes()
        {
            CADJuego juego = new CADJuego();
            return juego.read5juegoDeportes(this);
        }

        public ENJuego[] read5juegoAventuras()
        {
            CADJuego juego = new CADJuego();
            return juego.read5juegoAventuras(this);
        }

        public ENJuego[] read5juegoDisparos()
        {
            CADJuego juego = new CADJuego();
            return juego.read5juegoDisparos(this);
        }




    }
}
