using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruzer.Repository.Models.DB
{
    public class PutnikModel
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("ime")]
        public string Ime { get; set; }
        [JsonProperty("prezime")]
        public string Prezime { get; set; }
        [JsonProperty("datum_rodjenja")]
        public DateTime Datum_rodjenja { get; set; }
        [JsonProperty("br_pasosa")]
        public string Br_pasosa { get; set; }
        [JsonProperty("drzava")]
        public string Drzava { get; set; }
        [JsonProperty("pol")]
        public string Pol { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }

        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", Ime, Prezime);
            }
        }
    }
}
