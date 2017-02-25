using System.Collections.Generic;


namespace Nergard.Epi.Tools.OverviewDashboard.Models
{
    public class DashboardPin
    {
        public string ID { get; set; }
        public string Heading { get; set; }

        public string Badge { get; set; }
        public List<DashboardData> Data { get; set; }

        public DashboardPin()
        {
            ID = this.GetType().Name;
            Data = new List<DashboardData>();        
        }

    }
}