using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages
{
    public class ConfirmProvidersContactDetailsPage : AedBasePage
    {
        protected override string PageTitle => "Confirm";

        protected override bool TakeFullScreenShot => false;

        public ConfirmProvidersContactDetailsPage(ScenarioContext context) : base(context)  { }

        public CheckYourAnswersPage ContinueToProviderCheckYourAnswersPage()
        {
            Continue();
            return new CheckYourAnswersPage(context);
        }

        public EditProvidersContactDetailsPage BackToEditProvidersContactDetailsPage()
        {
            formCompletionHelper.Click(BackLink);
            return new EditProvidersContactDetailsPage(context);
        }
    }
}
