using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage;
using TechTalk.SpecFlow;


namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class YouMustCompleteAllApprenticeDetailsPage : ApprovalsBasePage
    {
        protected override string PageTitle => "You must complete all apprentice details before you can approve this record";

        protected virtual By Reference => By.CssSelector("dd.das-definition-list__definition:nth-child(4)");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector("#submitCohort button");

        private By DraftSaveAndSubmit => By.Id("continue-button");

        public YouMustCompleteAllApprenticeDetailsPage (ScenarioContext context) : base(context) => _context = context;
        
        public DynamicHomePages DraftReturnToHomePage()
        {
            var cohortReference = pageInteractionHelper.GetText(Reference);
            
            objectContext.SetCohortReference(cohortReference);

            SelectRadioOptionByForAttribute("radio-home");

            formCompletionHelper.ClickElement(DraftSaveAndSubmit);

            return new DynamicHomePages(_context);
        }
        
    }
}