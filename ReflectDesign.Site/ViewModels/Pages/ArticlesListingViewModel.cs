using ReflectDesign.Site.Extensions;
using ReflectDesign.Site.Models.Generated;
using ReflectDesign.Site.ViewModels.Layout;

namespace ReflectDesign.Site.ViewModels.Pages;

public class ArticlesListingViewModel : PageViewModel
{
    private ArticlesListingViewModel(
        string title,
        HeaderViewModel header,
        FooterViewModel footer,
        string description,
        string surtTitle,
        IEnumerable<string> categories
    )
    {
        Title = title;
        Header = header;
        Footer = footer;
        Description = description;
        Surtitle = surtTitle;
        Categories = categories.ToList();
    }

    public string Description { get; private set; }
    public string Surtitle { get; private set; }
    public IReadOnlyList<string> Categories { get; private set; }

    public static ArticlesListingViewModel Create(Home? home, ArticlesListing? articlesListing)
    {
        ArgumentNullException.ThrowIfNull(home, nameof(home));
        ArgumentNullException.ThrowIfNull(articlesListing, nameof(articlesListing));

        var header = HeaderViewModel.Create(home);
        var footer = FooterViewModel.Create(home);
        var categories = home
            .FirstChild<Categories>()
            .Children()
            .Select(category => category.Name)
            .ToList();

        return new ArticlesListingViewModel(
            articlesListing.GetPageTitle(),
            header,
            footer,
            articlesListing.Description,
            articlesListing.Surtitle,
            categories
        );
    }
}
