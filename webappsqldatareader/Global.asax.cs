using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace webappsqldatareader
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // Add Routes.
            RegisterCustomRoutes(RouteTable.Routes);
        }

        void RegisterCustomRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(
                "SqlDataReaderNextResult",
                "SqlDataReaderNext",
                "~/Sqldatareader.aspx"
            );

            routes.MapPageRoute(
                "SqlDataAdapter",
                "SqlDataAdapter",
                "~/Sqldatadapter.aspx"
            );
            routes.MapPageRoute(
                "SqlDataSet",
                "SqlDataSet",
                "~/Sqldataset.aspx"
            );
            routes.MapPageRoute(
                "SqlCachedDataSet",
                "SqlCachedDataSet",
                "~/Sqlcachedataset.aspx"
            );
            routes.MapPageRoute(
                "SqlCommandBuilder",
                "SqlCommandBuilder",
                "~/Sqlcommandbuilder.aspx"
            );
            routes.MapPageRoute(
                "DisconnectedDataAccess",
                "DisconnectedDataAccess",
                "~/Disconnecteddataaccess.aspx"
            );
        }
    }
}