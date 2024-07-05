using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class ConfirmApplicantSucessfulPage(ScenarioContext context) : ConfirmApplicantSuccessStatusPage(context, "successful?")
    {
        public new ApplicationSuccessfulPage NotifyApplicant()
        {
            base.NotifyApplicant();
            return new ApplicationSuccessfulPage(context);
        }
    }
}
