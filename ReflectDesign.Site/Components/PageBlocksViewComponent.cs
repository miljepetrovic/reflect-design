using Microsoft.AspNetCore.Mvc;
using ReflectDesign.Site.ViewModels.Blocks;

namespace ReflectDesign.Site.Components;

public class PageBlocksViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(PageBlockViewModel module)
    {
        return View(module.GetType().Name.Replace("ViewModel", ""), module);
    }
}
