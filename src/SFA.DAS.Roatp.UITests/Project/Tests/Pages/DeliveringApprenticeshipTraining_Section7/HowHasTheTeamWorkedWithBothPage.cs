using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.DeliveringApprenticeshipTraining_Section7
{
    public class HowHasTheTeamWorkedWithBothPage : HowHasTheTeamOrPersonWorked
    {
        protected override string PageTitle => "How has the team worked with other organisations and employers to develop and deliver training?";

        public HowHasTheTeamWorkedWithBothPage(ScenarioContext context) : base(context)   {  }
    }
}