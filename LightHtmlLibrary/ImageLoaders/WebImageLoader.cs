using System.Net;

namespace LightHtmlLibrary.ImageLoaders;

public class WebImageLoader : IImageLoader
{
    [Obsolete("Obsolete")]
    public byte[] GetImage(string href)
    {
        using WebClient client = new();
        var bytes = client.DownloadData(new Uri(href));
        return bytes;
    }
}
