using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Links.UrlBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Sitecore.Configuration.Settings;

namespace Sitecore.DemoProject.MVC.CustomCode
{

    public class CustomLinkProvider : ItemUrlBuilder
    {
        public CustomLinkProvider(DefaultItemUrlBuilderOptions defaultOptions) : base(defaultOptions)
        {
        }

        public override string Build(Item item, ItemUrlBuilderOptions options)
        {
            options.AlwaysIncludeServerUrl = true;
            options.SiteResolving = Rendering.SiteResolving;
            return base.Build(item, options);
        }
    }
}