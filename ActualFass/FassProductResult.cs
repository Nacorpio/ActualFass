using HtmlAgilityPack;

namespace ActualFass;

public class FassProductResult : AbstractHtmlNode
{
  private HtmlNode? HyperNode => Root.SelectSingleNode("a");
  private HtmlNode? DetailNode => HyperNode?.SelectSingleNode("div[@class]");

  public string? Url => HyperNode != null &&
    HyperNode.Attributes.Contains("href")
      ? "http://www.fass.se" + HyperNode?.Attributes["href"].Value.CleanEndpoint()
      : null;

  public string? Label => DetailNode?
   .SelectSingleNode("span[@class='innerlabel']").InnerText
   .CleanText();

  public string? CompanyName => DetailNode?
   .SelectSingleNode("div[@class='additionalInfo'][1]/span").InnerText
   .CleanText();

  public FassProductResult(HtmlNode root) : base(root)
  {
  }

  public string? GetProductId() =>
    Url == null
      ? null
      : new Uri(Url).Query.Split('&')[1]
       .Split('=')[1];

}