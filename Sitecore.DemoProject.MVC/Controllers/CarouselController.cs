using Sitecore.Data.Fields;
using Sitecore.DemoProject.MVC.Models;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.DemoProject.MVC.Controllers
{
    public class CarouselController : Controller
    {
        public ActionResult Index()
        {
            var model = new CarouselModel();
            List<Slide> slides = new List<Slide>();
            var dataSource = RenderingContext.Current?.Rendering.Item;
            if(dataSource == null) { return View(); }

            model.Previous = new MvcHtmlString(FieldRenderer.Render(
                                    dataSource.Fields["Previous"].Item, "Previous"));
            model.Next = new MvcHtmlString(FieldRenderer.Render(
                                   dataSource.Fields["Next"].Item, "Next"));


            MultilistField slidesField = dataSource.Fields["Slides"];

            if (slidesField?.Count > 0)
            {
                var slideItems = slidesField.GetItems();
                foreach (var slideItem in slideItems)
                {
                    var title = new MvcHtmlString(FieldRenderer.Render(
                            slideItem, "Title"));

                    var subTitle = new MvcHtmlString(FieldRenderer.Render(
                        slideItem, "sub_Title"));

                    var image = new MvcHtmlString(FieldRenderer.Render(
                        slideItem, "Image", "class=d-block w-100"));

                    var callToAction = new MvcHtmlString(FieldRenderer.Render(
                        slideItem, "Call_To_Action",
                        "class=btn animated fadeInUp"));

                    slides.Add(new Slide
                    {
                        Title = title,
                        SubTitle = subTitle,
                        Image = image,
                        CallToAction = callToAction
                    });
                }
                model.Slides = slides;
            }

            return View(model);
        }
    }
}