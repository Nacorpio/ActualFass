// See https://aka.ms/new-console-template for more information

using ActualFass;

var fc       = new FassClient();
var result   = await fc.SearchAsync("diazepam");
var products = result?.GetProducts();

var cards = new List <FassProductCard>();

foreach (var product in products!)
{
  var productId   = product.GetProductId();
  var productCard = await fc.GetProductCardAsync(productId!);
  
  cards.Add(productCard!);
}

Console.ReadLine();