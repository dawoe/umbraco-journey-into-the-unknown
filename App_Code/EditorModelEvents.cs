using System.Linq;

using Umbraco.Core;
using Umbraco.Core.Models.Membership;
using Umbraco.Web;
using Umbraco.Web.Editors;
using Umbraco.Web.Models.ContentEditing;

public class EditorModelEvents : ApplicationEventHandler
{
    protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
    {       
        EditorModelEventManager.SendingContentModel += this.EditorModelEventManager_SendingContentModel;
    }

    private void EditorModelEventManager_SendingContentModel(System.Web.Http.Filters.HttpActionExecutedContext sender, EditorModelEventArgs<Umbraco.Web.Models.ContentEditing.ContentItemDisplay> e)
    {
        var contentItemDisplay = e.Model;           

        DisablePreview(contentItemDisplay);

        ChangeTabNames(contentItemDisplay);

        HideTabs(contentItemDisplay);
    }


    private void ChangeTabNames(ContentItemDisplay contentItemDisplay)
    {
        var doctypes = new[] { "products", "blog", "people" };

        if (doctypes.Contains(contentItemDisplay.ContentTypeAlias))
        {
            if (contentItemDisplay.Tabs.Any(x => x.Label == "Child items"))
            {
                contentItemDisplay.Tabs.First(x => x.Label == "Child items").Label = contentItemDisplay.ContentTypeName;
            }
        }
    }

    private void DisablePreview(ContentItemDisplay contentItemDisplay)
    {
        if (contentItemDisplay.ContentTypeAlias == "product")
        {
            contentItemDisplay.AllowPreview = false;
            contentItemDisplay.Urls = new string[0];
        }
    }

    private void HideTabs(ContentItemDisplay contentItemDisplay)
    {
        var usergroups = UmbracoContext.Current.Security.CurrentUser.Groups.ToList();

        if (usergroups.Exists(x => x.Name == "Writers"))
        {
            contentItemDisplay.Tabs = contentItemDisplay.Tabs.Where(x => x.Label != "Navigation & SEO");
        }
    }
}