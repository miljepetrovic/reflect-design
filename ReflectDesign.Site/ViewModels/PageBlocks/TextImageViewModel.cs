using System;
using ReflectDesign.Site.Models.Generated;
using ReflectDesign.Site.ViewModels.Blocks;
using ReflectDesign.Site.ViewModels.Shared;

namespace ReflectDesign.Site.ViewModels.Blocks;

public class TextImageViewModel : PageBlockViewModel
{
    public TextImageViewModel(TextImage model)
    {
        ArgumentNullException.ThrowIfNull(nameof(model));
        Title = model.Title;
        Surtitle = model.Surtitle;
        Description = model.Description;
        Image = ImageViewModel.Create(model.Image);
        CallToActionLink = LinkViewModel.Create(model.CallToActionLink);
    }

    public string? Title { get; private set; }
    public string? Surtitle { get; private set; }
    public string? Description { get; private set; }

    public ImageViewModel? Image { get; private set; }
    public LinkViewModel? CallToActionLink { get; private set; }
}
