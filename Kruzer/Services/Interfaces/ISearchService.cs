using Kruzer.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kruzer.Services.Interfaces
{
    public interface ISearchService
    {

        List<LukaModel> GetLukaByCountry(LukaModel luka);
        List<PutnikModel> GetPutnikByCountry(PutnikModel putnik);
    }
}