using System.Text;
using LightHtmlLibrary.ImageLoaders;
using LightHtmlLibrary.Visitors;

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
    
    public override string Accept(IVisitor visitor) => visitor.Visit(this);

    protected override string RenderNode()
    {
        StringBuilder sb = new($"<{Tag}");

        if (Display != null)
        {
            sb.Append($" style=\"display:{Display};\"");
            _onStylesApplied();
        }

        if (_classes.Count != 0)
        {
            sb.Append($" class=\"{string.Join(' ', _classes)}\"");
            _onClassListApplied();
        }

        sb.Append($" />: {_loader.GetImage(Href)}");

        return sb.ToString();
    }
}