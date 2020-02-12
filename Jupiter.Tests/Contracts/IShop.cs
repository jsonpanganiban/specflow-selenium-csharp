using System;

namespace Jupiter.Tests.Contracts
{
    public interface IShop : IProduct
    {
        void Buy(string item);
    }
}