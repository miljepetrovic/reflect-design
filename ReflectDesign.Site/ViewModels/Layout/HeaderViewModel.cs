using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ReflectDesign.Site.Models.Generated;
using ReflectDesign.Site.ViewModels.Shared;

namespace ReflectDesign.Site.ViewModels.Layout;

public class HeaderViewModel
{
    private HeaderViewModel(
        ImageViewModel logo,
        IEnumerable<HeaderMenuItemViewModel> menuItems,
        LinkViewModel? contactButton
    )
    {
        Logo = logo;
        MenuItems = menuItems.ToList();
        ContactButton = contactButton;
    }
    public static HeaderViewModel Create(IHeader header)
    {
        ArgumentNullException.ThrowIfNull(header, nameof(header));

        var logo = ImageViewModel.Create(header.HeaderLogo);
        var menuItems = header.CastedMenuItems
            .Select(menuItem => new HeaderMenuItemViewModel(menuItem))
            .ToList();
        var contactButton = LinkViewModel.Create(header.ContactButton);

        return new HeaderViewModel(
            logo,
            menuItems,
            contactButton
        );
    }

    public ImageViewModel? Logo { get; private set; }
    public IReadOnlyList<HeaderMenuItemViewModel> MenuItems { get; private set; } = [];
    public LinkViewModel? ContactButton { get; private set; }
}

public class HeaderMenuItemViewModel
{
    public HeaderMenuItemViewModel(HeaderMenuItem model)
    {
        Link = LinkViewModel.Create(model.Link);
        SubLinks = model.Sublinks
            .Select(LinkViewModel.Create)
            .ToList();
    }

    public LinkViewModel? Link { get; private set; }
    public IReadOnlyList<LinkViewModel> SubLinks { get; private set; } = [];
}