using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruzer.Repository.Models.DB
{
    public class ZaposleniModel
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime Datum_rodjenja { get; set; }
        public int Godine_staza { get; set; }
        public int Duzina_ugovora { get; set; }
        public string Pozicija { get; set; }
        public string Pol { get; set; }
        public string Drzava { get; set; }
        public string Kruzer { get; set; }
        public int Plata { get; set; }


    }
}
