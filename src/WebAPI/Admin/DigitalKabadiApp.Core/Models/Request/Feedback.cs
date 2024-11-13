using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Core.Models.Request
{
    public class Feedback
    {
        public int Id { get; set; }

        public int PickupId { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CreatedOn { get; set; } = string.Empty;
    }


    public class Feedbacks
    {
        public string RatingFrom { get; set; }
        public string RatingTo { get; set; }
        public string CreatedFrom { get; set; }
        public string CreatedTo { get; set; }
        public int UserId { get; set; }
    }

}