using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using ReflectDesign.Site.Models.Generated;
using ReflectDesign.Site.ViewModels.Pages;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace ReflectDesign.Site.Controllers.Pages;

public class HomeController : RenderController
{
    public HomeController(
        ILogger<RenderController> logger,
        ICompositeViewEngine compositeViewEngine,
        IUmbracoContextAccessor umbracoContextAccessor
    ) : base(logger, compositeViewEngine, umbracoContextAccessor)
    {
    }

    public override IActionResult Index()
    {
        ArgumentNullException.ThrowIfNull(CurrentPage);

        var page = CurrentPage.SafeCast<Home>();
        var pageViewModel = HomeViewModel.Create(page);

        return CurrentTemplate(pageViewModel);
    }
}
