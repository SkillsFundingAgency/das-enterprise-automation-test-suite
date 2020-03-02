using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage
{
    public class DoYouNeedToCreateAnAdvertPage : DoYouNeedToCreateAnAdvertBasePage
    {
        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.Id("accept");
        private By NoRadioButtonOption => By.Id("choice2-no");

        public DoYouNeedToCreateAnAdvertPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public AddAnApprenitcePage ClickNoRadioButtonTakesToAddAnApprentices()
        {
            _formCompletionHelper.ClickElement(NoRadioButtonOption);
            Continue();
            return new AddAnApprenitcePage(_context);
        }
    }
}
