using ReflectDesign.Site.Extensions;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace ReflectDesign.Site.Models.Generated;

public partial class Cards : IBlock
{
    public IReadOnlyList<CardItem> CastedItems
        => Items.GetBlockListItems<CardItem>();
}
