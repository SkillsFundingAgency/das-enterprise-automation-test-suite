using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7
{
    public class HowHasThisPersonWorkedPage : HowHasTheTeamOrPersonWorked
    {
        protected override string PageTitle => "How has this person worked with employers to develop and deliver training?";

        public HowHasThisPersonWorkedPage(ScenarioContext context) : base(context)  {  }
    }
}
