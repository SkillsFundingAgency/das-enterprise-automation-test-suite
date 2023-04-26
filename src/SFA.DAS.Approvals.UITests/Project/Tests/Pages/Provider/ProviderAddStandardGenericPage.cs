using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderAddStandardGenericPage : ApprovalsBasePage
    {
        protected override By PageHeader => By.ClassName("govuk-caption-xl");
        protected override string PageTitle => "Add standard";
        private By IsThisCorrectStandard => By.Id("is-correct-standard-yes");

        public ProviderAddStandardGenericPage(ScenarioContext context) : base(context) { }

        public ProviderYourCntctInfoForThisStandardPage ConfirmStandard()
        {
            javaScriptHelper.ClickElement(IsThisCorrectStandard);
            Continue();
            return new ProviderYourCntctInfoForThisStandardPage(context);
        }
    }
}
