using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class ApplyForTheNewApprenticePaymentPage : EIBasePage
    {
        protected override string PageTitle => "Apply for the new apprentice payment";

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        public ApplyForTheNewApprenticePaymentPage(ScenarioContext context) : base(context) => _context = context;

        public HaveYouTakenOnNewApprenticesPage ClickStartNowButtonInEIStartPageForSingleEntityJourney()
        {
            formCompletionHelper.Click(ContinueButton);
            return new HaveYouTakenOnNewApprenticesPage(_context);
        }

        public ChooseOrganisationPage ClickStartNowButtonInEIStartPageForMultipleEntityJourney()
        {
            formCompletionHelper.Click(ContinueButton);
            return new ChooseOrganisationPage(_context);
        }
    }
}
