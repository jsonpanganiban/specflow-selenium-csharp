using System;
using System.Collections.Generic;

namespace Jupiter.Tests.Contracts
{
    public interface ICart: IProduct
    {
        String GetSubtotalPrice(string item);
        void UpdateQuantity(string item, string quantity);
        void ProceedToCheckOut();

    }
}