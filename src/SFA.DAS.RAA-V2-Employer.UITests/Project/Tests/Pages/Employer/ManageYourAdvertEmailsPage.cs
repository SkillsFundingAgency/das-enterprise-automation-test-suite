using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{
    public class ManageYourAdvertEmailsPage : RegistrationBasePage
    {
        protected override string PageTitle => "Manage your emails";

        #region Helpers and Context      
        private readonly ScenarioContext _context;
        #endregion

        public ManageYourAdvertEmailsPage(ScenarioContext context) : base(context) => _context = context;

    }
}
