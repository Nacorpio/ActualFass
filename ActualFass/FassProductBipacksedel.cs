using HtmlAgilityPack;

namespace ActualFass;

public class FassBipacksedel : FassArticleContentSelector
{
  public FassBipacksedel(HtmlNode root) : base(root, HeaderSelector, DataSelector)
  {
  }

  private static IEnumerable <string> HeaderSelector(HtmlNode root) =>
    root
     .SelectNodes("a[@id]")
     .Select(x => x.GetAttributeValue("id", null));

  private static IEnumerable <HtmlNode> DataSelector(HtmlNode root) =>
    root
     .SelectNodes("a[@id]")
     .Select(x => x.NextSibling.NextSibling);

}