using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;


namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class YouMustCompleteAllApprenticeDetailsPage : BasePage
    {
        protected override string PageTitle => "You must complete all apprentice details before you can approve this record";
        protected virtual By Reference => By.CssSelector("dd.das-definition-list__definition:nth-child(4)");

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector("#submitCohort button");
        private By DraftSaveAndSubmit => By.Id("continue-button");
        public YouMustCompleteAllApprenticeDetailsPage (ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _employerStepsHelper = new EmployerStepsHelper(context);
            VerifyPage();
        }
        
        public DynamicHomePages DraftReturnToHomePage()
        {
            var cohortReference = _pageInteractionHelper.GetText(Reference);
            _employerStepsHelper.SetCohortReference(cohortReference);

            SelectRadioOptionByForAttribute("radio-home");
            _formCompletionHelper.ClickElement(DraftSaveAndSubmit);
            return new DynamicHomePages(_context);
        }
        
    }
}