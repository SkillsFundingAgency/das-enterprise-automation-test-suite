using OpenQA.Selenium;
using SFA.DAS.ProviderLogin.Service.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages
{
    public class AedProviderHomePage : ProviderHomePage
    {
        protected By FindingEmployersThatNeedATrainingProviderLink => By.LinkText("Find employers that need a training provider");

        public AedProviderHomePage(ScenarioContext context) : base(context) => VerifyPage();

        public FindEmployersThatNeedATrainingProviderPage FindEmployersThatNeedATrainingProvider()
        {
            formCompletionHelper.ClickElement(FindingEmployersThatNeedATrainingProviderLink);
            
            ClickIfPirenIsDisplayed();
            
            return new FindEmployersThatNeedATrainingProviderPage(context);
        }
    }
}
