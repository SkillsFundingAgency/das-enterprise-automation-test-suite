using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public class DoYouNeedToCreateAnAdverForThisApprenticeshipPage : BasePage
    {
        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        #region
        protected override string PageTitle => "Do you need to create an advert for this apprenticeship?";
        protected override By PageHeader => By.Id("heading-continue-setup-create-advert");
        protected override By ContinueButton => By.Id("accept");
        private By YesRadioButtonOption => By.Id("choice1-yes");
        private By NoRadioButtonOption => By.Id("choice2-no");
        #endregion

        public DoYouNeedToCreateAnAdverForThisApprenticeshipPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public ApprenticesHomePage ClickNoRadioButtonTakesToAddAnApprentices()
        {
            _formCompletionHelper.ClickElement(NoRadioButtonOption);
            Continue();
            return new ApprenticesHomePage(_context);
        }
        public RecruitmentHomePage ClickYesRadioButtonTakesToRecruitment()
        {
            _formCompletionHelper.ClickElement(YesRadioButtonOption);
            Continue();
            return new RecruitmentHomePage(_context);
        }
    }
}
