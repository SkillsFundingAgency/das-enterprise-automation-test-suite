using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class UseTransferFundsPage(ScenarioContext context) : TransferMatchingBasePage(context, false)
    {

        protected override string PageTitle => "Use transfer funds from";

        private static By StartNowButton => By.LinkText("Start now");

        public ChooseYourMainTrainingProviderPage ClickOnStartNowButton()
        {
            formCompletionHelper.Click(StartNowButton);
            return new ChooseYourMainTrainingProviderPage(context);
        }
    }
}
