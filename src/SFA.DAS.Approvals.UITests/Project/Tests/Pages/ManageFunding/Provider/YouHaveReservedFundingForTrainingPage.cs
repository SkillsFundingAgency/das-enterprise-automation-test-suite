using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class YouHaveReservedFundingForTrainingPage(ScenarioContext context) : ReservationIdBasePage(context)
    {
        protected override string PageTitle => "You have reserved funding for training";

        private static By ContinueButtonTo => By.XPath("//button[contains(text(),'Continue')]");

        internal ApprovalsProviderHomePage GoToHomePage()
        {
            SelectRadioOptionByForAttribute("WhatsNext-home");
            formCompletionHelper.ClickElement(ContinueButtonTo);
            return new ApprovalsProviderHomePage(context);
        }

        internal ProviderSelectStandardPage GoToSelectStandardPage()
        {
            SelectRadioOptionByForAttribute("WhatsNext-add");
            formCompletionHelper.ClickElement(ContinueButtonTo);
            return new ProviderSelectStandardPage(context);
        }

        internal ProviderAddApprenticeDetailsHow GoToAddApprenticeDetailsHowPage()
        {
            SelectRadioOptionByForAttribute("WhatsNext-add");
            formCompletionHelper.ClickElement(ContinueButtonTo);
            return new ProviderAddApprenticeDetailsHow(context);
        }

        public new YouHaveReservedFundingForTrainingPage VerifySucessMessage()
        {
            base.VerifySucessMessage();
            return this;
        }
    }
}
