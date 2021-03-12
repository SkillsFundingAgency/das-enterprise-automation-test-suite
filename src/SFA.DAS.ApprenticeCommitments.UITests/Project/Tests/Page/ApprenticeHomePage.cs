using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ApprenticeHomePage : ApprenticeCommitmentsBasePage
    {
        private readonly ScenarioContext _context;

        protected override string PageTitle => "My apprenticeship(s)";

        public ApprenticeHomePage(ScenarioContext context) : base(context)
        {
            _context = context;

            VerifyPage();
        }

        public ConfirmYourEmployerPage ConfirmYourEmployerPage()
        {
            formCompletionHelper.ClickLinkByText("Confirm your employer");
            return new ConfirmYourEmployerPage(_context);
        }
    }
}
