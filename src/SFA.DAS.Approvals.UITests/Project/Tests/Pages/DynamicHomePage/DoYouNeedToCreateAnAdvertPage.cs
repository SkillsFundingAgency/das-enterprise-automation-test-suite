
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage
{
    public class DoYouNeedToCreateAnAdvertPage : DoYouNeedToCreateAnAdvertBasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public DoYouNeedToCreateAnAdvertPage(ScenarioContext context) : base(context) => _context = context;

        public AddAnApprenitcePage ClickNoRadioButtonTakesToAddAnApprentices()
        {
            formCompletionHelper.ClickElement(NoRadioButtonOption);
            Continue();
            return new AddAnApprenitcePage(_context);
        }
    }
}
