using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public class SelectAStandardOptionpage : ApprovalsBasePage
    {
        protected override string PageTitle => "Select a standard option";

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public SelectAStandardOptionpage(ScenarioContext context) : base(context) { }

        public void SelectAStandard()
        {
            formCompletionHelper.ClickElement(() => apprenticeDataHelper.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(RadioLabels)));

            Continue();
        }

        public void ContinueWithAlreadySelectedStandard() => Continue();
    }
}
