using ReflectDesign.Site.Extensions;
using ReflectDesign.Site.Factories;
using ReflectDesign.Site.Models.Generated;
using ReflectDesign.Site.ViewModels.Blocks;
using ReflectDesign.Site.ViewModels.Layout;

namespace ReflectDesign.Site.ViewModels.Pages;

public class StandardContentViewModel : PageViewModel
{
    private StandardContentViewModel(
        string title,
        HeaderViewModel header,
        FooterViewModel footer,
        HeroBannerViewModel heroBanner,
        IEnumerable<PageBlockViewModel> blocks
    )
    {
        Title = title;
        Header = header;
        Footer = footer;
        HeroBanner = heroBanner;
        Blocks = blocks.ToList();
    }

    public IReadOnlyList<PageBlockViewModel> Blocks { get; private set; } = [];
    public HeroBannerViewModel HeroBanner { get; private set; }

    public static StandardContentViewModel Create(Home? home, StandardContent? standardContent)
    {
        ArgumentNullException.ThrowIfNull(home, nameof(home));
        ArgumentNullException.ThrowIfNull(standardContent, nameof(standardContent));

        var header = HeaderViewModel.Create(home);
        var footer = FooterViewModel.Create(home);
        var blocks = PageBlocksViewModelFactory.Create(standardContent.CastedBlocks);
        var heroBanner = HeroBannerViewModel.Create(standardContent.CastedHeroBanner);

        return new StandardContentViewModel(
            standardContent.GetPageTitle(),
            header,
            footer,
            heroBanner,
            blocks
        );
    }
}
