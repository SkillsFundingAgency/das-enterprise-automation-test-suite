using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class FundedByTheOfficeForStudentsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Is your organisation funded by the Office for Students?";
        
        public FundedByTheOfficeForStudentsPage(ScenarioContext context) : base(context) => VerifyPage();

        public InitialTeacherTrainingPage SelectYesForFundedbyOFSAndContinue()
        {
            SelectYesAndContinue();
            return new InitialTeacherTrainingPage(_context);
        }

        public ApprenticeshipTrainingAsSubcontractorPage SelectYesForFundedbyOFSAndContinueForSupportingRoute()
        {
            SelectYesAndContinue();
            return new ApprenticeshipTrainingAsSubcontractorPage(_context);
        }

        public InitialTeacherTrainingPage SelectNoForFundedbyOFSAndContinue()
        {
            SelectNoAndContinue();
            return new InitialTeacherTrainingPage(_context);
        }

        public ApprenticeshipTrainingAsSubcontractorPage SelectNoForFundedbyOFSAndContinueForSupportingRoute()
        {
            SelectNoAndContinue();
            return new ApprenticeshipTrainingAsSubcontractorPage(_context);
        }
    }
}
