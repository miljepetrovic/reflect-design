using ReflectDesign.Site.Extensions;
using ReflectDesign.Site.Factories;
using ReflectDesign.Site.Models.Generated;
using ReflectDesign.Site.ViewModels.Blocks;
using ReflectDesign.Site.ViewModels.Layout;
using ReflectDesign.Site.ViewModels.Shared;

namespace ReflectDesign.Site.ViewModels.Pages;

public class HomeViewModel : PageViewModel
{
    private HomeViewModel(
        string title,
        HeaderViewModel header,
        FooterViewModel footer,
        HeroBannerViewModel heroBanner,
        IEnumerable<PageBlockViewModel> blocks,
        bool displaySplashScreen,
        ImageViewModel splashScreenImage
    )
    {
        Title = title;
        Header = header;
        Footer = footer;
        HeroBanner = heroBanner;
        Blocks = blocks.ToList();
        DisplaySplashScreen = displaySplashScreen;
        SplashScreenImage = splashScreenImage;
    }

    public IReadOnlyList<PageBlockViewModel> Blocks { get; private set; } = [];
    public HeroBannerViewModel HeroBanner { get; private set; }
    public bool DisplaySplashScreen { get; private set; }
    public ImageViewModel SplashScreenImage { get; private set; }

    public static HomeViewModel Create(Home? home)
    {
        ArgumentNullException.ThrowIfNull(home, nameof(home));

        var header = HeaderViewModel.Create(home);
        var footer = FooterViewModel.Create(home);
        var blocks = PageBlocksViewModelFactory.Create(home.CastedBlocks);
        var heroBanner = HeroBannerViewModel.Create(home.CastedHeroBanner);
        var splashScreenImage = ImageViewModel.Create(home.SplashScreenImage);

        return new HomeViewModel(
            home.GetPageTitle(),
            header,
            footer,
            heroBanner,
            blocks,
            home.DisplaySplashScreen,
            splashScreenImage
        );
    }
}