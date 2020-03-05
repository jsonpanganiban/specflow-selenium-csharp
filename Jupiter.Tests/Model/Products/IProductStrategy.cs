using Jupiter.Tests.Model.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jupiter.Tests.Model.Contracts
{
    public interface IProductStrategy
    {
        //void Buy(Product product);
        bool CompareProduct(Product product);
    }
}
