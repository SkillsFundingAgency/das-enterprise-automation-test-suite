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
        #endregion
    }
}
