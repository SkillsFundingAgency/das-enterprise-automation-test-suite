using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class ChooseOrganisationPage : EIBasePage
    {
        protected override string PageTitle => "Choose organisation";

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        public ChooseOrganisationPage(ScenarioContext context) : base(context) => _context = context;

        public QualificationQuestionPage SelectFirstEntityInChooseOrgPageAndContinue()
        {
            SelectRadioOptionByForAttribute("selected");
            formCompletionHelper.Click(ContinueButton);
            return new QualificationQuestionPage(_context);
        }
    }
}
