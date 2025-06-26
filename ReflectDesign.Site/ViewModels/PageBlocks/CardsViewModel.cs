using ReflectDesign.Site.Models.Generated;
using ReflectDesign.Site.ViewModels.Blocks;
using ReflectDesign.Site.ViewModels.Shared;

namespace ReflectDesign.Site.ViewModels.Blocks;

public class CardsViewModel : PageBlockViewModel
{
    public CardsViewModel(Cards model)
    {
        ArgumentNullException.ThrowIfNull(model, nameof(model));

        Title = model.Title;
        Description = model.Description;
        Items = model.CastedItems
            .Select(card => new CardItemViewModel(card))
            .ToList();
        FullImage = model.FullImage;
    }

    public string? Title { get; private set; }
    public string? Description { get; private set; }
    public IReadOnlyList<CardItemViewModel> Items { get; private set; } = [];
    public bool FullImage { get; private set; }
}

public class CardItemViewModel
{
    public CardItemViewModel(CardItem card)
    {
        Title = card.Title;
        Image = ImageViewModel.Create(card.Image);
        CallToActionLink = LinkViewModel.Create(card.CallToActionLink);
        Description = card.Description;
    }

    public string? Title { get; private set; }
    public ImageViewModel? Image { get; private set; }
    public LinkViewModel? CallToActionLink { get; private set; }
    public string? Description { get; private set; }
}