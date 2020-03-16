using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class OrganisationDetailsPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Organisation details";

        protected override By PageHeader => By.CssSelector(".govuk-caption-xl");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ContactLink => By.CssSelector(".govuk-link[href*='view-contact']");

        private By StandardViewLink => By.CssSelector(".govuk-link[href*='view-standard']");

        public OrganisationDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ContactDetailsPage SelectContact()
        {
            NavigateTo(ContactLink);
            return new ContactDetailsPage(_context);
        }

        public StandardsDetailsPage SelectStandards()
        {
            NavigateTo(StandardViewLink);
            return new StandardsDetailsPage(_context);
        }

        private void NavigateTo(By @by) => formCompletionHelper.ClickElement(() => ePAOAdminDataHelper.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(@by)));
    }
}
