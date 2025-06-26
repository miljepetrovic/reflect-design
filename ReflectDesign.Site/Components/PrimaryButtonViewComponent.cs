using Microsoft.AspNetCore.Mvc;
using ReflectDesign.Site.ViewModels.Shared;

namespace ReflectDesign.Site.Components;

public class PrimaryButtonViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(LinkViewModel link) => View(link);
}
