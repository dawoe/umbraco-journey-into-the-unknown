using Umbraco.Core;

public class ResolverSetupEvents : ApplicationEventHandler
{
    protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
    {
       MobileDetectorResolver.Current = new MobileDetectorResolver();
       MobileDetectorResolver.Current.SetMobileDetector(new AspNetMobileDetector());
    }
}