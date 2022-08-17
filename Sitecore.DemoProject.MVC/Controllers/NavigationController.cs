using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.DemoProject.MVC.Extensions;
using Sitecore.DemoProject.MVC.Models;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.DemoProject.MVC.Controllers
{
    public class NavigationController : Controller
    {
        // GET: Navigation
        public ActionResult Index()
        {
            var homeItem = Context.Site.HomeItem();
            var navigations = new List<Navigation> { BuildNavigation(homeItem) };

            foreach (Item childItem in homeItem.Children)
            {
                if (childItem.Fields.Any(c => c.Name == "Navigation_Title"))
                {
                    CheckboxField hideInNavigation = childItem.Fields["Hide_in_Navigation"];
                    if (!hideInNavigation.Checked)
                    {
                        navigations.Add(BuildNavigation(childItem));
                    }
                }
            }
            return View(new NavigationViewModel { Navigations = navigations });
        }

        private Navigation BuildNavigation(Item item) =>
            new Navigation
            {
                NavigationTitle = item.Fields["Navigation_Title"]?.Value,
                NavigationLink = item.Url(),
                ActiveClass = PageContext.Current.Item.ID == item.ID ? "active" : string.Empty
            };

    }
}