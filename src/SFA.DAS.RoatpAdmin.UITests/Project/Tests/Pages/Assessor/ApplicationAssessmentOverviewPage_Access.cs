using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.ProtectingYourApprenticesChecks;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor
{
    public partial class ApplicationAssessmentOverviewPage : AssessorBasePage
    {
        private void NavigateToTask(string linkText) => formCompletionHelper.ClickLinkByText(linkText);

        #region Section-1
        public ContinuityPlanForApprenticeshipTrainingPage Access_Section1_Link1()
        {
            NavigateToTask(Section1_Link1);
            return new ContinuityPlanForApprenticeshipTrainingPage(_context);
        }
        public EqualityAndDiversityPolicyPage Access_Section1_Link2()
        {
            NavigateToTask(Section1_Link2);
            return new EqualityAndDiversityPolicyPage(_context);
        }
        public SafeguardingAndPreventDutyPolicyPage Access_Section1_Link3()
        {
            NavigateToTask(Section1_Link3);
            return new SafeguardingAndPreventDutyPolicyPage(_context);
        }
        public HealthAndSafetyPolicyPage Access_Section1_Link4()
        {
            NavigateToTask(Section1_Link4);
            return new HealthAndSafetyPolicyPage(_context);
        }
        public ActingAsASubcontractorPage Access_Section1_Link5()
        {
            NavigateToTask(Section1_Link5);
            return new ActingAsASubcontractorPage(_context);
        }
        #endregion
    }
}
