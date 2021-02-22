using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ForgottenPasswordConfirmPage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => "Forgotten password";

        private readonly ScenarioContext _context;

        private By Info => By.CssSelector("#main-content .govuk-body");

        public ForgottenPasswordConfirmPage(ScenarioContext context) : base(context)
        {
            _context = context;

            VerifyPage();

            VerifyPage(Info, objectContext.GetApprenticeEmail());
        }
    }
}
