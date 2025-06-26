using ReflectDesign.Site.Extensions;

namespace ReflectDesign.Site.Models.Generated;

public partial class Faq : IBlock
{
    public IReadOnlyList<FaqItem> CastedFaqs
        => Items.GetBlockListItems<FaqItem>();
}