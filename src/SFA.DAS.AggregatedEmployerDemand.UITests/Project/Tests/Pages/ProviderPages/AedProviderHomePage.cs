using OpenQA.Selenium;
using SFA.DAS.ProviderLogin.Service.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages
{
    public class AedProviderHomePage : ProviderHomePage
    {
        public AedProviderHomePage(ScenarioContext context) : base(context) => VerifyPage();

        private By PireanPreprodButton => By.XPath("//span[contains(text(),'Pirean Preprod')]");

        public FindEmployersThatNeedATrainingProviderPage FindEmployersThatNeedATrainingProvider()
        {
            formCompletionHelper.ClickElement(FindingEmployersThatNeedATrainingProviderLink);
            if (pageInteractionHelper.IsElementDisplayed(PireanPreprodButton))
            {
                formCompletionHelper.ClickElement(PireanPreprodButton);
            }
            return new FindEmployersThatNeedATrainingProviderPage(context);
        }
    }
}
