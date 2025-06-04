using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    internal class Problem12
    {
        static void Main()
        {
            Product product = new Product();
            var maxPrice = product.GetProducts().Max(p => p.ProMrp);
            Console.WriteLine($"Max Price: {maxPrice}");
            Console.ReadLine();
        }
    }
}

