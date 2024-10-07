namespace App.Services;

using App.Models;

public class SuggestionService
{
    public List<Product> GetSuggestions(Order? cart, List<Product>? products)
    {
        var suggestions = new List<Product>();

        if (products != null)
        {
            foreach (var product in products)
            {
                if (cart != null && cart.Items != null)
                {
                    var productInCart = false;
                    foreach (var item in cart.Items)
                    {
                        if (item.Product.Id == product.Id)
                        {
                            productInCart = true;
                            break;
                        }
                    }

                    if (!productInCart)
                    {
                        suggestions.Add(product);
                    }
                }
                else
                {
                    suggestions.Add(product);
                }

                if (suggestions.Count == 10)
                {
                    break;
                }
            }
        }

        return suggestions;
    }


}
