using HtmlAgilityPack;

namespace ActualFass;

public class FassResultSelector
{
  protected readonly HtmlNode Root;

  private readonly Func <HtmlNode, string> _titleSelector;
  private readonly Func <HtmlNode, IEnumerable <HtmlNode>> _resultSelector;

  public string Title => _titleSelector(Root);

  public FassResultSelector
  (
    HtmlNode root,
    Func <HtmlNode, string> titleSelector,
    Func <HtmlNode, IEnumerable <HtmlNode>> resultSelector)
  {
    Root            = root;
    _titleSelector  = titleSelector;
    _resultSelector = resultSelector;
  }

  public IEnumerable <HtmlNode> GetResults() => _resultSelector(Root);
}