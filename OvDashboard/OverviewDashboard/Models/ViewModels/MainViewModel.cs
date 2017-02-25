using System.Collections.Generic;
using Nergard.Epi.Tools.OverviewDashboard.Models;

namespace Nergard.Epi.Tools.OverviewDashboard.Models.ViewModels
{
    public class MainViewModel
    {
        public List<DashboardPin> MenuPins { get; set; }

        public MainViewModel()
        {
            MenuPins = new List<DashboardPin>();
        }
    }
}