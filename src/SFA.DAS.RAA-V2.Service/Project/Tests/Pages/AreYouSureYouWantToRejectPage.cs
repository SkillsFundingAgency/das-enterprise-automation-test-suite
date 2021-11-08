using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class AreYouSureYouWantToRejectPage : AreYouSureBasePage
    {
        protected override string PageTitle => "Are you sure you want to reject this job advert?";

        public AreYouSureYouWantToRejectPage(ScenarioContext context) : base(context) { }
    }
}
