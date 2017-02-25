using Nergard.Epi.Tools.OverviewDashboard.Core.Interfaces;
using Nergard.Epi.Tools.OverviewDashboard.Models;
using OverviewDashboard.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Nergard.Epi.Tools.OverviewDashboard.Core.ExampleImplemenation
{
    public class AppsettingsInformation : IDashboardInformation
    {

        public string Heading
        {
            get
            {
                return "AppSettings";
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

            return retList;
        }

        public string Badge { get; set; }

    }
}