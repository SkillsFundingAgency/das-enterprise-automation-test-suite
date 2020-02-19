using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public class ProviderRoutePage : RoatpAdminBasePage
    {
        protected override string PageTitle => "Choose a provider route for";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector(".govuk-button[value='Continue']");

        public ProviderRoutePage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public TypeOrganisationsPage SubmitProviderTypeMain()
        {
            SelectRadioOptionByText("Main provider");
            Continue();
            return new TypeOrganisationsPage(_context);
        }
    }
}
