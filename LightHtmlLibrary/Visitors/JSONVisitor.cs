using System.Text;

namespace LightHtmlLibrary.Visitors;

public class JSONVisitor : IVisitor
{
    public string Visit(LightElementNode node)
    {
        StringBuilder sb = new("{\n" + $"\"{node.Tag}\":" + "\n{");
        sb.Append($"\n\"single\": {node.IsSingle.ToString().ToLower()}");
        
        if (node.Display is not null)
            sb.Append($",\n\"display\": {node.Display}");
        
        if (node.Classes.Any())
        {
            sb.Append(",\n\"classes\": [\n");
            sb.Append(string.Join(",\n", node.Classes.Select(c => $"\"{c}\"")));
            sb.Append("\n]");
        }

        if (node.Children.Any())
        {
            sb.Append(",\n\"children\": [\n");
            sb.Append(string.Join(",\n", node.Children.Select(c => c.Accept(this))));
            sb.Append("\n]");
        }

        sb.Append("\n}\n}");
        return sb.ToString();
    }

    public string Visit(LightTextNode node) => "{ " + $"\"text\": \"{node.InnerText}\"" + " }";

    public string Visit(LightImageNode node) => "{ \"image\": { \"href\": \"" + node.Href + "\" } }";
}
