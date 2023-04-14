using Kruzer.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kruzer.Services.Interfaces
{
    public interface IZaposleniService
    {
        List<ZaposleniModel> GetZaposleni();

        ZaposleniModel GetZaposleniByID(int zaposleniID);
        bool DeleteZaposleni(int zaposleniID);
        bool InsertZaposleni(ZaposleniModel zaposleni);
        bool UpdateZaposleni(ZaposleniModel zaposleni);

    }
}