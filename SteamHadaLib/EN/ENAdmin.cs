using library.EN;
using System;
using System.Collections.Generic;

namespace SteamHadaLib
{
    public class ENAdmin: Usuario
    {
        private List<ENSorteo> sorteos;
        private List<ENBaneado> baneados;

        public ENAdmin(String correo, String contrasenya)
        {
            this.correo = correo;
            this.contrasenya = contrasenya;
        }
        public ENAdmin(String correo, String nombre, String apellidos, String contrasenya, String biografia, String foto, string tel)
        {
            this.correo = correo;
            this.contrasenya = contrasenya;
            this.apellidos = apellidos;
            this.contrasenya = contrasenya;
            this.biografia = biografia;
            this.foto = foto;
            this.telefono = tel;
        }

        public List<ENSorteo> Sorteos { get => sorteos; set => sorteos = value; }
        public List<ENBaneado> Baneados { get => baneados; set => baneados = value; }
        public bool createAdmin()
        {
            //return new CADAdmin().createAdmin(this);
            return false;
        }
        public bool readAdmin()
        {
            // return new CADAdmin().readAdmin(this);
            return false;
        }
        public bool updateAdmin()
        {
            // return new CADAdmin().updateAdmin(this);
            return false;
        }
        public bool deleteAdmin()
        {
            return false;
            // return new CADAdmin().deleteAdmin(this);
        }

    }
}
