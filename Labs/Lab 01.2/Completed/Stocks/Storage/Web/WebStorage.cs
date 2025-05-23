using Wincubate.Module1.Exceptions;

namespace Wincubate.Module1.Storage.Web;

class WebStorage : IReadStorage
{
    public string Url { get; }

    public WebStorage(string url)
    {
        Url = url;
    }

    public async Task<string> GetDataAsStringAsync()
    {
        try
        {
            using HttpClient client = new();
            return await client.GetStringAsync(Url);
        }
        catch (Exception exception)
        {
            throw new StockStorageException($"Could not load from \"{Url}\"", exception);
        }
    }
}
