using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace Sitecore.DemoProject.MVC.GlobalConfiguration
{
    public static class Labels
    {
        public static string NextText()
        {
            var label = Context.Database.GetItem(new ID("{D3A0A1B9-D8C4-45C4-9CC5-CC458AD0A16E}"));
            if (label != null) { return label["Name"]; }
            return "";
        }

        public static string PreviousText()
        {
            var label = Context.Database.GetItem(new ID("{0FF0FBC5-FAA2-4FE2-AE93-6437B6E221B7}"));
            if (label != null) { return label["Name"]; }
            return "";
        }
    }
}
