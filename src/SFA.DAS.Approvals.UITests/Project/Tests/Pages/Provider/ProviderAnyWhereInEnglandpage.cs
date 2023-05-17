using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderAnyWhereInEnglandpage : ApprovalsBasePage
    {
        protected override string PageTitle => "Can you deliver this training anywhere in England?";
        private By YesICanDeliverTrainingAnywhereInEngland => By.Id("Yes");

        public ProviderAnyWhereInEnglandpage(ScenarioContext context) : base(context) { }

        public ProviderSaveStandardPage SelectOptionICanDeliverAnywhereInEngland()
        {
            javaScriptHelper.ClickElement(YesICanDeliverTrainingAnywhereInEngland);
            Continue();
            return new ProviderSaveStandardPage(context);
        }

    }
}
