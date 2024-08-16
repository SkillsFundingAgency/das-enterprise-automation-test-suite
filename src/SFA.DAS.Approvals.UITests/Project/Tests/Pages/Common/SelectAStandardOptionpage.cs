using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public class SelectAStandardOptionpage(ScenarioContext context, bool verifyPage = true) : ApprovalsBasePage(context, verifyPage)
    {
        protected override string PageTitle => "Select a standard option";

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public void SelectAStandardOption()
        {
            formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(RadioLabels)));

            Continue();
        }

        public void ContinueWithAlreadySelectedStandardOption() => Continue();

        public ApprenticeDetailsPage GoBackToApprenticeDetailsPage()
        {
            Back();
            return new ApprenticeDetailsPage(context);
        }
        public ProviderApprenticeDetailsPage GoBackToProviderApprenticeDetailsPage()
        {
            Back();
            return new ProviderApprenticeDetailsPage(context);
        }
    }
}
