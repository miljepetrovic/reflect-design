
using ReflectDesign.Site.Extensions;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace ReflectDesign.Site.Models.Generated;

public partial interface IFooter
{
    IReadOnlyList<FooterColumn> CastedColumns { get; }
    IReadOnlyList<SocialIcon> CastedSocialIcons { get; }
}

public partial class Footer : IFooter
{
    public IReadOnlyList<FooterColumn> CastedColumns
        => GetCastedColumns(this);
    public IReadOnlyList<SocialIcon> CastedSocialIcons
        => GetCastedSocialIcons(this);

    public static IReadOnlyList<FooterColumn> GetCastedColumns(IFooter that)
        => that.Columns.GetBlockListItems<FooterColumn>();
    public static IReadOnlyList<SocialIcon> GetCastedSocialIcons(IFooter that)
        => that.SocialIcons.GetBlockListItems<SocialIcon>();
}