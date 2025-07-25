using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider;
using TechTalk.SpecFlow;


namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderAddApprenticeDetailsHow(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Add apprentice details";
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        internal ProviderSelectLearnerFromILRPage SelectApprenticeFromILR()
        {
            SelectRadioOptionByForAttribute("confirm-ILR");
            Continue();
            return new ProviderSelectLearnerFromILRPage(context);
        }

        internal ProviderSelectStandardPage SelectAddManually()
        {
            SelectRadioOptionByForAttribute("confirm-Manual");
            Continue();
            return new ProviderSelectStandardPage(context);
        }

        internal ProviderChooseAReservationPage SelectAddManuallyViaCreateNewReservation()
        {
            SelectRadioOptionByForAttribute("confirm-Manual");
            Continue();
            return new ProviderChooseAReservationPage(context);
        }

        internal ProviderAccessDeniedPage SelectAddManuallyGoesToAccessDenied()
        {
            SelectRadioOptionByForAttribute("confirm-Manual");
            Continue();
            return new ProviderAccessDeniedPage(context);
        }



    }
}
