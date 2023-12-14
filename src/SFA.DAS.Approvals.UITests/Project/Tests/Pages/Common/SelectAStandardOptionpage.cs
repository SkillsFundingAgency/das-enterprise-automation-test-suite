using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public class SelectAStandardOptionpage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Select a standard option";

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public void SelectAStandardOption()
        {
            formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(RadioLabels)));

            Continue();
        }

        public void ContinueWithAlreadySelectedStandardOption() => Continue();
    }
}
