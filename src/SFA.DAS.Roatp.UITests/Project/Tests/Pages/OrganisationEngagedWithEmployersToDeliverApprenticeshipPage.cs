using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class OrganisationEngagedWithEmployersToDeliverApprenticeshipPage : RoatpBasePage
    {
        protected override string PageTitle => "Has your organisation engaged with employers to deliver apprenticeship training to their employees?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public OrganisationEngagedWithEmployersToDeliverApprenticeshipPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ManageRelationshipWithEmployerPage ClickYesToEngagedWithEmployersToDeliverApprenticeshipAndContinue()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new ManageRelationshipWithEmployerPage(_context);
        }
    }
}
