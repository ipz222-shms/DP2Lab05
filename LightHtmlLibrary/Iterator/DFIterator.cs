namespace LightHtmlLibrary.Iterator;

public class DFIterator : IIterator
{
    private readonly Stack<LightNodeBase> _stack = [];

    public DFIterator(LightNodeBase root) => _stack.Push(root);

    public LightNodeBase Next()
    {
        if (_stack.Count == 0)
            throw new InvalidOperationException();

        var node = _stack.Pop();
        if (node is LightElementNode elementNode)
            foreach (var childNode in elementNode.Children.Reverse())
                _stack.Push(childNode);

        return node;
    }
    
    public bool HasNext() => _stack.Count > 0;
}
