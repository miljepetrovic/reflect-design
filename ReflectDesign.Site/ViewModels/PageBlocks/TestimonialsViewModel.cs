using System;
using ReflectDesign.Site.Models.Generated;
using ReflectDesign.Site.ViewModels.Blocks;

namespace ReflectDesign.Site.ViewModels.Blocks;

public class TestimonialsViewModel : PageBlockViewModel
{
    public TestimonialsViewModel(Testimonials model)
    {
        ArgumentNullException.ThrowIfNull(nameof(model));

        Title = model.Title;
        Description = model.Description;
        Items = model.CastedItems
            .Select(item => new TestimonialItemViewModel(item))
            .ToList();
    }
    public string? Title { get; private set; }
    public string? Description { get; private set; }
    public IReadOnlyList<TestimonialItemViewModel> Items { get; private set; }
}

public class TestimonialItemViewModel
{
    public TestimonialItemViewModel(TestimonialItem model)
    {
        ArgumentNullException.ThrowIfNull(nameof(model));

        Text = model.Text;
        Author = model.Author;
    }

    public string? Text { get; private set; }
    public string? Author { get; private set; }
}
