using Jupiter.Tests.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Jupiter.Tests.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly LoginPage _loginPage;

        public LoginSteps(LoginPage loginPage)
        {
            _loginPage = loginPage;
        }

        [When(@"I enter invalid credentials")]
        [When(@"I enter valid credentials")]
        public void WhenIEnterCredentials(Table loginTable)
        {
            var loginData = loginTable.CreateInstance<LoginData>();
            _loginPage.Login(loginData.Username, loginData.Password);
        }

        [Then(@"Message (.*) should be displayed")]
        public void ThenFailureMessageShouldBeDisplayed(string message)
        {
            _loginPage.ValidateInvalidLogin(message);
        }
    }
}
