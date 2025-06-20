using System;

namespace SteamHadaLib
{
    public class ENBaneado: Usuario
    {
        String causa, fecha, hora, fechaExpiracion;

        public ENBaneado(String correo, String contrasenya)
        {
            this.correo = correo;
            this.contrasenya = contrasenya;
        }

        public string Causa { get => causa; set => causa = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Hora { get => hora; set => hora = value; }
        public string FechaExpiracion { get => fechaExpiracion; set => fechaExpiracion = value; }

        public bool createBaneado()
        {
            //return new CADBaneado().createBaneado(this);
            return false;
        }
        public bool readBaneado()
        {
            // return new CADBaneado().readBaneado(this);
            return false;
        }
        public bool updateBaneado()
        {
            // return new CADBaneado().updateBaneado(this);
            return false;
        }
        public bool deleteBaneado()
        {
            return false;
            // return new CADBaneado().deleteBaneado(this);
        }
    }
}