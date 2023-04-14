using Kruzer.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kruzer.Services.Interfaces
{
    public interface ITipZaposlenogService
    {
        List<TipZaposlenogModel> GetTipZaposlenog();

    }
}