using System;
using System.Web;

using Umbraco.Core;
using Umbraco.Web.PublishedContentModels;
using Umbraco.Web.Routing;

/// <summary>
/// Summary description for ContentPreparedEventes
/// </summary>
public class ContentPreparedEvents : ApplicationEventHandler
{
    protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
    {
        PublishedContentRequest.Prepared += PublishedContentRequestOnPrepared;
    }

    private void PublishedContentRequestOnPrepared(object sender, EventArgs eventArgs)
    {
        var request = sender as PublishedContentRequest;

        if (request == null || !request.HasPublishedContent)
            return;

        ChangeHomePageTemplate(request);
    }

    private static void ChangeHomePageTemplate(PublishedContentRequest request)
    {
        if (request.PublishedContent.DocumentTypeAlias == Home.ModelTypeAlias)
        {
            if (HttpContext.Current.Request.Browser.IsMobileDevice)
            {
                request.TrySetTemplate("HomeClean");
            }
           
        }
    }
}