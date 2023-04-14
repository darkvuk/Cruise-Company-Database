using Kruzer.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kruzer.Services.Interfaces
{
    public interface IKartaService
    {
        List<KartaModel> GetKarta();
        List<KartaModel> GetFullKartaDetails();

        KartaModel GetKartaByID(int kartaID);

        bool InsertKarta(KartaModel karta);

        bool DeleteKarta(int kartaID);

        bool UpdateKarta(KartaModel karta);

    }
}