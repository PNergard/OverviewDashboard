using Nergard.Epi.Tools.OverviewDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nergard.Epi.Tools.OverviewDashboard.Core.Interfaces
{
    public interface IDashboardInformation
    {
        string Heading { get; }
        List<DashboardData> Data();
        string Badge { get; set; }
    }
}


