using Microsoft.AspNetCore.Mvc;
using ReflectDesign.Site.ViewModels.Layout;

namespace ReflectDesign.Site.Components;

public class FooterViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(FooterViewModel footer) => View(footer);
}
