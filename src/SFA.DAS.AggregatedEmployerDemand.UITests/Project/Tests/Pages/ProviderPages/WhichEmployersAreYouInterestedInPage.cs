using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages
{
    public class WhichEmployersAreYouInterestedInPage : AEDBasePage
    {
        protected override string PageTitle => "";
        protected override By PageHeader => By.ClassName("govuk-heading-xl");

        public WhichEmployersAreYouInterestedInPage(ScenarioContext context) : base(context)  { }

        #region Locators
        private By FirstEmployerCheckbox => By.ClassName("govuk-checkboxes__input");
        #endregion

        public EditProvidersContactDetailsPage CheckAndContinueWithfirstEmployerCheckbox()
        {
            formCompletionHelper.SelectCheckbox(FirstEmployerCheckbox);
            ContinueToNextPage();
            return new EditProvidersContactDetailsPage(context);
        }
        public FindEmployersThatNeedATrainingProviderPage BackToFindEmployersThatNeedATrainingProviderPage()
        {
            formCompletionHelper.Click(BackLink);
            return new FindEmployersThatNeedATrainingProviderPage(context);
        }
        public ConfirmProvidersContactDetailsPage CheckAndContinueWithfirstEmployerCheckboxAfterChange()
        {
            formCompletionHelper.SelectCheckbox(FirstEmployerCheckbox);
            ContinueToNextPage();
            return new ConfirmProvidersContactDetailsPage(context);
        }
    }
}
