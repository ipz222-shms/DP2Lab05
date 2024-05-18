using LightHtmlLibrary.Visitors;

namespace LightHtmlLibrary;

public interface ILightNode
{
    public string Render();
    public string Accept(IVisitor visitor);
}
