using ReflectDesign.Site.Extensions;

namespace ReflectDesign.Site.Models.Generated;

public partial class OurValues : IBlock
{
  public IReadOnlyList<ValueItem> CastedValueItems
    => Items.GetBlockListItems<ValueItem>();
}
