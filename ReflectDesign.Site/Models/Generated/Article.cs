using System;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace ReflectDesign.Site.Models.Generated;

public partial class Article
{
    public IReadOnlyList<Category> CastedCategories
        => this.Value<IEnumerable<IPublishedContent>>("categories")?
               .Select(category => category.SafeCast<Category>())?
               .WhereNotNull()
               .ToList() ?? [];
}
