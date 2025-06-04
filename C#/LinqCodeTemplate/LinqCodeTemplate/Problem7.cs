using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    internal class Problem7
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();
            var result = products.GroupBy(p => p.ProCategory);

            foreach (var group in result)
            {
                Console.WriteLine($"Category: {group.Key}");
                foreach (var item in group)
                {
                    Console.WriteLine($"\t{item.ProName} - {item.ProMrp}");
                }
            }

            Console.ReadLine();
        }
    }
}

