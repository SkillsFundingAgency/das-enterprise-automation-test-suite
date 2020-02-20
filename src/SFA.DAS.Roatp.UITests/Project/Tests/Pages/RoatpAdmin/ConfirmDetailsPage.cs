using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public class ConfirmDetailsPage : RoatpAdminBasePage
    {
        protected override string PageTitle => "Confirm details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector(".govuk-button[value='Confirm and add organisation']");

        public ConfirmDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public RoatpAdminHomePage ConfirmOrganisationsDetails()
        {
            Continue();
            return new RoatpAdminHomePage(_context);
        }
    }
}
