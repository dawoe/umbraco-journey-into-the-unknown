using System.Web.Mvc;

using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

public class OrderStatusController : RenderMvcController
{
    public ActionResult OrderStatus(RenderModel model, string orderId)
    {      
        return this.View("OrderStatus", model: model);
    }
}