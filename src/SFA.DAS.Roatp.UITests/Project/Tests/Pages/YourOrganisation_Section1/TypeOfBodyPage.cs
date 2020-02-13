using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.YourOrganisation_Section1
{
    public class TypeOfBodyPage : RoatpBasePage
    {
        protected override string PageTitle => "What type of public body is your organisation?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public TypeOfBodyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public DescribeYourOrganisationPage SelectGovernmentDepartmentAndContinue()
        {
            SelectRadioOptionByText("Government department");
            Continue();
            return new DescribeYourOrganisationPage(_context);
        }
    }
}
