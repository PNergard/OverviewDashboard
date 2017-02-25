using EPiServer.Security;
using EPiServer.Shell.Navigation;
using System.Collections.Generic;
using System.Web.Routing;

namespace Nergard.Epi.Tools.OverviewDashboard.Core.MenuProvider
{
    [MenuProvider]
    public class OverviewDashboardMenuProvider : IMenuProvider
    {
        public IEnumerable<MenuItem> GetMenuItems()
        {

            var mainAdminMenu = new SectionMenuItem("Overview dashboard", "/global/overviewdashboard");
            mainAdminMenu.IsAvailable = ((RequestContext request) => PrincipalInfo.HasAdminAccess); //(request) => PrincipalInfo.HasEditAccess;

            var firstMenuItem = new UrlMenuItem("Main", "/global/overviewdashboard/main", "/overviewdashboard/main");

            firstMenuItem.IsAvailable = ((RequestContext request) => true);
            firstMenuItem.SortIndex = 100;

            return new MenuItem[]
           {
                mainAdminMenu,
                firstMenuItem
            };
        }

        protected virtual UrlMenuItem CreateUrlMenuItem(string title, string logicalPath, string resourcePath)
        {
            var menuItem = new UrlMenuItem(title, 
                                          logicalPath, 
                                          resourcePath);
            menuItem.IsAvailable = ((RequestContext request) => true);
            return menuItem;
        }
    }
}