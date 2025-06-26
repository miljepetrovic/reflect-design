using System;
using ReflectDesign.Site.Services.Interfaces;

namespace ReflectDesign.Site.Services;

public static class DependencyInjection
{
    public static IUmbracoBuilder AddContentServices(this IUmbracoBuilder builder)
    {
        _ = builder.Services
            .AddScoped<IArticlesService, ArticleService>();

        return builder;
    }
}
