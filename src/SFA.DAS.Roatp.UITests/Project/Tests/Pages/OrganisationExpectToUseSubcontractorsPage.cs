using OpenQA.Selenium;
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

    public class CarryOutDueDiligencePage : RoatpBasePage
    {
        protected override string PageTitle => "How will your organisation carry out due diligence on its subcontractors?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion
        private By LongTextArea => By.Id("RTE-71");
        public CarryOutDueDiligencePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage EnterTextForManagingRelationshipWithEmployersAndContinue()
        {
            formCompletionHelper.EnterText(LongTextArea, applydataHelpers.ManagingRelationshipWithEmployers);
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
