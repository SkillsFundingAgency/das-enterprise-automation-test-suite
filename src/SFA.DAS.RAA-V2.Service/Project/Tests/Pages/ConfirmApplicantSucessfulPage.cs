using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ConfirmApplicantSucessfulPage : ConfirmApplicantStatusBasePage
    {     
        public ConfirmApplicantSucessfulPage(ScenarioContext context) : base(context, "have been accepted?") { }

        public new ApplicationSuccessfulPage NotifyApplicant()
        {
            base.NotifyApplicant();
            return new ApplicationSuccessfulPage(context);
        }
    }    
}
