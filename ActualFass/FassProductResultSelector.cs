using HtmlAgilityPack;

namespace ActualFass;

public class FassProductResultSelector : FassResultSelector
{
  public static FassProductResultSelector Create(HtmlNode root) => new(root);

  public FassProductResultSelector
  (
    HtmlNode root) : base(
    root,
    TitleSelector,
    ResultSelector
  )
  {
  }

  private static IEnumerable <HtmlNode> ResultSelector
    (HtmlNode arg) =>
    arg.SelectNodes("div[@id][1]/div[@class='productResultPanel']");

  private static string TitleSelector(HtmlNode arg) =>
    arg
     .SelectSingleNode("div[@class='navigatortitle']")
     .InnerText;
}