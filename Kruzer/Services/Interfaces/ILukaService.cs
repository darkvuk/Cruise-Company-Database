using Kruzer.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kruzer.Services.Interfaces
{
    public interface ILukaService
    {
        List<LukaModel> GetLuka();

        LukaModel GetLukaByID(String lukaID);

        bool DeleteLuka(string lukaID);
        bool InsertLuka(LukaModel luka);

        bool UpdateLuka(LukaModel karta);



    }
}