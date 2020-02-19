using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public class RoatpAdminHomePage : RoatpAdminBasePage
    {
        protected override string PageTitle => "Search for an apprenticeship training provider";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By Confirmation => By.CssSelector(".govuk-panel--confirmation");

        public RoatpAdminHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public OrganisationUkprnPage AddANewTrainingProvider()
        {
            formCompletionHelper.ClickLinkByText("Add a new training provider");
            return new OrganisationUkprnPage(_context);
        }

        public bool VerifyNewProviderHasBeenAdded() => pageInteractionHelper.VerifyText(Confirmation, "has been added");
    }
}
