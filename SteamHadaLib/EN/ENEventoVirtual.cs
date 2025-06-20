using library.CAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamHadaLib
{
    public class ENEventoVirtual : ENEvento
    {
        private string dir;
        private string main;
        private string game;

        public string juego
        {
            set { game = value; }
            get => game;
        }

        public string url
        {
            set { dir = value; }
            get => dir;
        }
        public string autor
        {
            set { main = value; }
            get => main;
        }
        public ENEventoVirtual()
        {

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

        public bool showMessages()
        {
            bool crear;
            CADEventoVirtual c = new CADEventoVirtual();
            crear = c.showMessages(this);

            if (crear == true)
            {
                return true;
            }
            else
                return false;
        }

        public bool sendMessage()
        {
            bool crear;
            CADEventoVirtual c = new CADEventoVirtual();
            crear = c.sendMessage(this);

            if (crear == true)
            {
                return true;
            }
            else
                return false;

        }

        public bool rateStream()
        {
            bool crear;
            CADEventoVirtual c = new CADEventoVirtual();
            crear = c.rateStream(this);

            if (crear == true)
            {
                return true;
            }
            else
                return false;

        }

        public bool sendGift()
        {
            bool crear;
            CADEventoVirtual c = new CADEventoVirtual();
            crear = c.sendGift(this);

            if (crear == true)
            {
                return true;
            }
            else
                return false;

        }
        public DataSet readVideos()
        {
            return new CADEvento().readVideos(this);
        }

    }
}