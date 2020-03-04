using Jupiter.Tests.Model.Contracts;
using OpenQA.Selenium;


namespace Jupiter.Tests.Model.Products
{
    public class Product
    {

        private IWebElement webElement;

        private readonly By _productTitleElem = By.CssSelector(".product-title");
        private readonly By _productPriceElem = By.CssSelector(".product-price");
        private readonly By _productButtonElem = By.CssSelector(".btn");


        public Product(IWebElement webElement)
        {
            this.webElement = webElement;
        }

        public string GetProductTitle()
        {
            return webElement.FindElement(_productTitleElem).Text;
        }

        public string GetProductPrice()
        {
            return webElement.FindElement(_productPriceElem).Text;
        }

        //public void BuyProduct()
        //{
        //    webElement.FindElement(_productButtonElem).Click();
        //}

    }
}
