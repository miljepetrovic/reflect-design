using System;
using Microsoft.AspNetCore.Mvc;
using ReflectDesign.Site.Services.Interfaces;
using ReflectDesign.Site.ViewModels.Items;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Website.Controllers;

namespace ReflectDesign.Site.Controllers.Surface;

public class ArticlesSurfaceController : SurfaceController
{
    private readonly IArticlesService _articleService;

    public ArticlesSurfaceController(
        IUmbracoContextAccessor umbracoContextAccessor,
        IUmbracoDatabaseFactory databaseFactory,
        ServiceContext services, AppCaches appCaches,
        IProfilingLogger profilingLogger,
        IPublishedUrlProvider publishedUrlProvider,
        IArticlesService articlesService)
        : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
    {
        _articleService = articlesService;
    }

    [HttpGet]
    public IActionResult GetAll([FromQuery] string? category)
    {
        var articles = _articleService
            .GetArticlesByCategory(category)
            .Select(article => new ArticleItemViewModel()
            {
                Title = article.Name,
                Summary = article.PreviewText,
                Category = string.IsNullOrWhiteSpace(category) ?
                    article.CastedCategories.FirstOrDefault()?.Name :
                    article.CastedCategories.FirstOrDefault(c => c.Name.Equals(category))?.Name,
                Image = article.PreviewImage.Url(),
                Date = article.UpdateDate.ToString(),
                Id = article.Id,
                Link = article.Url(),
            })
            .ToList();

        return Json(articles);
    }
}