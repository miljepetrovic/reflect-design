
using ReflectDesign.Site.Extensions;

namespace ReflectDesign.Site.Models.Generated;

public partial interface IHeader
{
    IReadOnlyList<HeaderMenuItem> CastedMenuItems { get; }
}

public partial class Header : IHeader
{
    public IReadOnlyList<HeaderMenuItem> CastedMenuItems
        => GetCastedMenuItems(this);
    public static IReadOnlyList<HeaderMenuItem> GetCastedMenuItems(IHeader that)
        => that.MenuItems.GetBlockListItems<HeaderMenuItem>();
}
