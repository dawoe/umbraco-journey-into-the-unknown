using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

using Umbraco.Core.Models;
using Umbraco.Core.Strings;
using Umbraco.Web.PublishedContentModels;

using IContentBase = Umbraco.Core.Models.IContentBase;

/// <summary>
/// Summary description for OrderStatusUrlSegmentProvider
/// </summary>
public class OrderStatusUrlSegmentProvider : IUrlSegmentProvider
{
    /// <summary>Gets the default url segment for a specified content.</summary>
    /// <param name="content">The content.</param>
    /// <returns>The url segment.</returns>
    public string GetUrlSegment(IContentBase content)
    {
        if (content.GetContentType().Alias == OrderStatus.ModelTypeAlias)
        {
            return "orderstatus";
        }

        return null;
    }

    /// <summary>
    /// Gets the url segment for a specified content and culture.
    /// </summary>
    /// <param name="content">The content.</param>
    /// <param name="culture">The culture.</param>
    /// <returns>The url segment.</returns>
    /// <remarks>This is for when Umbraco is capable of managing more than one url
    /// per content, in 1-to-1 multilingual configurations. Then there would be one
    /// url per culture.</remarks>
    public string GetUrlSegment(IContentBase content, CultureInfo culture)
    {
        return GetUrlSegment(content);
    }
}