
using ReflectDesign.Site.Models.Generated;
using Umbraco.Cms.Core.Models;

namespace ReflectDesign.Site.ViewModels.Blocks;

public class TextViewModel : PageBlockViewModel
{
    public TextViewModel(Text model)
    {
        ArgumentNullException.ThrowIfNull(nameof(model));

        Content = model.Content?.ToHtmlString();
    }

    public string? Content { get; private set; }
}
