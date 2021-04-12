using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ApprenticeHomePage : ApprenticeCommitmentsBasePage
    {
        private readonly ScenarioContext _context;

        protected override string PageTitle => "My apprenticeship(s)";
        private string ConfirmYourEmployerLinkText => "Confirm your employer";
        private string ConfirmYourProviderLinkText => "Confirm your training provider";
        private string ConfirmApprenticeshipLinkText => "Your Apprenticeship Details";

        public ApprenticeHomePage(ScenarioContext context) : base(context) => _context = context;

        public ConfirmYourEmployerPage ConfirmYourEmployer()
        {
            formCompletionHelper.ClickLinkByText(ConfirmYourEmployerLinkText);
            return new ConfirmYourEmployerPage(_context);
        }

        public AlreadyConfirmedEmployerPage ConfirmAlreadyConfirmedEmployer()
        {
            formCompletionHelper.ClickLinkByText(ConfirmYourEmployerLinkText);
            return new AlreadyConfirmedEmployerPage(_context);
        }

        public ConfirmYourTrainingProviderPage ConfirmYourTrainingProvider()
        {
            formCompletionHelper.ClickLinkByText(ConfirmYourProviderLinkText);
            return new ConfirmYourTrainingProviderPage(_context);
        }

        public AlreadyConfirmedTrainingProviderPage ConfirmAlreadyConfirmedTrainingProvider()
        {
            formCompletionHelper.ClickLinkByText(ConfirmYourProviderLinkText);
            return new AlreadyConfirmedTrainingProviderPage(_context);
        }

        public ConfirmYourApprenticeshipDetailsPage ConfirmYourApprenticeship()
        {
            formCompletionHelper.ClickLinkByText(ConfirmApprenticeshipLinkText);
            return new ConfirmYourApprenticeshipDetailsPage(_context);
        }

        public AlreadyConfirmedApprenticeshipDetailsPage ConfirmAlreadyConfirmedApprenticeship()
        {
            formCompletionHelper.ClickLinkByText(ConfirmApprenticeshipLinkText);
            return new AlreadyConfirmedApprenticeshipDetailsPage(_context);
        }
    }
}
