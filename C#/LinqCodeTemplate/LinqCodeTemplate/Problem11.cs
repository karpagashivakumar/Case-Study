using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    internal class Problem11
    {
        static void Main()
        {
            Product product = new Product();
            var count = product.GetProducts().Count(p => p.ProCategory == "FMCG");
            Console.WriteLine($"Total FMCG Products: {count}");
            Console.ReadLine();
        }
    }
}

