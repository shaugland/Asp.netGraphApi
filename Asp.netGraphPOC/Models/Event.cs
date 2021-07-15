using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp.netGraphPOC.Models
{
    public class Event
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        // Dates are just going to be assumed in July at 12:00:00 for now
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Attendees { get; set; }
    }
}