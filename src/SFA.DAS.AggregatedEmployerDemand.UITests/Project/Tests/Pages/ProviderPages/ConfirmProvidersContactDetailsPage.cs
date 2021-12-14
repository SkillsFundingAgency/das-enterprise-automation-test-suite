using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages
{
    public class ConfirmProvidersContactDetailsPage : AEDBasePage
    {
        protected override string PageTitle => "";
        protected override By PageHeader => By.ClassName("govuk-heading-xl");

        public ConfirmProvidersContactDetailsPage(ScenarioContext context) : base(context)  { }

        public CheckYourAnswersPage ContinueToProviderCheckYourAnswersPage()
        {
            ContinueToNextPage();
            return new CheckYourAnswersPage(context);
        }
        public EditProvidersContactDetailsPage BackToEditProvidersContactDetailsPage()
        {
            formCompletionHelper.Click(BackLink);
            return new EditProvidersContactDetailsPage(context);
        }
    }
}
