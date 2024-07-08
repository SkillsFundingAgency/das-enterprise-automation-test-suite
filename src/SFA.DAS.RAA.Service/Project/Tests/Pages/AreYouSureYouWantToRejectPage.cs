using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class AreYouSureYouWantToRejectPage(ScenarioContext context) : AreYouSureBasePage(context)
    {
        protected override string PageTitle => "Are you sure you want to reject this job advert?";
    }
}
