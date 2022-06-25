using HtmlAgilityPack;

namespace ActualFass;

public class FassResult : AbstractHtmlNode
{
  private HtmlNode? ProductPanelNode => Root.SelectSingleNode("div[@class='mainPanel']/div[1]");
  private HtmlNode? SubstancePanelNode => Root.SelectSingleNode("div[@class='rightPanel']/div[1]");
  private HtmlNode? DiseasePanelNode => Root.SelectSingleNode("div[@class='rightPanel']/div[2]");

  private readonly FassProductResultSelector _productSelector;
  private readonly FassSubstanceResultSelector _substanceSelector;

  public FassResult(HtmlNode root) : base(root)
  {
    _productSelector   = new FassProductResultSelector(ProductPanelNode!);
    _substanceSelector = new FassSubstanceResultSelector(SubstancePanelNode!);
  }

  public IEnumerable <FassProductResult> GetProducts() =>
    GetProductTradeNames()
     .SelectMany(
        x => x
         .GetResults() ?? Array.Empty <FassProductResult>()
      );

  public IEnumerable <FassProductTradeName> GetProductTradeNames() =>
    GetProductPanels()
     .SelectMany(
        x => x
           .GetResults()
          ?? Array.Empty <FassProductTradeName>()
      );

  public IEnumerable <FassProductResultPanel> GetProductPanels() =>
    _productSelector
     .GetResults()
     .Select(x => new FassProductResultPanel(x));
}