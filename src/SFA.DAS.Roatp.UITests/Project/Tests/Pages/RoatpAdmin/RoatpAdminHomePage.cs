using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public class RoatpAdminHomePage : RoatpAdminBasePage
    {
        protected override string PageTitle => "Staff dashboard";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

 

        public RoatpAdminHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public OrganisationUkprnPage AddANewTrainingProvider()
        {
            formCompletionHelper.ClickLinkByText("Add a new apprenticeship training provider");
            return new OrganisationUkprnPage(_context);
        }

        public RoatpAdminHomePage DownloadRegister()
        {
            formCompletionHelper.ClickLinkByText("Download list of apprenticeship training providers");
            return new RoatpAdminHomePage(_context);
        }

        public SearchPage SearchForTrainingProvider()
        {
            formCompletionHelper.ClickLinkByText("Search for an apprenticeship training provider");
            return new SearchPage(_context);
        }
    }
}
