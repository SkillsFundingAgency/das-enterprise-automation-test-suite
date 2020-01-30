using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages
{
    public class AP_OD13_RegisterOfRemovedTrusteesPage : EPAO_BasePage
    {
        protected override string PageTitle => "Register of removed trustees";
        private readonly ScenarioContext _context;

        public AP_OD13_RegisterOfRemovedTrusteesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_OrganisationDetailsBasePage SelectNoOptionAndContinueInRegisterOfRemovedTrusteesPage()
        {
            SelectRadioOptionByForAttribute("CD-27_1");
            Continue();
            return new AP_OrganisationDetailsBasePage(_context);
        }
    }
}
