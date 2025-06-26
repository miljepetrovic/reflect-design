using System;
using ReflectDesign.Site.Models.Generated;
using ReflectDesign.Site.ViewModels.Blocks;

namespace ReflectDesign.Site.ViewModels.Blocks;

public class OurValuesViewModel : PageBlockViewModel
{
    public OurValuesViewModel(OurValues model)
    {
        ArgumentNullException.ThrowIfNull(nameof(model));

        Title = model.Title;
        Description = model.Description;
        Items = model.CastedValueItems
            .Select(valueItem => new ValueItemViewModel(valueItem))
            .ToList();
    }

    public string? Title { get; private set; }
    public string? Description { get; private set; }
    public IReadOnlyList<ValueItemViewModel> Items { get; }
}

public class ValueItemViewModel
{
    public ValueItemViewModel(ValueItem model)
    {
        ArgumentNullException.ThrowIfNull(nameof(model));

        Icon = model.Icon;
        Title = model.Title;
        Description = model.Description;
    }

    public string? Icon { get; private set; }
    public string? Title { get; private set; }
    public string? Description { get; private set; }
}
