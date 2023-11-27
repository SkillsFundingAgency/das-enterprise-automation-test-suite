using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ConfirmApplicantSucessfulPage : ConfirmApplicantSuccessStatusPage
    {     
        public ConfirmApplicantSucessfulPage(ScenarioContext context) : base(context, "successful?") { }

        public new ApplicationSuccessfulPage NotifyApplicant()
        {
            base.NotifyApplicant();
            return new ApplicationSuccessfulPage(context);
        }
    }    
}
