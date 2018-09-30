using System.Linq;

using log4net.Util;

using Umbraco.Core;
using Umbraco.Core.Models.Membership;
using Umbraco.Web;
using Umbraco.Web.Editors;
using Umbraco.Web.Models.ContentEditing;
using Umbraco.Web.PublishedContentModels;

public class EditorModelEvents : ApplicationEventHandler
{
    protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
    {       
        EditorModelEventManager.SendingContentModel += this.EditorModelEventManager_SendingContentModel;
    }

    private void EditorModelEventManager_SendingContentModel(System.Web.Http.Filters.HttpActionExecutedContext sender, EditorModelEventArgs<Umbraco.Web.Models.ContentEditing.ContentItemDisplay> e)
    {
        var contentItemDisplay = e.Model;
        var context = e.UmbracoContext;

        //DisablePreview(contentItemDisplay);

        //ChangeTabNames(contentItemDisplay);

        //HideTabs(contentItemDisplay, context);

        //HideProperties(contentItemDisplay, context);

        //MakePropertiesReadOnly(contentItemDisplay, context);

        //SetDefaultPrice(contentItemDisplay);
    }

    private void ChangeTabNames(ContentItemDisplay contentItemDisplay)
    {
        var doctypes = new[] { Products.ModelTypeAlias,  Blog.ModelTypeAlias, People.ModelTypeAlias };

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
        if (contentItemDisplay.ContentTypeAlias == Product.ModelTypeAlias)
        {
            contentItemDisplay.AllowPreview = false;
            contentItemDisplay.Urls = new string[0];
        }
    }

    private void HideTabs(ContentItemDisplay contentItemDisplay, UmbracoContext context)
    {
        var usergroups = context.Security.CurrentUser.Groups.ToList();

        if (usergroups.Exists(x => x.Alias == "admin") == false && contentItemDisplay.ContentTypeAlias == Home.ModelTypeAlias)
        {
            contentItemDisplay.Tabs = contentItemDisplay.Tabs.Where(x => x.Label != "Maintenance Mode");
        }       
    }

    private void HideProperties(ContentItemDisplay contentItemDisplay, UmbracoContext context)
    {
        var usergroups = context.Security.CurrentUser.Groups.ToList();

        if (contentItemDisplay.ContentTypeAlias == Products.ModelTypeAlias && !usergroups.Exists(x => x.Alias == "admin"))
        {
            var shopTab = contentItemDisplay.Tabs.FirstOrDefault(x => x.Label == "Shop");

            if (shopTab != null)
            {
                shopTab.Properties = shopTab.Properties.Where(x => x.Alias != "defaultCurrency");

                contentItemDisplay.Tabs.First(x => x.Label == "Shop").Properties = shopTab.Properties;
            }
            
        }
    }

    private void MakePropertiesReadOnly(ContentItemDisplay contentItemDisplay, UmbracoContext context)
    {
        var usergroups = context.Security.CurrentUser.Groups.ToList();

        if (contentItemDisplay.ContentTypeAlias == Products.ModelTypeAlias && !usergroups.Exists(x => x.Alias == "admin"))
        {
            var shopTab = contentItemDisplay.Tabs.FirstOrDefault(x => x.Label == "Shop");

            if (shopTab != null)
            {
               shopTab.Properties.First(x => x.Alias == "defaultCurrency").View = "readonlyvalue";                
            }

        }
    }

    private void SetDefaultPrice(ContentItemDisplay contentItemDisplay)
    {
        if (contentItemDisplay.ContentTypeAlias == Product.ModelTypeAlias)
        {
            var priceProperty = contentItemDisplay.Properties.FirstOrDefault(f => f.Alias == "price");
            if (priceProperty != null && (priceProperty.Value == null || string.IsNullOrEmpty(priceProperty.Value.ToString())))
            {
                // set default value if the price property is null or empty
                priceProperty.Value = 100;
            }
        }
    }
}