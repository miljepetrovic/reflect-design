using System;
using ReflectDesign.Site.Models.Generated;
using ReflectDesign.Site.ViewModels.Blocks;

namespace ReflectDesign.Site.ViewModels.Blocks;

public class FaqViewModel : PageBlockViewModel
{
    public FaqViewModel(Faq model)
    {
        ArgumentNullException.ThrowIfNull(nameof(model));

        Title = model.Title;
        Description = model.Description;
        Items = model.CastedFaqs
            .Select(item => new FaqItemViewModel(item))
            .ToList();
    }

    public string? Title { get; private set; }
    public string? Description { get; private set; }
    public IReadOnlyList<FaqItemViewModel> Items { get; private set; }
}

public class FaqItemViewModel
{
    public FaqItemViewModel(FaqItem model)
    {
        ArgumentNullException.ThrowIfNull(nameof(model));

        Title = model.Title;
        Answer = model.Answer;
    }

    public string? Title { get; private set; }
    public string? Answer { get; private set; }
}
