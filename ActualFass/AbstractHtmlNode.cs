using HtmlAgilityPack;

namespace ActualFass;

public abstract class AbstractHtmlNode
{
  protected HtmlNode Root { get; }

  protected AbstractHtmlNode(HtmlNode root)
  {
    Root = root;
  }
}