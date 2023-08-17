using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    internal class Product
    {
        public string Name { get; set; }
        public  decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public static decimal TotalCalc(IEnumerable<Product> products)
        {
            return products.Sum(p => p.Price);
        }
    }
}
