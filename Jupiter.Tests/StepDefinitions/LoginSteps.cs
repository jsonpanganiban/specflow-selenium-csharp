using Jupiter.Tests.Dialogs;
using Jupiter.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Jupiter.Tests.StepDefinitions
{
    [Binding]
    public class LoginStep
    {
        private readonly LoginDialog _loginDialog;

        public LoginStep(LoginDialog loginDialog)
        {
            _loginDialog = loginDialog;
        }

        [When(@"I enter invalid credentials")]
        [When(@"I enter valid credentials")]
        public void WhenIEnterCredentials(Table loginTable)
        {
            var loginData = loginTable.CreateInstance<LoginData>();
            _loginDialog.Login(loginData.Username, loginData.Password);
        }

        [Then(@"Message (.*) should be displayed")]
        public void ThenFailureMessageShouldBeDisplayed(string message)
        {
            Assert.True(_loginDialog.GetLoginErrorMessage().Displayed);
            Assert.True(_loginDialog.GetLoginErrorMessage().Text.Equals(message));
        }
    }
}
