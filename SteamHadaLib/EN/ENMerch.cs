using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;


namespace SteamHadaLib
{
    public class ENMerch : ENProducto
    {
        private float peso;
        private float volumen;
        private string publicationData;
        //private ENProducto producto;

        public float pesoMerch
        {
            get => peso;
            set => peso = value;
        }

        public float volumenMerch
        {
            get => volumen;
            set => volumen = value;
        }

        public int codeMerch
        {
            get => code;
            set => code = value;
        }

        public string nameMerch
        {
            get => name;
            set => name = value;
        }

        public float pvpMerch {
            get => pvp;
            set => pvp = value;
        }

        public string imageMerch
        {
            get => image;
            set => image = value;
        }

        public string descriptionMerch
        {
            get => description;
            set => description = value;
        }

        public string dataMerch
        {
            get => publicationData;
            set => publicationData = value;
        }

        /*public ENProducto productoMerch
        {
            get => producto;
            set => producto = value;
        }*/

        public ENMerch() { }

        public ENMerch(string n)
        {
            nameMerch = n;
        }

        public ENMerch(float p, float v, int c, string n, float pv, string i, string d, string pd /*ENProducto pr*/)
        {
            pesoMerch = p;
            volumenMerch = v;
            codeMerch = c;
            nameMerch = n;
            pvpMerch = pv;
            imageMerch = i;
            descriptionMerch = d;
            dataMerch = pd;
        }

        public bool insertMerch(){
            CADMerch merch = new CADMerch();
            return merch.insertMerch(this);
        }

        public bool deleteMerch(){
            CADMerch merch = new CADMerch();
            return merch.deleteMerch(this);
        }

        public bool modifyMerch(){
            CADMerch merch = new CADMerch();
            return merch.modifyMerch(this);
        }

        public bool readMerchFilter(){
            CADMerch merch = new CADMerch();
            return merch.readMerchFilter(this);
        }

       public ENMerch[] read5merch()
       {
            CADMerch merch = new CADMerch();
            return merch.read5merch(this);
       }

    }
}