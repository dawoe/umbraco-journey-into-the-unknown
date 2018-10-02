using System;
using System.Web.Routing;

using Umbraco.Core;
using Umbraco.Core.Strings;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using Umbraco.Web.PublishedContentModels;

public class VirtualRouteEvents : ApplicationEventHandler
{
   
    protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
    {
        UrlSegmentProviderResolver.Current.InsertTypeBefore<DefaultUrlSegmentProvider, OrderStatusUrlSegmentProvider>();
    }
    
    protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
    {
        RouteTable.Routes.MapUmbracoRoute(
            "order_status",
            "orderstatus/{orderId}",
            new { controller = "OrderStatus", action = "OrderStatus" },
            new OrderStatusRouteHandler());       
    }

    private  string GetRoutePathFromNodeUrl(string routePath)
    {
        Uri result;
        return Uri.TryCreate(routePath, UriKind.Absolute, out result)
                   ? result.LocalPath.TrimStart('/')
                   : routePath.TrimStart('/');
    }
}
