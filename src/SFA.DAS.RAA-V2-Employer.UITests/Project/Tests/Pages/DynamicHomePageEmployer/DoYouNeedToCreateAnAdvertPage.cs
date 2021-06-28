using SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.DynamicHomePageEmployer
{
    class DoYouNeedToCreateAnAdvertPage: DoYouNeedToCreateAnAdvertBasePage
    {
        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public DoYouNeedToCreateAnAdvertPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public CreateAnAdvertHomePage ClickYesRadioButtonTakesToRecruitment()
        {
            _formCompletionHelper.ClickElement(YesRadioButtonOption);
            Continue();
            return new CreateAnAdvertHomePage(_context);
        }
    }
}
