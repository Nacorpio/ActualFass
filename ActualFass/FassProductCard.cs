using HtmlAgilityPack;

namespace ActualFass;

public sealed class FassProductCard : AbstractHtmlNode
{
    public sealed class Feature : AbstractHtmlNode
    {
        // XPath: abbr

        private HtmlNode? HyperNode => Root.SelectSingleNode("a[@id]");
        private HtmlNode? ImageNode => HyperNode?.SelectSingleNode("img[@alt]");

        public string? Url => HyperNode?.GetAttributeValue("href", null);
        public string? Summary => ImageNode?.GetAttributeValue("alt", null);
        public string? Description => ImageNode?.GetAttributeValue("data-explanation", null);

        public Feature(HtmlNode root) : base(root)
        {
        }

    }

    public const string XPath = "div[@id='product-card']";

    private HtmlNode? IntroNode => Root.SelectSingleNode("header/div[@class='intro']");
    private HtmlNode? DescriptionNode => Root.SelectSingleNode("div[@class='description-container']");
    private HtmlNode? ImageNode => Root.SelectSingleNode("div[@class='imgs']");
    private HtmlNode? FeaturesNode => IntroNode?.SelectSingleNode("div[@class='features']");
    private HtmlNode? GeneralInfoNode => IntroNode?.SelectSingleNode("p[@class='generalinfo']");

    public string? Label => IntroNode?.SelectSingleNode("h1[@class='big-header']")?.InnerText.CleanText();
    public string? CompanyName => IntroNode?.SelectSingleNode("a[@id='companyname']/span")?.InnerText.CleanText();
    public string? AtcCode => Root.SelectSingleNode("div[@class='list-box code']/a/span")?.InnerText.CleanText();

    public string? Interchangeable =>
        Root.SelectSingleNode("div[@class='list-box interchangeable']/a/span").InnerText.CleanText();

    public string? Summary => DescriptionNode?.SelectSingleNode("p[@class='desc'][3]").InnerText.CleanText() ?? null;

    public string? ImageUrl =>
        ImageNode?.SelectSingleNode("figure/a/img")?.GetAttributeValue("src", null).CleanText() ?? null;

    public string? WeightText => GeneralInfoNode?.SelectSingleNode("span[@class='weight']")?.InnerText ?? null;

    public string? AppearanceText => GeneralInfoNode?
       .SelectSingleNode("span[@class='shape']")?.InnerText?
       .TrimStart('(')
       .TrimEnd(')');

    public string? AddictionText => DescriptionNode?.SelectSingleNode("p[@class='desc'][1]/span").InnerText;

    public IEnumerable <string>? ActiveSubstances => Root
       .SelectNodes("div[@class='list-box substance']/ul/li/a/span")?
       .Select(x => x.InnerText);

    public IEnumerable <Feature>? Features => FeaturesNode?
       .SelectNodes("abbr")
       .Select(x => new Feature(x));

    public FassProductCard(HtmlNode root) : base(root)
    {
    }
}