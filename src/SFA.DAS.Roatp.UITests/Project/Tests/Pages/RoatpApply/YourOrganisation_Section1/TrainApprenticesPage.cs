using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class TrainApprenticesPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "How will your organisation train its apprentices?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public TrainApprenticesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public DescribeYourOrganisationPage SelectInYourOrganisationAndContinue()
        {
            
            SelectRadioOptionByText("In your organisation");
            Continue();
            return new DescribeYourOrganisationPage(_context);
        }
    }
}
