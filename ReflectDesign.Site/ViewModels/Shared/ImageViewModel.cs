using ReflectDesign.Site.Models.Generated;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace ReflectDesign.Site.ViewModels.Shared;

public class ImageViewModel
{
    private ImageViewModel(Image image)
    {
        Url = image.Url(mode: UrlMode.Absolute);
        AlternateText = image.AlternateText;
    }

    public static ImageViewModel? Create(MediaWithCrops? media)
    {
        if (media is null)
        {
            return null;
        }
        var image = media.Content.SafeCast<Image>();

        if (image is null || string.IsNullOrWhiteSpace(image.Url(mode: UrlMode.Absolute)))
        {
            return null;
        }

        return new(image);
    }

    public string Url { get; private set; }
    public string? AlternateText { get; private set; }
}
