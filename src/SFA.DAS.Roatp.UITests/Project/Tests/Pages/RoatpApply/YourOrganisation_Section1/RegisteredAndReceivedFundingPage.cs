
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class RegisteredAndReceivedFundingPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Is your organisation registered and receiving funding from ESFA?";

        public RegisteredAndReceivedFundingPage(ScenarioContext context) : base(context) => VerifyPage();

        public DescribeYourOrganisationPage SelectYesForRegisteredAndReceivedFundingAndContinue()
        {
            SelectYesAndContinue();
            return new DescribeYourOrganisationPage(_context);
        }
    }
}


