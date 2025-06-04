using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    internal class Problem15
    {
        static void Main()
        {
            Product product = new Product();
            var anyBelow30 = product.GetProducts().Any(p => p.ProMrp < 30);
            Console.WriteLine($"Any product below 30: {anyBelow30}");
            Console.ReadLine();
        }
    }
}

