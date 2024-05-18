namespace LightHtmlLibrary.Iterator;

public class BFIterator : IIterator
{
    private readonly Queue<LightNodeBase> _queue = [];

    public BFIterator(LightNodeBase root) => _queue.Enqueue(root);

    public LightNodeBase Next()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException();

        var node = _queue.Dequeue();
        if (node is LightElementNode elementNode)
            foreach (var childNode in elementNode.Children)
                _queue.Enqueue(childNode);

        return node;
    }

    public bool HasNext() => _queue.Count > 0;
}
