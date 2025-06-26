using System;
using ReflectDesign.Site.Models.Generated;
using ReflectDesign.Site.ViewModels.Blocks;
using ReflectDesign.Site.ViewModels.Shared;

namespace ReflectDesign.Site.ViewModels.Blocks;

public class ImageSlidesViewModel : PageBlockViewModel
{
    public ImageSlidesViewModel(ImageSlides model)
    {
        ArgumentNullException.ThrowIfNull(nameof(model));

        Slides = model.CastedImageSlides
            .Select(image => new ImageSlideItemViewModel(image))
            .ToList();
    }

    public List<ImageSlideItemViewModel> Slides { get; private set; }
}

public class ImageSlideItemViewModel
{
    public ImageSlideItemViewModel(ImageSlideItem model)
    {
        ArgumentNullException.ThrowIfNull(nameof(model));

        Title = model.Title;
        Description = model.Description;
        BackgroundImage = ImageViewModel.Create(model.BackgroundImage);
        CallToActionLink = LinkViewModel.Create(model.CallToActionLink);

    }

    public string? Title { get; private set; }
    public string? Description { get; private set; }
    public ImageViewModel? BackgroundImage { get; private set; }
    public LinkViewModel? CallToActionLink { get; private set; }
}
