
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class RegisteredAndReceivedFundingPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Is your organisation registered and receiving funding from ESFA?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public RegisteredAndReceivedFundingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public DescribeYourOrganisationPage SelectYesForRegisteredAndReceivedFundingAndContinue()
        {
            SelectYesAndContinue();
            return new DescribeYourOrganisationPage(_context);
        }
    }
}


