using System.Text;

namespace LightHtmlLibrary.Visitors;

public class XMLVisitor : IVisitor
{
    public string Visit(LightElementNode node)
    {
        StringBuilder sb = new($"<{node.Tag}>");

        if (node.Display != null)
            sb.Append($"\n<{node.Tag}.DISPLAY>\n{node.Display}\n</{node.Tag}.DISPLAY>\n");

        if (!node.IsSingle && node.Children.Any())
        {
            sb.Append('\n');
            foreach (var childNode in node.Children)
                sb.Append($"{childNode.Accept(this)}\n");
        }
        
        sb.Append($"</{node.Tag}>");
        return sb.ToString();
    }

    public string Visit(LightTextNode node) => $"<TEXT>{node.InnerText}</TEXT>";

    public string Visit(LightImageNode node) => $"<IMAGE>\n<IMAGE.HREF>\n{node.Href}\n</IMAGE.HREF>\n</IMAGE>";
}
