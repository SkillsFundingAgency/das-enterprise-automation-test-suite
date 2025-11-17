using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class ConfirmYourReservationPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Confirm your reservation";

        protected override bool TakeFullScreenShot => false;

        private static By ConfirmButton => By.XPath("//button[contains(text(),'Confirm')]");
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public SuccessfullyReservedFundingPage ClickConfirmButton()
        {
            formCompletionHelper.ClickElement(ConfirmButton);
            return new SuccessfullyReservedFundingPage(context);
        }
    }
}