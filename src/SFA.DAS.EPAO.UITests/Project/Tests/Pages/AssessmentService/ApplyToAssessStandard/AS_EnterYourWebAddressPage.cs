using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_EnterYourWebAddressPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Enter your web address";

        private readonly ScenarioContext _context;

        public AS_EnterYourWebAddressPage(ScenarioContext context) : base(context) => _context = context;

        public AS_ApplyToStandardPage EnterWebAddress()
        {
            formCompletionHelper.EnterText(InputText, standardDataHelper.RandomWebsiteAddress);
            Continue();
            return new AS_ApplyToStandardPage(_context);
        }

    }
}
