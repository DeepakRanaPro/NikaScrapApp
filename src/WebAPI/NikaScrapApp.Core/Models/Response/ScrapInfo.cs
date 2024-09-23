using NikaScrapApp.Core.Models.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikaScrapApp.Core.Models.Response
{
    public class ScrapInfoResponse : Response
    {
        public List<ScrapInfo> Data { get; set; } = new List<ScrapInfo>();

    }

    public class ScrapInfo
    {
        public int Id { get; set; }
        public int PickupCode { get; set; }
        public DateOnly PickUpDate { get; set; }
        public int UserI { get; set; }
        public int StatusId { get; set; }
        public int languageId { get; }



    }
}
