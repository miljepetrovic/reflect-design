using System;
using ReflectDesign.Site.Models.Generated;
using ReflectDesign.Site.Services.Interfaces;
using ReflectDesign.Site.ViewModels.Items;
using Umbraco.Cms.Core.Web;

namespace ReflectDesign.Site.Services;

public sealed class ArticleService : IArticlesService
{
    private readonly IUmbracoContextAccessor _umbracoContextAccessor;

    public ArticleService(IUmbracoContextAccessor umbracoContextAccessor)
    {
        _umbracoContextAccessor = umbracoContextAccessor;
    }

    public IReadOnlyList<Article> GetArticlesByCategory(string? category)
    {
        if (!_umbracoContextAccessor.TryGetUmbracoContext(out IUmbracoContext? context))
        {
            throw new Exception("Missing Umbraco context");
        }

        if (context.Content is null)
        {
            throw new Exception("Content Cache is null");
        }

        var articlesListing = (context.Content
                                .GetAtRoot()
                                .FirstOrDefault()?
                                .FirstChild<ArticlesListing>()) ??
            throw new Exception($"Could not find {nameof(ArticlesListing)} page.");

        var articles = articlesListing.Children<Article>();

        if (articles is null)
        {
            return [];
        }

        if (string.IsNullOrWhiteSpace(category))
        {
            return articles.ToList();
        }

        articles = articles.Where(article => article.CastedCategories.Select(articleCategory => articleCategory.Name).Contains(category));

        return articles.ToList();
    }
}
