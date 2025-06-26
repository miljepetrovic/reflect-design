using ReflectDesign.Site.Models;
using ReflectDesign.Site.Models.Generated;
using ReflectDesign.Site.ViewModels.Blocks;

namespace ReflectDesign.Site.Factories;

public class PageBlocksViewModelFactory
{
    public static IReadOnlyList<PageBlockViewModel> Create(IEnumerable<PageBlock> pageBlock)
        => pageBlock
            .Select(CreateViewModel)
            .WhereNotNull()
            .ToList();

    private static PageBlockViewModel? CreateViewModel(PageBlock block)
    {
        var blocksViewModelMap = new Dictionary<Type, Type>
        {
            { typeof(Cards), typeof(CardsViewModel) },
            { typeof(TextImage), typeof(TextImageViewModel) },
            { typeof(OurValues), typeof(OurValuesViewModel) },
            { typeof(AgreementDetails), typeof(AgreementDetailsViewModel) },
            { typeof(ImageSlides), typeof(ImageSlidesViewModel) },
            { typeof(Faq), typeof(FaqViewModel) },
            { typeof(Testimonials), typeof(TestimonialsViewModel) },
            { typeof(Text), typeof(TextViewModel) }
        };

        if (!blocksViewModelMap.TryGetValue(block.Block.GetType(), out var viewModelType))
        {
            return default;
        }

        var blockViewModel
            = Activator.CreateInstance(viewModelType, block.Block) as PageBlockViewModel;

        blockViewModel.BackgroundColor = block.BackgroundColor;

        return blockViewModel;
    }
}
