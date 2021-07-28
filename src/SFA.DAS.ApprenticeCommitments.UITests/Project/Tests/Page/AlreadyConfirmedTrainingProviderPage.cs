using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class AlreadyConfirmedTrainingProviderPage : ConfirmYourDetailsPage
    {
        protected override string PageTitle => "Confirm your training provider";
        private string GreenTickTextInfo => "You have confirmed this is your training provider";

        public AlreadyConfirmedTrainingProviderPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
            pageInteractionHelper.VerifyText(GreenTickText, GreenTickTextInfo);
            VerifyPage(ConfirmingEntityNamePageHeader, objectContext.GetProviderName());
        }
    }
}
