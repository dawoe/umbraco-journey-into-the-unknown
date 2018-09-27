using System.Web.Mvc;

using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using Umbraco.Web.PublishedContentModels;

public class OrderStatusController : RenderMvcController
{
    public ActionResult OrderStatus(RenderModel model, string orderId)
    {
        var content = model.Content.OfType<OrderStatus>();

        content.OrderId = orderId;

        return this.View("OrderStatus", model: content);
    }
}