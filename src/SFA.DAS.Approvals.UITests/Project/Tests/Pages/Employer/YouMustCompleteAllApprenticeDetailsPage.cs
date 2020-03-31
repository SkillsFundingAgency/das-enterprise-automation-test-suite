using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;


namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class YouMustCompleteAllApprenticeDetailsPage : BasePage
    {
        protected override string PageTitle => "You must complete all apprentice details before you can approve this record";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector("#submitCohort button");
        private By DraftGoToHomePage => By.CssSelector("#submitCohort > div > fieldset > div > div:nth-child(4) > label");
        private By DraftSaveAndSubmit => By.CssSelector("#submitCohort > button");
        public YouMustCompleteAllApprenticeDetailsPage (ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }
        
        public DynamicHomePages DraftReturnToHomePage()
        {
            _formCompletionHelper.ScrollAndClickElement(DraftGoToHomePage);
            _formCompletionHelper.ScrollAndClickElement(DraftSaveAndSubmit);
            return new DynamicHomePages(_context);
        }
        
    }
}