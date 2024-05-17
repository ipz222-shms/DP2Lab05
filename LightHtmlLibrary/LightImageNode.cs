using System.Text;
using LightHtmlLibrary.ImageLoaders;

namespace LightHtmlLibrary;

public class LightImageNode : LightElementNode
{
    private readonly IImageLoader _loader;
    public string Href { get; set; }

    public LightImageNode(string href, IImageLoader loader) : base("img")
    {
        Href = href;
        IsSingle = true;
        _loader = loader;
    }

    public override string Render()
    {
        StringBuilder sb = new($"<{Tag}");
        
        if (Display != null)
            sb.Append($" style=\"display:{Display};\"");
        
        if (_classes.Count != 0)
            sb.Append($" class=\"{string.Join(' ', _classes)}\"");

        sb.Append($" />: {_loader.GetImage(Href)}");

        return sb.ToString();
    }
}