using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamHadaLib
{
    public class ENFaq
    {
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
        public int Codigo { get; set; }

        public DataSet obtenerFaq()
        {
            CADFaq faq = new CADFaq();
            return faq.obtenerFaq();
        }

        public bool updateFaq()
        {
            CADFaq faq = new CADFaq();
            return faq.updateFaq(this);
        }
        public bool deleteFaq()
        {
            CADFaq faq = new CADFaq();
            return faq.deleteFaq(this);
        }
        public bool insertFaq()
        {
            CADFaq faq = new CADFaq();
            return faq.insertFaq(this);
        }
    }
}
