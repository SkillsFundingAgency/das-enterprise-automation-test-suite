using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class CheckDetailsAndReserveFundingPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Check details and reserve funding";

        protected override bool TakeFullScreenShot => false;

        private static By ConfirmButton => By.XPath("//button[contains(text(),'like to reserve funding')]");
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public SuccessfullyReservedFundingPage ClickConfirmButton()
        {
            formCompletionHelper.ClickElement(ConfirmButton);
            return new SuccessfullyReservedFundingPage(context);
        }
    }
}