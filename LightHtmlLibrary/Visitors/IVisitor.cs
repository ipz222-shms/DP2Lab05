namespace LightHtmlLibrary.Visitors;

public interface IVisitor
{
    public string Visit(LightElementNode node);
    public string Visit(LightTextNode node);
    public string Visit(LightImageNode node);
}
