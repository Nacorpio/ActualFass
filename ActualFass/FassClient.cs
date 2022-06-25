using HtmlAgilityPack;

namespace ActualFass;

public class FassClient
{
  private readonly HttpClient _client;

  public FassClient()
  {
    _client = new HttpClient();
  }

  public async Task <FassBipacksedel?> GetBipacksedelAsync
    (string productId, FassUserType userType = FassUserType.Public)
  {
    var root        = await GetRootNodeAsync(FassEndpoints.Product(productId, (int)userType));
    var bipacksedel = root.SelectSingleNode("//article[@class='article-main']");

    if (bipacksedel == null)
      return null;

    return new FassBipacksedel(bipacksedel);
  }

  public async Task <FassProductCard?> GetProductCardAsync
    (string productId, FassUserType userType = FassUserType.Public)
  {
    var root = await GetRootNodeAsync(FassEndpoints.Product(productId, (int)userType));
    var card = root.SelectSingleNode("//" + FassProductCard.XPath);

    if (card == null)
      return null;

    return new FassProductCard(card);
  }

  public async Task <FassResult?> SearchAsync(string input, FassUserType userType = FassUserType.Public)
  {
    var root  = await GetRootNodeAsync(FassEndpoints.Search(input, (int)userType));
    var panel = root.SelectSingleNode("//div[@class='resultpanel']");

    if (panel == null)
      return null;

    return new FassResult(panel);
  }

  private async Task <HtmlNode> GetRootNodeAsync(string url)
  {
    var src = await _client.GetStringAsync(url);
    var doc = new HtmlDocument();

    doc.LoadHtml(src);

    return doc.DocumentNode;
  }
}