using ReflectDesign.Site.Extensions;

namespace ReflectDesign.Site.Models.Generated;

public partial class ImageSlides : IBlock
{
    public IReadOnlyList<ImageSlideItem> CastedImageSlides
        => Images.GetBlockListItems<ImageSlideItem>();
}