using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class EnterUkprnPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "What is your organisation's UK provider reference number (UKPRN)?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By UkprnField => By.CssSelector("#UKPRN, #Ukprn");
        private By EmptyUkprnErrorMessage => By.LinkText("Enter a UKPRN");
        private By InvalidUkprnErrorMessage => By.LinkText("Enter a UKPRN using 8 numbers");

        public EnterUkprnPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ConfirmOrganisationsDetailsPage EnterOrgTypeCompanyProvidersUkprn() => EnterOrgTypeCompanyProvidersUkprn(objectContext.GetUkprn());

        public ConfirmOrganisationsDetailsPage EnterOrgTypeCompanyProvidersUkprn(string ukprn)
        {
            formCompletionHelper.EnterText(pageInteractionHelper.FindElement(UkprnField), ukprn);
            Continue();
            return new ConfirmOrganisationsDetailsPage(_context);
        }
    }
}
