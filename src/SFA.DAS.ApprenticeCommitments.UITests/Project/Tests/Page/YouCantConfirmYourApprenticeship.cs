using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class YouCantConfirmYourApprenticeship : ApprenticeCommitmentsBasePage
    {
        private readonly ScenarioContext _context;

        protected override string PageTitle => "You can’t confirm your apprenticeship yet";

        public YouCantConfirmYourApprenticeship(ScenarioContext context) : base(context)
        {
            _context = context;

            VerifyPage();
        }
    }
}
