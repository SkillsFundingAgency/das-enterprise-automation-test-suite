using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Financial;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Financial
{
    public class Financial_EndToEndStepsHelper
    { 
    public void MarkApplicationAsReadyForModeration(FinancialHealthAssessmentOverviewPage financialHealthAssessmentOverviewPage)
    {
            financialHealthAssessmentOverviewPage
               .ConfirmFHAReviewAsOutstanding()
               .GoToRoATPAssessorApplicationsPage()
               .
    }
}
