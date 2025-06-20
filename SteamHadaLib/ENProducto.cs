using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamHadaLib
{
    public class ENProducto
    {
        protected int code;
        protected string name;
        protected float pvp;
        protected string image;
        protected string description;
        protected string publicationData;
        protected bool avaliable;
        protected string usuario;

        public int Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public float Pvp { get => pvp; set => pvp = value; }
        public string Image { get => image; set => image = value; }
        public string Description { get => description; set => description = value; }
        public bool Avaliable { get => avaliable; set => avaliable = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public ENProducto() { }
        public  ENProducto(ENProducto en)
        {
            Code = en.Code;
            Name = en.Name;
            Pvp = en.Pvp;
            Image = en.Image;
            Description = en.Description;
            Avaliable = en.Avaliable;
            Usuario = en.usuario;
        }

        public string imageProd
        {
            get => image;
            set => image = value;
        }


        public bool avaliableProd
        {
            get => avaliable;
            set => avaliable = value;
        }
    }
}
