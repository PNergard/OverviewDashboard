using System.Collections.Generic;
using Nergard.Epi.Tools.OverviewDashboard.Models;
using Nergard.Epi.Tools.OverviewDashboard.Core.Interfaces;

namespace OverviewDashboard.Core.DashboardInformationImplementations
{
    public class GeneralExample : IDashboardInformation
    {
        public string Badge
        {
            get; set;
        }

        public string Heading
        {
            get
            {
                return "General example";
            }
        }

        public List<DashboardData> Data()
        {
            var retList = new List<DashboardData>();
            var dbData = new DashboardData
            {
                RenderType = RenderTypes.General,
                Data = new General { Heading = "This is a test", BodyText = "This is a test with alert warning!", AlertType = AlertTypes.Warning }
            };

            retList.Add(dbData);

            return retList;

        }
    }
}