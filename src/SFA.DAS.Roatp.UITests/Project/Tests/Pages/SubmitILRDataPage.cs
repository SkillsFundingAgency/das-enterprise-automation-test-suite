using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class SubmitILRDataPage : RoatpBasePage
    {
        protected override string PageTitle => "Does your organisation have the resources to submit Individualised Learner Record (ILR) data?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public SubmitILRDataPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage SelectYesAndContinueonILRpage()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
