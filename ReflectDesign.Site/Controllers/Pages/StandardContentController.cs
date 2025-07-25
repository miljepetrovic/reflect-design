using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using ReflectDesign.Site.Models.Generated;
using ReflectDesign.Site.ViewModels.Pages;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace ReflectDesign.Site.Controllers.Pages;

public class StandardContentController : RenderController
{
    public StandardContentController(
        ILogger<RenderController> logger,
        ICompositeViewEngine compositeViewEngine,
        IUmbracoContextAccessor umbracoContextAccessor
    ) : base(logger, compositeViewEngine, umbracoContextAccessor)
    {
    }

    public override IActionResult Index()
    {
        ArgumentNullException.ThrowIfNull(CurrentPage);

        var page = CurrentPage.SafeCast<StandardContent>();
        var home = CurrentPage.Root<Home>();
        var pageViewModel = StandardContentViewModel.Create(home, page);

        return CurrentTemplate(pageViewModel);
    }
}
