namespace LightHtmlLibrary.Iterator;

public interface IIterator
{
    public LightNodeBase Next();
    public bool HasNext();
}
