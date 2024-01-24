using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class AreYouSureYouWantToSubmitPage(ScenarioContext context) : AreYouSureBasePage(context)
    {
        protected override string PageTitle => "Are you sure you want to submit this job advert?";
    }
}
