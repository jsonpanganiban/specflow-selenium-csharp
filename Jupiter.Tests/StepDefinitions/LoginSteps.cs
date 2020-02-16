using Jupiter.Tests.Pages;
using Jupiter.Tests.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Jupiter.Tests.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private LoginPage loginPage;

        public LoginSteps(LoginPage loginPage)
        {
            this.loginPage = loginPage;
        }

        [When(@"I enter invalid credentials")]
        [When(@"I enter valid credentials")]
        public void WhenIEnterCredentials(Table loginTable)
        {
            var loginDict = TableHelpersExtension.ConvertToDictionary(loginTable);
            loginPage.Login(loginDict["Username"], loginDict["Password"]);
        }

        [Then(@"Message (.*) should be displayed")]
        public void ThenFailureMessageShouldBeDisplayed(string message)
        {
            loginPage.ValidateInvalidLogin(message);
        }
    }
}
