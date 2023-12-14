using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
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
