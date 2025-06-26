using Microsoft.AspNetCore.Components.Web;
using ReflectDesign.Site.Models.Generated;
using ReflectDesign.Site.ViewModels.Blocks;
using ReflectDesign.Site.ViewModels.Shared;

namespace ReflectDesign.Site.ViewModels.Blocks;

public class AgreementDetailsViewModel : PageBlockViewModel
{
    public AgreementDetailsViewModel(AgreementDetails model)
    {
        ArgumentNullException.ThrowIfNull(nameof(model));

        Title = model.Title;
        Description = model.Description;
        CallToActionLink = LinkViewModel.Create(model.CallToActionLink);
        Image = ImageViewModel.Create(model.Image);
        Steps = model.CastedSteps
            .Select((step, index) => new AgreementStepViewModel((index + 1).ToString("D2"), step))
            .ToList();
    }

    public string? Title { get; private set; }
    public string? Description { get; private set; }
    public LinkViewModel? CallToActionLink { get; private set; }
    public ImageViewModel? Image { get; private set; }
    public IReadOnlyList<AgreementStepViewModel> Steps { get; private set; }
}

public class AgreementStepViewModel
{
    public AgreementStepViewModel(string index, AgreementStep model)
    {
        ArgumentNullException.ThrowIfNull(nameof(model));

        Index = index;
        Title = model.Title;
        Description = model.Description;
    }

    public string Index { get; private set; }
    public string? Title { get; private set; }
    public string? Description { get; }
}