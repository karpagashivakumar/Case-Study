using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    internal class Problem14
    {
        static void Main()
        {
            Product product = new Product();
            var allBelow30 = product.GetProducts().All(p => p.ProMrp < 30);
            Console.WriteLine($"All products below 30: {allBelow30}");
            Console.ReadLine();
        }
    }
}

