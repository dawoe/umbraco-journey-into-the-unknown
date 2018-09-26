using Umbraco.Core;
using Umbraco.Core.Strings;

public class VirtualRouteEvents : ApplicationEventHandler
{
   
    protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
    {
        UrlSegmentProviderResolver.Current.InsertTypeBefore<DefaultUrlSegmentProvider, OrderStatusUrlSegmentProvider>();
    }
}
