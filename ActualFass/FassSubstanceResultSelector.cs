using HtmlAgilityPack;

namespace ActualFass;

public class FassSubstanceResultSelector : FassResultSelector
{
  public static FassSubstanceResultSelector Create(HtmlNode root) => new(root);

  public FassSubstanceResultSelector
  (
    HtmlNode root) : base(root, TitleSelector, ResultSelector)
  {
  }

  private static IEnumerable <HtmlNode> ResultSelector(HtmlNode arg) =>
    arg
     .SelectNodes("ul/li[@class='linkList']");

  private static string TitleSelector(HtmlNode arg) =>
    arg
     .SelectSingleNode("h2")
     .InnerText;
}