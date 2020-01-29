using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class OrganisationExpectToUseSubcontractorsPage : RoatpBasePage
    {
        protected override string PageTitle => "Does your organisation expect to use subcontractors in the first 12 months of joining RoATP?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public OrganisationExpectToUseSubcontractorsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public CarryOutDueDiligencePage YesToUsingSubcontractorsAndContinue()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new CarryOutDueDiligencePage(_context);
        }
    }
}
