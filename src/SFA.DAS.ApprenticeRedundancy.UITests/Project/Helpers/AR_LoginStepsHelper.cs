using SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages.AR_Admin;
using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages.Admin
{
    public class AR_LoginStepsHelper
    {
        private readonly ScenarioContext _context;

        public AR_LoginStepsHelper(ScenarioContext context) => _context = context;

        public void SubmitValidLoginDetails()
        {
            new IdamsPage(_context).LoginToAccess1Staff();

            new AR_SignInPage(_context).SubmitValidLoginDetails();
        }
    }
}
