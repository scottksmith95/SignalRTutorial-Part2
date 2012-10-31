using SignalR;
using SignalRTutorial.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalRTutorial.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public void Notify()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<TagHub>();
            context.Clients.addTag("notify called");
        }
    }
}
