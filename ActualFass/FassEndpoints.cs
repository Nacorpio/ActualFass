namespace ActualFass;

public static class FassEndpoints
{

  // https://www.fass.se/LIF/product?userType=2&nplId=19960927000126
  // https://www.fass.se/LIF/companydetails?orgId=394
  // https://www.fass.se/LIF/substance?userType=2&substanceId=IDE4POCAU9E2EVERT1

  public static string Substance
    (string substanceId, int userType = 2) =>
    $"https://www.fass.se/LIF/substance?userType={userType}&substanceId={substanceId}";

  public static string Company
    (string organizationId) =>
    $"https://www.fass.se/LIF/companydetails?orgId={organizationId}";

  public static string Product
    (string productId, int userType = 2, FassArticleType articleType = FassArticleType.Bipacksedel) =>
    $"https://www.fass.se/LIF/product?userType={userType}&nplId={productId}&docType={(int)articleType}";

  public static string Search
    (string input, int userType = 2) =>
    $"https://www.fass.se/LIF/result?query={input}&userType={userType}";
}