namespace LightHtmlLibrary;

public class LightTextNode(string text) : ILightNode
{
    public string InnerText { get; set; } = text;

    public string Render() => InnerText;
}
