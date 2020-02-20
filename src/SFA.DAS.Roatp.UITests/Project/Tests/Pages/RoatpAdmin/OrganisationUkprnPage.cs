using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public class OrganisationUkprnPage : RoatpAdminBasePage
    {
        protected override string PageTitle => "What is the organisation's UKPRN?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By UkprnField => By.Id("UKPRN");

        public OrganisationUkprnPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public OrganisationsDetailsPage EnterUkprn()
        {
            formCompletionHelper.EnterText(UkprnField, objectContext.GetUkprn());
            Continue();
            return new OrganisationsDetailsPage(_context);
        }

    }
}
