using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class AlreadyConfirmedEmployerPage : ConfirmYourDetailsPage
    {
        protected override string PageTitle => "Confirm your employer";
        private string GreenTickTextInfo => "You have confirmed this is your employer";

        public AlreadyConfirmedEmployerPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
            pageInteractionHelper.VerifyText(GreenTickText, GreenTickTextInfo);
            VerifyPage(ConfirmingEntityNamePageHeader, objectContext.GetEmployerName().Replace("  "," "));
        }
    }
}
