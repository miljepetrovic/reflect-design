using System;
using ReflectDesign.Site.Extensions;

namespace ReflectDesign.Site.Models.Generated;

public partial class StandardContent
{
    public IReadOnlyList<PageBlock> CastedBlocks
        => Blocks.GetPageBlockListItems();

    public HeroBanner CastedHeroBanner
        => HeroBanner.GetBlockListSingleItem<HeroBanner>();
}
