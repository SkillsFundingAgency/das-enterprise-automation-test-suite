using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderAddApprenticeDetailsHow(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Add apprentice details";
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        internal ProviderSelectStandardPage SelectAddManually()
        {
            SelectRadioOptionByForAttribute("confirm-Manual");
            Continue();
            return new ProviderSelectStandardPage(context);
        }

        internal ProviderSelectApprenticeFromILRPage SelectApprenticeFromILR()
        {
            SelectRadioOptionByForAttribute("confirm-ILR");
            Continue();
            return new ProviderSelectApprenticeFromILRPage(context);
        }
    }
}
