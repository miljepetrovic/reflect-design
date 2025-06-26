using ReflectDesign.Site.Extensions;
using ReflectDesign.Site.Models.Generated;
using ReflectDesign.Site.ViewModels.Layout;

namespace ReflectDesign.Site.ViewModels.Pages;

public class ArticleViewModel : PageViewModel
{
    private ArticleViewModel(
        string title,
        HeaderViewModel header,
        FooterViewModel footer,
        string content
    )
    {
        Title = title;
        Header = header;
        Footer = footer;
        Content = content;
    }

    public string Content { get; private set; }

    public static ArticleViewModel Create(Home? home, Article? article)
    {
        ArgumentNullException.ThrowIfNull(home, nameof(home));
        ArgumentNullException.ThrowIfNull(article, nameof(article));

        var header = HeaderViewModel.Create(home);
        var footer = FooterViewModel.Create(home);

        return new ArticleViewModel(
            article.GetPageTitle(),
            header,
            footer,
            article.Content.ToHtmlString()
        );
    }
}
