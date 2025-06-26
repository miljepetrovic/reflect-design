
using ReflectDesign.Site.Extensions;

namespace ReflectDesign.Site.Models.Generated;

public partial class Testimonials : IBlock
{
    public IReadOnlyList<TestimonialItem> CastedItems
        => Items.GetBlockListItems<TestimonialItem>();
}
