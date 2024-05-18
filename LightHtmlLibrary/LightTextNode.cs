using LightHtmlLibrary.Visitors;

namespace LightHtmlLibrary;

public class LightTextNode(string text) : LightNodeBase
{
    public string InnerText { get; set; } = text;

    public override string Accept(IVisitor visitor) => visitor.Visit(this);

    protected override string RenderNode()
    {
        _onTextRendered();
        return InnerText;
    }
}
