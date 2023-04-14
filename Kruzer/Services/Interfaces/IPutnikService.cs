using Kruzer.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kruzer.Services.Interfaces
{
    public interface IPutnikService
    {
        List<PutnikModel> GetPutnik();

        PutnikModel GetPutnikByID(int putnikID);

        bool DeletePutnik(int putnikID);
        bool InsertPutnik(PutnikModel putnik);
        bool UpdatePutnik(PutnikModel putnik);



    }
}