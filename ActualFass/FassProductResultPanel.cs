using HtmlAgilityPack;

namespace ActualFass;

public class FassProductResultPanel : AbstractHtmlNode
{
  private HtmlNode? AnchorNode => ContentNode?
   .SelectSingleNode("a[@class]");

  private HtmlNode? ContentNode => Root
   .SelectSingleNode("div[@id]");

  private HtmlNode? ExpandContentNode => ContentNode?
   .SelectSingleNode("div[@class='expandcontent']/ul");

  public string? Label => AnchorNode?
   .SelectSingleNode("span[@class='toplabel']")
   .InnerText;

  public FassProductResultPanel(HtmlNode root) : base(root)
  {
  }

  public IEnumerable <FassProductTradeName>? GetResults() =>
    ExpandContentNode?
     .SelectNodes("li[@class='tradeNameList']")
     .Select(x => new FassProductTradeName(x));
}