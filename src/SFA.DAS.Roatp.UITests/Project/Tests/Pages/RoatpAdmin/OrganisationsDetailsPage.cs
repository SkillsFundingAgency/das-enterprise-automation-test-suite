using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public class OrganisationsDetailsPage : RoatpAdminBasePage
    {
        protected override string PageTitle => "Organisation's details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector(".govuk-button[value='Continue']");

        public OrganisationsDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public ProviderRoutePage ConfirmOrganisationsDetails()
        {
            Continue();
            return new ProviderRoutePage(_context);
        }
    }
}
