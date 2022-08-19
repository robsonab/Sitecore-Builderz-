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
    public class LandingPageController : Controller
    {
        private const string LandingPage = "Landing Page";
        // GET: LandingPage
        public ActionResult Index()
        {
            var homeItem = Context.Site.HomeItem();
            var navigations = new List<Navigation>();

            var children = homeItem.Children
                                    .Where(item => item.TemplateName == LandingPage)
                                    .Select(item => BuildNavigation(item));
            navigations.AddRange(children);

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