using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ConfirmApplicantUnsuccessfulPage(ScenarioContext context) : ConfirmApplicantStatusBasePage(context, "have not been accepted?")
    {
        public new ApplicationUnsuccessfulPage NotifyApplicant()
        {
            base.NotifyApplicant();
            return new ApplicationUnsuccessfulPage(context);
        }
    }
}
