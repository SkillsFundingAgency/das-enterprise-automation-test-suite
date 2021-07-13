using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages
{
    public class WhichEmployersAreYouInterestedInPage : AEDBasePage
    {
        protected override string PageTitle => "";
        protected override By PageHeader => By.ClassName("govuk-heading-xl");
        private readonly ScenarioContext _context;
        public WhichEmployersAreYouInterestedInPage(ScenarioContext context) : base(context) => _context = context;

        #region Locators
        private By FirstEmployerCheckbox => By.ClassName("govuk-checkboxes__input");
        #endregion

        public EditProvidersContactDetailsPage CheckAndContinueWithfirstEmployerCheckbox()
        {
            formCompletionHelper.SelectCheckbox(FirstEmployerCheckbox);
            ContinueToNextPage();
            return new EditProvidersContactDetailsPage(_context);
        }
    }
}
