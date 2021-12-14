using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages
{
    public class CheckYourAnswersPage : AEDBasePage
    {
        protected override string PageTitle => "Check your answers";
        
        public CheckYourAnswersPage(ScenarioContext context) : base(context)  { }

        private By ChangeEmail => By.XPath("//body/div[2]/main[1]/div[1]/div[1]/dl[2]/div[1]/dd[2]/a[1]");

        private By ChangeLocation => By.XPath("//body/div[2]/main[1]/div[1]/div[1]/dl[1]/div[2]/dd[2]/a[1]");

        public WeveSharedYourContactDetailsWithEmployersPage ContinueToWeveSharedYourContactDetailsWithEmployersPage()
        {
            ContinueToNextPage();
            return new WeveSharedYourContactDetailsWithEmployersPage(context);
        }

        public EditProvidersContactDetailsPage ChangeProviderContactDetails()
        {
            formCompletionHelper.Click(ChangeEmail);
            return new EditProvidersContactDetailsPage(context);
        }

        public ConfirmProvidersContactDetailsPage BackToProvidersContactDetailsPage()
        {
            formCompletionHelper.Click(BackLink);
            return new ConfirmProvidersContactDetailsPage(context);
        }

        public WhichEmployersAreYouInterestedInPage ChangeProviderLocationDetails()
        {
            formCompletionHelper.Click(ChangeLocation);
            return new WhichEmployersAreYouInterestedInPage(context);
        }
    }
}