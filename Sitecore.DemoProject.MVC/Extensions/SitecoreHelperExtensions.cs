using Sitecore.Data;
using Sitecore.Mvc.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.DemoProject.MVC.Extensions
{
    public static class SitecoreHelperExtensions
    {
        public static HtmlString Field(this SitecoreHelper helper, ID fieldId)
        {
            return helper.Field(fieldId.ToString());
        }
        public static HtmlString Field(this SitecoreHelper helper, ID fieldId, object parameters)
        {
            return helper.Field(fieldId.ToString(), parameters);
        }

        
    }

    
}