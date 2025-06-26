using System;
using ReflectDesign.Site.Models.Generated;
using ReflectDesign.Site.ViewModels.Items;

namespace ReflectDesign.Site.Services.Interfaces;

public interface IArticlesService
{
    IReadOnlyList<Article> GetArticlesByCategory(string? category);
}