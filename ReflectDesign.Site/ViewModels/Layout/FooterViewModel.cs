using ReflectDesign.Site.Models.Generated;
using ReflectDesign.Site.ViewModels.Shared;

namespace ReflectDesign.Site.ViewModels.Layout;

public class FooterViewModel
{
    public static FooterViewModel Create(IFooter footer)
    {
        ArgumentNullException.ThrowIfNull(footer, nameof(footer));

        var logo = ImageViewModel.Create(footer.FooterLogo);
        var copyright = footer.CopyrightText.Replace(
            "{{godina}}",
            DateTime.UtcNow.Year.ToString(),
            StringComparison.OrdinalIgnoreCase
        );
        var bottomLinks = footer.BottomLinks?
            .Select(LinkViewModel.Create)
            .ToList()
                ?? [];
        var footerColumns = footer.CastedColumns?
            .Select(footerColumn => new FooterColumnViewModel(footerColumn))
            .ToList();
        var socialIcons = footer.CastedSocialIcons?
            .Select(socialIcon => new SocialIconViewModel(socialIcon))
            .ToList();

        return new()
        {
            Logo = logo,
            Description = footer.Description,
            Address = footer.Address,
            EmailAddress = footer.EmailAddress,
            PhoneNumber = footer.PhoneNumber,
            Copyright = copyright,
            BottomLinks = bottomLinks,
            Columns = footerColumns,
            SocialIcons = socialIcons
        };
    }

    public ImageViewModel? Logo { get; private set; }
    public string Description { get; private set; }
    public string EmailAddress { get; private set; }
    public string Address { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Copyright { get; private set; }
    public IReadOnlyList<LinkViewModel> BottomLinks { get; private set; } = [];
    public IReadOnlyCollection<FooterColumnViewModel> Columns { get; private set; } = [];
    public IReadOnlyCollection<SocialIconViewModel> SocialIcons { get; private set; } = [];

}

public class FooterColumnViewModel
{
    public FooterColumnViewModel(FooterColumn column)
    {
        Title = column.Title;
        Links = column.Links?.Select(LinkViewModel.Create).ToList() ?? [];
    }

    public string Title { get; private set; }
    public IReadOnlyList<LinkViewModel> Links { get; private set; }
}

public class SocialIconViewModel
{
    public SocialIconViewModel(SocialIcon model)
    {
        Icon = model.Icon;
        Link = model.Link;
    }

    public string Icon { get; private set; }
    public string Link { get; private set; }
}
