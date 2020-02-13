using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jupiter.Tests.StepDefinitions
{
    public class ProductContext
    {
        public ProductContext()
        {
            ShopData = new ProductData();
        }

        public ProductData ShopData { get; set; }
    }
}
