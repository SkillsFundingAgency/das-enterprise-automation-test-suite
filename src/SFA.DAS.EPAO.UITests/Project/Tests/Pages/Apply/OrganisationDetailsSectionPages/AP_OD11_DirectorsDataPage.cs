using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages
{
    public class AP_OD11_DirectorsDataPage : EPAO_BasePage
    {
        protected override string PageTitle => "Directors data";
        private readonly ScenarioContext _context;

        public AP_OD11_DirectorsDataPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_DAD_1_AuthoriserDetailsPage SelectNoOptionAndContinueInDirectorsDataPage()
        {
            SelectRadioOptionByForAttribute("CD-22_1");
            Continue();
            return new AP_DAD_1_AuthoriserDetailsPage(_context);
        }
    }
}
