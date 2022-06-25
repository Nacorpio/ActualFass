using HtmlAgilityPack;

namespace ActualFass;

public class FassProductTradeName : AbstractHtmlNode
{
  private HtmlNode? HyperNode => Root.SelectSingleNode("a[@class]");
  private HtmlNode? ContentNode => Root.SelectSingleNode("ul[@class]");

  public string? Label => HyperNode?
   .SelectSingleNode("span[@class='innerlabel dotmarker']")
   .InnerText;

  public FassProductTradeName(HtmlNode root) : base(root)
  {
    Console.WriteLine();
  }

  public IEnumerable <FassProductResult>? GetResults() =>
    ContentNode?
     .SelectNodes("li[@class='linkList']")
     .Select(x => new FassProductResult(x));
}