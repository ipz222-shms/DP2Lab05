namespace LightHtmlLibrary.ImageLoaders;

public class FileImageLoader : IImageLoader
{
    public byte[] GetImage(string href)
    {
        var bytes = File.ReadAllBytes(href);
        return bytes;
    }
}
