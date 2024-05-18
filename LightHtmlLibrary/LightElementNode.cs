using System.Text;
using LightHtmlLibrary.Iterator;

namespace LightHtmlLibrary;

public class LightElementNode(string tag) : LightNodeBase
{
    private readonly List<LightNodeBase> _children = [];
    public string Tag { get; set; } = tag;
    public bool IsSingle { get; set; }
    public string? Display { get; set; }
    public IEnumerable<string> Classes => new List<string>(_classes);
    public IEnumerable<LightNodeBase> Children => new List<LightNodeBase>(_children);
    public int ChildrenCount => _children.Count;
    
    public event EventHandler? OnClick;
    public event EventHandler? OnDblClick;
    public event EventHandler? OnMouseOver;
    public event EventHandler? OnMouseOut;

    public void AppendChild(LightNodeBase child)
    {
        if (IsSingle)
            throw new ArgumentException("Single nodes can't contain any children!");
        _children.Add(child);
        _onInserted();
    }

    public void RemoveChild(LightNodeBase child)
    {
        _children.Remove(child);
        _onRemoved(child);
    }

    public void AddClass(string css)
    {
        if (!_classes.Contains(css))
            _classes.Add(css);
    }

    public void RemoveClass(string css)
        => _classes.Remove(css);
    
    public string InnerHTML()
    {
        StringBuilder sb = new();
        foreach (var childNode in _children)
            sb.Append($"\n{childNode.Render()}");
        return sb.ToString();
    }

    public string OuterHTML() => Render();

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
        
        if (!IsSingle)
        {
            if (_children.Count != 0)
            {
                sb.Append('>');
                sb.Append(InnerHTML());
                sb.Append($"\n</{Tag}>");
            }
            else
                sb.Append($"></{Tag}>");
        }
        else
            sb.Append(" />");

        return sb.ToString();
    }

    public IIterator GetIterator(IteratorType type = IteratorType.DepthFirst)
    {
        return type switch
        {
            IteratorType.DepthFirst => new DFIterator(this),
            IteratorType.BreadthFirst => new BFIterator(this),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
    
    public void EmulateClick() => OnClick?.Invoke(this, EventArgs.Empty);
    public void EmulateDblClick() => OnDblClick?.Invoke(this, EventArgs.Empty);
    public void EmulateMouseOver() => OnMouseOver?.Invoke(this, EventArgs.Empty);
    public void EmulateMouseOut() => OnMouseOut?.Invoke(this, EventArgs.Empty);
    
    public override string ToString() => Tag;
}
