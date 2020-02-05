using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.PlanningApprenticeshipTraining_Section6
{
    public class AwardingBodiesPage : RoatpBasePage
    {
        protected override string PageTitle => "How does your organisation plan to engage and work with awarding bodies?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");


        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea_EngageWithAwardingBodies => By.Id("PAT-800");

        public AwardingBodiesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ContactAboutTheApprenticeshipsPage EnterTextForEngageAndWorkWithAwardingBodiesMainRouteAndContinue()
        {
            formCompletionHelper.EnterText(LongTextArea_EngageWithAwardingBodies, applydataHelpers.EngageWithAwardingBodies);
            Continue();
            return new ContactAboutTheApprenticeshipsPage(_context);
        }

        public ApplicationOverviewPage EnterTextForEngageAndWorkWithAwardingBodiesEmployerRouteAndContinue()
        {
            formCompletionHelper.EnterText(LongTextArea_EngageWithAwardingBodies, applydataHelpers.EngageWithAwardingBodies);
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
