using HtmlAgilityPack;

namespace ActualFass;

public class FassArticleContentSelector : AbstractHtmlNode
{
  public delegate IEnumerable <string> HeaderNodeSelector(HtmlNode root);

  public delegate IEnumerable <HtmlNode> DataNodeSelector(HtmlNode root);

  protected HtmlNode? HeaderNode => Root.SelectSingleNode("header");
  protected HtmlNode? ContentNode => Root.SelectSingleNode("div[@id='readspeaker-article-content']/div[@class]");

  private readonly HeaderNodeSelector _headerSelector;
  private readonly DataNodeSelector _dataSelector;

  public FassArticleContentSelector
  (
    HtmlNode root,
    HeaderNodeSelector headerSelector,
    DataNodeSelector dataSelector) : base(root)
  {
    _headerSelector = headerSelector;
    _dataSelector   = dataSelector;
  }

  public IReadOnlyDictionary <string, HtmlNode>? ToDictionary()
  {
    var headers = GetHeaderNodes().ToArray();
    var data    = GetDataNodes().ToArray();

    var results = new Dictionary <string, HtmlNode>();

    for (var i = 0 ; i < headers.Length ; i++)
    {
      var h = headers[i].CleanText();
      var d = data[i];

      results.Add(h, d);
    }

    return results;
  }

  public IEnumerable <string> GetHeaderNodes() => _headerSelector(ContentNode!);
  public IEnumerable <HtmlNode> GetDataNodes() => _dataSelector(ContentNode!);
}