using Nergard.Epi.Tools.OverviewDashboard.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nergard.Epi.Tools.OverviewDashboard.Models;
using System.Configuration;

namespace Nergard.Epi.Tools.OverviewDashboard.Core.ExampleImplemantation
{
    public class GeneralMixedExample : IDashboardInformation
    {
        public string Badge
        {
            get; set;
        }

        public string Heading
        {
            get
            {
                return "Mixed";
            }
        }

        public List<DashboardData> Data()
        {
            var retList = new List<DashboardData>();

            var dict = ConfigurationManager.AppSettings.AllKeys
                        .ToDictionary(k => k, v => ConfigurationManager.AppSettings[v]);
            var dbData = new DashboardData
            {
                RenderType = RenderTypes.Dictionary,
                Data = dict,

            };

            retList.Add(dbData);

            var dbData2 = new DashboardData
            {
                RenderType = RenderTypes.General,
                Data = new General { Heading = "This is a test", BodyText = "This is a test with no warning!", AlertType = AlertTypes.Vanilla }
            };

            retList.Add(dbData2);

            var dbData3 = new DashboardData
            {
                RenderType = RenderTypes.General,
                Data = new General { Heading = "Something is not quite right!", BodyText = "This is a test with danger warning!", AlertType = AlertTypes.Danger }
            };

            Badge = "!";

            retList.Add(dbData3);

            return retList;
        }
    }
}