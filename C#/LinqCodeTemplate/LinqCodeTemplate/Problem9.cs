using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    internal class Problem9
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();
            var maxFmcg = products
                .Where(p => p.ProCategory == "FMCG")
                .OrderByDescending(p => p.ProMrp)
                .FirstOrDefault();

            if (maxFmcg != null)
            {
                Console.WriteLine($"{maxFmcg.ProCode}\t{maxFmcg.ProName}\t{maxFmcg.ProMrp}");
            }

            Console.ReadLine();
        }
    }
}

