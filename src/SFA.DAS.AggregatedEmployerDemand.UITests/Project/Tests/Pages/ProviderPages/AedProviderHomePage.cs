using OpenQA.Selenium;
using SFA.DAS.ProviderLogin.Service.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages
{
    public class AedProviderHomePage : ProviderHomePage
    {
        private readonly ScenarioContext _context;
        public AedProviderHomePage(ScenarioContext context) : base(context) => _context = context;

        private By PireanPreprodButton => By.XPath("//span[contains(text(),'Pirean Preprod')]");

        public FindEmployersThatNeedATrainingProviderPage FindEmployersThatNeedATrainingProvider()
        {
            formCompletionHelper.ClickElement(FindingEmployersThatNeedATrainingProviderLink);
            if (pageInteractionHelper.IsElementDisplayed(PireanPreprodButton))
            {
                formCompletionHelper.ClickElement(PireanPreprodButton);
            }
            return new FindEmployersThatNeedATrainingProviderPage(_context);
        }
    }
}
