using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jupiter.Tests.StepDefinitions
{
    public class ShopContext
    {
        public ShopContext()
        {
            ShopData = new ShopData();
        }

        public ShopData ShopData { get; set; }
    }
}
