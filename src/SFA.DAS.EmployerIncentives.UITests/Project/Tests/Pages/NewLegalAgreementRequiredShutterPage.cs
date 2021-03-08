using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class NewLegalAgreementRequiredShutterPage : EIBasePage
    {
        protected override string PageTitle => $"{ObjectContextExtension.GetOrganisationName(objectContext)} needs to accept a new employer agreement";

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        public NewLegalAgreementRequiredShutterPage(ScenarioContext context) : base(context) => _context = context;

        public By ViewAgreement => By.ClassName("govuk-button");

        public LegalAgreementsPage ViewLegalAgreement()
        {
            formCompletionHelper.ClickButtonByText(ViewAgreement, "View agreement");
            return new LegalAgreementsPage(_context);
        }
    }
}
