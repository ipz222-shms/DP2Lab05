namespace LightHtmlLibrary;

public class LightTextNode(string text) : LightNodeBase
{
    public string InnerText { get; set; } = text;

    protected override string RenderNode()
    {
        _onTextRendered();
        return InnerText;
    }
}
