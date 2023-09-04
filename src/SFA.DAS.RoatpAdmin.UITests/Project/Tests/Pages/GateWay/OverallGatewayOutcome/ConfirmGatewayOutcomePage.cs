using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project;
using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OverallGatewayOutcome
{
    public class ConfirmGatewayOutcomePage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Confirm gateway outcome";

        private static By InternalFailComments => By.Id("OptionFailedText");
        private static By ExternalFailComments => By.Id("OptionFailedExternalText");
        private static By InternalRejectComments => By.Id("OptionRejectedText");
        private static By ExternalRejectComments => By.Id("OptionExternalRejectedText");

        public ConfirmGatewayOutcomePage(ScenarioContext context) : base(context) => VerifyPage();

        public FinalConfirmationPassPage PassThisApplicationAndContinue()
        {
            SelectRadioOptionByText("Pass this application");
            if (objectContext.GetApplicationRoute() == ApplicationRoute.SupportingProviderRoute ||
                objectContext.GetApplicationRoute() == ApplicationRoute.SupportingProviderRouteForExistingProvider) SelectRadioOptionByText("100k");
            Continue();
            return new FinalConfirmationPassPage(context);
        }
        public FinalConfirmationFailPage FailThisApplicationAndContinue()
        {
            SelectRadioOptionByText("Fail this application");
            formCompletionHelper.EnterText(InternalFailComments, "Internal Fail comments");
            formCompletionHelper.EnterText(ExternalFailComments, "External Fail comments");
            Continue();
            return new FinalConfirmationFailPage(context);
        }
        public FinalConfirmationRejectPage RejectThisApplicationAndContinue()
        {
            SelectRadioOptionByText("Reject this application");
            formCompletionHelper.EnterText(InternalRejectComments, "Internal Reject Comments");
            formCompletionHelper.EnterText(ExternalRejectComments, "External Reject Comments");
            Continue();
            return new FinalConfirmationRejectPage(context);
        }
    }
}
