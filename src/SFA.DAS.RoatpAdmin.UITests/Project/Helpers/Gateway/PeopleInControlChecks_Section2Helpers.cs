using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Gateway
{
   public class PeopleInControlChecks_Section2Helpers
    {
        internal GWApplicationOverviewPage PassPeopleInControlChecks_PeopleInControl(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section2_PeopleInControl()
            .SelectPassAndContinue()
            .VerifyPeopleincontrol_Section2(StatusHelper.StatusPass);
        }
        internal GWApplicationOverviewPage PassPeopleInControlChecks_PeopleInControlHighRisk(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section2_PeopleInControlHighRisk()
            .SelectPassAndContinue()
            .VerifyPeopleincontrolhighrisk_Section2(StatusHelper.StatusPass);
        }
        internal GWApplicationOverviewPage FailPeopleInControlChecks_PeopleInControl(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section2_PeopleInControl()
            .SelectFailAndContinue()
            .VerifyPeopleincontrol_Section2(StatusHelper.StatusFail);
        }
        internal GWApplicationOverviewPage FailPeopleInControlChecks_PeopleInControlHighRisk(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section2_PeopleInControlHighRisk()
            .SelectFailAndContinue()
            .VerifyPeopleincontrolhighrisk_Section2(StatusHelper.StatusFail);
        }
    }
}
