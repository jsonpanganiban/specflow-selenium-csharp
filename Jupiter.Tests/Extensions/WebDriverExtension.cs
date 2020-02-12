using Jupiter.Tests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jupiter.Tests.Extensions
{
    public static class WebDriverExtension
    {
        public static IWebElement WaitForVisible(this ISearchContext searchContext, Func<ISearchContext, IWebElement> condition, double seconds = 10)
        {
            var wait = new DefaultWait<ISearchContext>(searchContext) { Timeout = TimeSpan.FromSeconds(seconds) };
            var result = wait.Until(condition);
            wait.Until(d => result.Displayed);
            return result;
        }
    }
}
