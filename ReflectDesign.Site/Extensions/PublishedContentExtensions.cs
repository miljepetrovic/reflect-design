using ReflectDesign.Site.Models;
using ReflectDesign.Site.Models.Generated;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace ReflectDesign.Site.Extensions;

public static class PublishedContentExtensions
{
    public static string GetPageTitle(this IPublishedContent source)
        => source.Name;

    public static Image? GetImage(this MediaWithCrops source)
        => source?.Content.SafeCast<Image>();

    public static IReadOnlyList<T> GetBlockListItems<T>(this BlockListModel? source) where T : class
        => source?
            .Select(module => module.Content.SafeCast<T>())
            .Where(module => module is not null)
            .ToList() ?? [];

    public static IReadOnlyList<PageBlock> GetPageBlockListItems(this BlockListModel? source)
    {
        var blocks = new List<PageBlock>();
        foreach (var item in source)
        {
            var block = item.Content.SafeCast<IBlock>();
            if (block is null)
            {
                continue;
            }
            var pageBlock = new PageBlock()
            {
                Block = block,
                BackgroundColor = item.Settings.SafeCast<BlockBackgroundSettings>()?.BackgroundColor
            };
            blocks.Add(pageBlock);
        }

        return blocks;
    }

    public static T? GetBlockListSingleItem<T>(this BlockListModel source) where T : class
     => source?.FirstOrDefault()?.Content?.SafeCast<T>();
}
