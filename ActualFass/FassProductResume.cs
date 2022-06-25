using HtmlAgilityPack;

namespace ActualFass;

public class FassResume : FassArticleContentSelector
{
  public FassResume(HtmlNode root) : base(root, HeaderSelector, DataSelector)
  {
  }

  private static IEnumerable <string> HeaderSelector(HtmlNode root) =>
    root
     .SelectNodes("h2")
     .Select(x => x.InnerText);

  private static IEnumerable <HtmlNode> DataSelector(HtmlNode root) =>
    root
     .SelectNodes("p");
}