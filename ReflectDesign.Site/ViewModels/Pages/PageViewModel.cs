using ReflectDesign.Site.ViewModels.Layout;

namespace ReflectDesign.Site.ViewModels.Pages;

public class PageViewModel
{
    public string? Title { get; protected set; }
    public HeaderViewModel Header { get; protected set; }
    public FooterViewModel Footer { get; protected set; }
}
