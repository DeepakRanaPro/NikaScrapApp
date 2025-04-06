using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikaScrapApp.Core.Interfaces
{
    public interface IDismantleService
    {
        ResponseData DismantleProduct(DismantleProduct dismantleProduct);
        ProcessRecponce ProcessDetails(int ProductId);
    }
}
