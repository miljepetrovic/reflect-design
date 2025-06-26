using System;
using ReflectDesign.Site.Models.Generated;
using ReflectDesign.Site.ViewModels.Shared;

namespace ReflectDesign.Site.ViewModels.Blocks;

public class HeroBannerViewModel
{
    private HeroBannerViewModel(
        string title,
        string description,
        ImageViewModel backgroundImage,
        LinkViewModel primaryCallToActionLink,
        LinkViewModel secondaryCallToActionLink
    )
    {

        Title = title;
        Description = description;
        BackgroundImage = backgroundImage;
        PrimaryCallToActionLink = primaryCallToActionLink;
        SecondaryCallToActionLink = secondaryCallToActionLink;
    }

    public static HeroBannerViewModel? Create(HeroBanner banner)
    {
        if (banner is null)
        {
            return default;
        }

        var backgroundImage = ImageViewModel.Create(banner.BackgroundImage);
        var primaryCallToActionLink = LinkViewModel.Create(banner.PrimaryCallToActionLink);
        var secondaryCallToActionLink = LinkViewModel.Create(banner.SecondaryCallToActionLink);

        return new(
            banner.Title,
            banner.Description,
            backgroundImage,
            primaryCallToActionLink,
            secondaryCallToActionLink
        );
    }

    public string? Title { get; private set; }
    public string Description { get; private set; }
    public ImageViewModel BackgroundImage { get; private set; }
    public LinkViewModel PrimaryCallToActionLink { get; private set; }
    public LinkViewModel SecondaryCallToActionLink { get; private set; }
}
