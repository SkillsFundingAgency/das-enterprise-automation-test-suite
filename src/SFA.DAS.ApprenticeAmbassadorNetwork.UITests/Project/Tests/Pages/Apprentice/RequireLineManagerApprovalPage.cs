namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice
{
    public class RequiresLineManagerApprovalPage(ScenarioContext context) : AanBasePage(context)
    {
        protected override string PageTitle => "Do you have approval from your line manager to join the network?";

        public FindYourRegionalNetworkPage YesHaveApprovalFromMaanagerAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByText("Yes");
            Continue();
            return new FindYourRegionalNetworkPage(context);
        }
        public ShutterPage NoHaveApprovalFromMaanagerAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByText("No");
            Continue();
            return new ShutterPage(context);
        }
        public AccessDeniedPage YesHaveApprovalFromMaanagerAndNonPrivateBetaUser()
        {
            formCompletionHelper.SelectRadioOptionByText("Yes");
            Continue();
            return new AccessDeniedPage(context);
        }
    }
}


