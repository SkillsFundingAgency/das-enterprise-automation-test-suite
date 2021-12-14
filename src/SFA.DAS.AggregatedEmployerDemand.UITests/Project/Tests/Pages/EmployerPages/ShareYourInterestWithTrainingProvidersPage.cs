using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.EmployerPages
{
    public class ShareYourInterestWithTrainingProvidersPage : AEDBasePage
    {
        protected override string PageTitle => "Share your interest with training providers";

        public ShareYourInterestWithTrainingProvidersPage(ScenarioContext context) : base(context)  { }

        private By StartNowButton => By.ClassName("govuk-button");

        public GetHelpWithFindingATrainingProviderPage ClickStartNow()
        {
            formCompletionHelper.ClickButtonByText(StartNowButton, "Start now");

            return new GetHelpWithFindingATrainingProviderPage(context);
        }
    }
}
