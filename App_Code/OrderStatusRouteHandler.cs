using System.Web.Routing;

using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using Umbraco.Web.PublishedContentModels;
using Umbraco.Web.Routing;

public class OrderStatusRouteHandler : UmbracoVirtualNodeRouteHandler
{
    protected override IPublishedContent FindContent(RequestContext requestContext, UmbracoContext umbracoContext)
    {
        var orderPage = umbracoContext.ContentCache.GetSingleByXPath(string.Format("//{0}[@isDoc]", OrderStatus.ModelTypeAlias)).OfType<OrderStatus>();

        if (orderPage != null)
        {
            orderPage.OrderId = requestContext.RouteData.Values["orderId"].ToString();
        }

        return orderPage;
    }   
}