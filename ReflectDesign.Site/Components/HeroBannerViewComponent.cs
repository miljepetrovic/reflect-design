using Microsoft.AspNetCore.Mvc;
using ReflectDesign.Site.ViewModels.Blocks;

namespace ReflectDesign.Site.Components;

public class HeroBannerViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(HeroBannerViewModel heroBanner) => View(heroBanner);
}
