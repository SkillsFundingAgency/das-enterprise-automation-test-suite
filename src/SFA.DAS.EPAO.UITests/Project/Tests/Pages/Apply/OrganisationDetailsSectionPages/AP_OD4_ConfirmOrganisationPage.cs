using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages
{
    public class AP_OD4_ConfirmOrganisationPage : EPAO_BasePage
    {
        protected override string PageTitle => "Confirm organisation";
        private readonly ScenarioContext _context;

        public AP_OD4_ConfirmOrganisationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_ApplicationOverviewPage ClickConfirmAndApplyButtonInConfirmOrgPage()
        {
            Continue();
            return new AP_ApplicationOverviewPage(_context);
        }
    }
}
