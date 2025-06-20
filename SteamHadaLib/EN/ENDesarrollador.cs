using System;
using System.Collections.Generic;

namespace SteamHadaLib
{
    public class ENDesarrollador: Usuario
    {
        private double comision;
        private List<ENJuego> juegos;

        public ENDesarrollador(String correo, String contrasenya)
        {
            this.Correo = correo;
            this.Contrasenya = contrasenya;
        }

        public ENDesarrollador(String correo, String nombre, String apellidos, String contrasenya, String biografia, String foto, string tel)
        {
            this.Correo = correo;
            this.Contrasenya = contrasenya;
            this.Apellidos = apellidos;
            this.Contrasenya = contrasenya;
            this.Biografia = biografia;
            this.Foto = foto;
            this.Telefono = tel;
        }
        public double Comision { get => comision; set => comision = value; }
        public List<ENJuego> Juegos { get => juegos; set => juegos = value; }

        public bool createDesarrollador()
        {
            //return new CADDesarrollador().createDesarrollador(this);
            return false;
        }
        public bool readDesarrollador()
        {
            // return new CADDesarrollador().readDesarrollador(this);
            return false;
        }
        public bool updateDesarrollador()
        {
            // return new CADDesarrollador().updateDesarrollador(this);
            return false;
        }
        public bool deleteDesarrollador()
        {
            return false;
            // return new CADDesarrollador().deleteDesarrollador(this);
        }
	
		public String gamesDeveloped(String games, int numberOfGames)
		{
			return new CADDesarrollador().gamesDeveloped(this, games, numberOfGames);
		}


	}
}
