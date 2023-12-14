using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class UseTransferFundsPage : TransferMatchingBasePage
    {

        protected override string PageTitle => "Use transfer funds from";

        private static By StartNowButton => By.XPath("//a[text()='Start now']");

        public UseTransferFundsPage(ScenarioContext context) : base(context, false) { }


        public AddTrainingProviderDetailsPage ClickOnStartNowButton()
        {
            formCompletionHelper.Click(StartNowButton);
            return new AddTrainingProviderDetailsPage(context);
        }



    }
}
