using System;
using Microsoft.AspNetCore.Mvc;
using ReflectDesign.Site.ViewModels.Layout;

namespace ReflectDesign.Site.Components;

public class HeaderViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(HeaderViewModel header) => View(header);
}
