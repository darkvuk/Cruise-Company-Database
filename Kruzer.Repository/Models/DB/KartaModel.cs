using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruzer.Repository.Models.DB
{
    public class KartaModel
    {
        public int Broj { get; set; }
        public int Cijena { get; set; }
        public int ID_Krstarenja { get; set; }
        public int ID_Putnika { get; set; }
        public string Ime_putnika { get; set; }
        public string Prezime_putnika { get; set; }
        public string IMO_Broj { get; set; }
        public string Ime_kruzera { get; set; }
        public int ID_Kabine { get; set; }

        //public Boolean cr { get; set; }

        

    }
}
