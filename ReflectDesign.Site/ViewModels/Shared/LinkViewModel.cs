using System;
using Umbraco.Cms.Core.Models;

namespace ReflectDesign.Site.ViewModels.Shared;

public class LinkViewModel
{
    private LinkViewModel(
        string url,
        string name,
        string target
    )
    {
        Url = url;
        Name = name;
        Target = target;
    }

    public static LinkViewModel? Create(Link? link)
    {
        if (link is null)
        {
            return default;
        }

        return new(link.Url!, link.Name!, link.Target ?? "_blank");
    }

    public string Url { get; private set; }
    public string Name { get; private set; }
    public string Target { get; private set; }
}
