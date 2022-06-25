using System.Web;

namespace ActualFass;

public static class FassExtensions
{
  public static string CleanText(this string _) => HttpUtility.HtmlDecode(_).Trim();
  public static string CleanEndpoint(this string _) => HttpUtility.HtmlDecode(_).TrimStart('.');
}