using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;

namespace App.Services
{
    public class SuggestionService
    {
        public List<Product> GetSuggestions(Order? cart, List<Product>? products)
        {
            List<Product> suggestions = new List<Product>();

            if (products != null)
            {
                foreach (Product product in products)
                {
                    if (cart != null && cart.Items != null)
                    {
                        bool productInCart = false;
                        foreach (OrderItem item in cart.Items)
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
}
