using TechTalk.SpecFlow;

namespace Jupiter.Framework.Base
{
    public abstract class BaseSteps
    {
        protected readonly ScenarioContext ScenarioContext;

        protected BaseSteps(ScenarioContext scenarioContext)
        {
            ScenarioContext = scenarioContext;
        }
    }
}
