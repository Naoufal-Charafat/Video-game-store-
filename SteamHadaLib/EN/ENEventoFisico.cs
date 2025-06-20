using library.CAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamHadaLib
{
    public class ENEventoFisico : ENEvento
    {
        private int afor;
        private int preci;
        private string empres;
        private string locali;
        private string provin;
        private string locl;
        private int tlf_emp;
        private string dir_emp;
        private string correo;
        private string dir;

        public string email
        {
            set { correo = value; }
            get => correo;
        }
        public string empresa
        {
            set { empres = value; }
            get => empres;
        }
        public string localidad
        {
            set { locali = value; }
            get => locali;
        }
        public string provincia
        {
            set { provin = value; }
            get => provin;
        }
        public string local
        {
            set { locl = value; }
            get => locl;
        }
        public int telefono_empresa
        {
            set { tlf_emp = value; }
            get => tlf_emp;
        }
        public string direccion_empresa
        {
            set { dir_emp = value; }
            get => dir_emp;
        }
        public string direccion
        {
            set { dir= value; }
            get => dir;
        }
        public int aforo
        {
            set { afor = value; }
            get => afor;
        }
        public int precio
        {
            set { preci = value; }
            get => preci;
        }

        public ENEventoFisico()
        {
        }

        public ENEventoFisico(string empresa, string localidad, string provincia, int telefono_empresa, int precio)
        {
            this.empresa = empresa;
            this.localidad = localidad;
            this.provincia = provincia;
            this.telefono_empresa = telefono_empresa;
            this.precio = precio;
        }

        public new bool readEvents()
        {
            CADEvento c = new CADEvento();

            if (c.readEvents(this) == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public new bool createEvents()
        {
            bool crear;
            CADEvento c = new CADEvento();
            crear = c.createEvents(this);

            if (crear == true)
            {
                return true;
            }
            else
                return false;
        }
    }
}