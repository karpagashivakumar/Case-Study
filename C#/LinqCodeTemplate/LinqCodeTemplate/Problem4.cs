using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    internal class Problem4
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();
            var result = products.OrderBy(p => p.ProCategory).ToList();
            foreach (var item in result)
            {
                Console.WriteLine($"{item.ProCategory}\t{item.ProName}");
            }

            Console.ReadLine();
        }
    }
}
