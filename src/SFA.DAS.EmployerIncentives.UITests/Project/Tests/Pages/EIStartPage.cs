using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class EIStartPage : EIBasePage
    {
        protected override string PageTitle => "Apply for the hire a new apprentice payment";
        private By StartNowButton => By.LinkText("Start now");

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        public EIStartPage(ScenarioContext context) : base(context) => _context = context;

        public QualificationQuestionPage ClickStartNowButtonInEIStartPageForSingleEntityJourney()
        {
            formCompletionHelper.Click(StartNowButton);
            return new QualificationQuestionPage(_context);
        }

        public ChooseOrganisationPage ClickStartNowButtonInEIStartPageForMultipleEntityJourney()
        {
            formCompletionHelper.Click(StartNowButton);
            return new ChooseOrganisationPage(_context);
        }
    }
}
