using Asp.netGraphPOC.Models;
using graph_tutorial.Helpers;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace graph_tutorial.Controllers
{
    public class CalendarController : BaseController
    {
        // GET: Calendar
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var events = await GraphHelper.GetEventsAsync();

            // Change start and end dates from UTC to local time
            foreach (var ev in events)
            {
                ev.Start.DateTime = DateTime.Parse(ev.Start.DateTime).ToLocalTime().ToString();
                ev.Start.TimeZone = TimeZoneInfo.Local.Id;
                ev.End.DateTime = DateTime.Parse(ev.End.DateTime).ToLocalTime().ToString();
                ev.End.TimeZone = TimeZoneInfo.Local.Id;
            }
            return View(events);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> SubmitEvent(Event newEvent)
        {
            await GraphHelper.SubmitEvent(newEvent);

            return Redirect("/");
        }
    }
}