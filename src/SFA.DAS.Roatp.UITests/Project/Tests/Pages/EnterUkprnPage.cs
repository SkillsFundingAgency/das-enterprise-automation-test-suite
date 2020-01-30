using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class EnterUkprnPage : RoatpBasePage
    {
        protected override string PageTitle => "What is your organisation's UK provider reference number (UKPRN)?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By UkprnField => By.Id("UKPRN");
        private By EmptyUkprnErrorMessage => By.LinkText("Enter a UKPRN");
        private By InvalidUkprnErrorMessage => By.LinkText("Enter a UKPRN using 8 numbers");

        public EnterUkprnPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ConfirmOrganisationsDetailsPage EnterOrgTypeCompanyProvidersUkprn()
        {
            formCompletionHelper.EnterText(UkprnField, objectContext.GetUkprn());
            Continue();
            return new ConfirmOrganisationsDetailsPage(_context);
        }
    }
}
