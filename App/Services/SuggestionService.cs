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

            if (products != null && cart != null)
            {
                foreach (Product product in products)
                {
                    if (cart.Items != null)
                    {
                        foreach (OrderItem item in cart.Items)
                        {
                            if (item.Product != product)
                            {
                                suggestions.Add(product);
                            }

                            if (suggestions.Count == 10)
                            {
                                break;
                            }
                        }
                    }
                }
            }

            return suggestions;
        }
    }
}
