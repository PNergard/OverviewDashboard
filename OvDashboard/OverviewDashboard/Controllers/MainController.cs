using Nergard.Epi.Tools.OverviewDashboard.Core.Interfaces;
using Nergard.Epi.Tools.OverviewDashboard.Models;
using Nergard.Epi.Tools.OverviewDashboard.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Nergard.Epi.Tools.OverviewDashboard.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        [Authorize(Roles = "WebAdmins")]
        public ActionResult Index()
        {
            var model = new MainViewModel();
            GetData(model);
            return View("~/OverviewDashboard/Views/Main/Index.cshtml",model);
        }

        private void GetData(MainViewModel viewModel)
        {
            List<string> results = new List<string>();

            var type = typeof(IDashboardInformation);

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.GetConstructor(Type.EmptyTypes) != null);

            var instances = from t in types
                            select Activator.CreateInstance(t) as IDashboardInformation;

            foreach (var instance in instances)
            {
                var pin = new DashboardPin
                {
                    Heading = instance.Heading,
                    Data = instance.Data(),
                    Badge = instance.Badge
                };

                viewModel.MenuPins.Add(pin);
            }

            viewModel.MenuPins = viewModel.MenuPins.OrderBy(p => p.Heading).ToList();
        }
    }
}