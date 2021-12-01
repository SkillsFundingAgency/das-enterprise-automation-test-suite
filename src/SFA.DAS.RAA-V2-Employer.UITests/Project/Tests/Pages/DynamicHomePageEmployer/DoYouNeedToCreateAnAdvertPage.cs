using SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.DynamicHomePageEmployer
{
    class DoYouNeedToCreateAnAdvertPage: DoYouNeedToCreateAnAdvertBasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public DoYouNeedToCreateAnAdvertPage(ScenarioContext context) : base(context) => _context = context;

        public CreateAnAdvertHomePage ClickYesRadioButtonTakesToRecruitment()
        {
            formCompletionHelper.ClickElement(YesRadioButtonOption);
            Continue();
            return new CreateAnAdvertHomePage(_context);
        }
    }
}
