using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class EIStartPage : EIBasePage
    {
        protected override string PageTitle => "Apply for the new apprentice payment";

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        public EIStartPage(ScenarioContext context) : base(context) => _context = context;

        public QualificationQuestionPage ClickStartNowButtonInEIStartPageForSingleEntityJourney()
        {
            formCompletionHelper.Click(ContinueButton);
            return new QualificationQuestionPage(_context);
        }

        public ChooseOrganisationPage ClickStartNowButtonInEIStartPageForMultipleEntityJourney()
        {
            formCompletionHelper.Click(ContinueButton);
            return new ChooseOrganisationPage(_context);
        }
    }
}
