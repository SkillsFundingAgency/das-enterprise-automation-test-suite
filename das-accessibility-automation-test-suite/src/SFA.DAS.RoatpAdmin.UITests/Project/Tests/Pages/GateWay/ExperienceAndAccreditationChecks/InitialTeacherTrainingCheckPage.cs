using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.ExperienceAndAccreditationChecks
{
    public class InitialTeacherTrainingCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Initial teacher training (ITT) check";

        public InitialTeacherTrainingCheckPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
