using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages
{
    public class WhichEmployersAreYouInterestedInPage : AedBasePage
    {
        protected override string PageTitle => "";

        public WhichEmployersAreYouInterestedInPage(ScenarioContext context) : base(context)  { }

        #region Locators
        private By FirstEmployerCheckbox => By.CssSelector(".govuk-checkboxes__input");
        #endregion

        public EditProvidersContactDetailsPage CheckAndContinueWithfirstEmployerCheckbox()
        {
            formCompletionHelper.SelectCheckbox(FirstEmployerCheckbox);
            Continue();
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
            Continue();
            return new ConfirmProvidersContactDetailsPage(context);
        }
    }
}
