using LightHtmlLibrary.Visitors;

namespace LightHtmlLibrary;

public abstract class LightNodeBase : ILightNode
{
    protected readonly List<string> _classes = [];
    
    public Action<LightNodeBase>? OnCreated;
    public Action<LightNodeBase>? OnInserted;
    public Action<LightNodeBase>? OnRemoved;
    public Action<LightNodeBase>? OnStylesApplied;
    public Action<LightNodeBase, IEnumerable<string>>? OnClassListApplied;
    public Action<LightNodeBase>? OnTextRendered;
    
    public string Render()
    {
        _onCreated();
        return RenderNode();
    }

    public abstract string Accept(IVisitor visitor);

    protected abstract string RenderNode();

    protected virtual void _onCreated() => OnCreated?.Invoke(this);
    protected virtual void _onInserted() => OnInserted?.Invoke(this);
    protected virtual void _onStylesApplied() => OnStylesApplied?.Invoke(this);
    protected virtual void _onRemoved(LightNodeBase? node = null) => OnRemoved?.Invoke(node ?? this);
    protected virtual void _onClassListApplied() => OnClassListApplied?.Invoke(this, _classes);
    protected virtual void _onTextRendered() => OnTextRendered?.Invoke(this);
}
