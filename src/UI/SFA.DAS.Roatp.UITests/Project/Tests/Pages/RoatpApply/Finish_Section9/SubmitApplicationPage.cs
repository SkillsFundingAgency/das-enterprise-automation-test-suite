using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.Finish_Section9
{
    public class SubmitApplicationPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Submit application on behalf of";

        private static By ConfirmSubmitApplication => By.Id("ConfirmSubmitApplication");
        private static By ConfirmChangeOfOwnership => By.Id("ConfirmChangeOfOwnershipSubmitApplication");
        private static By ConfirmOrganisationSpecific => By.Id("ConfirmOrganisationSpecificSubmitApplication");
        private static By ConfirmFurtherInfoSubmitApplication => By.Id("ConfirmFurtherInfoSubmitApplication");
        private static By ConfirmFurtherCommunicationSubmitApplication => By.Id("ConfirmFurtherCommunicationSubmitApplication");

        public SubmitApplicationPage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationSubmittedPage ConfirmAllAnswersAndSubmitApplication()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ConfirmSubmitApplication));
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ConfirmOrganisationSpecific));
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ConfirmChangeOfOwnership));
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ConfirmFurtherInfoSubmitApplication));
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ConfirmFurtherCommunicationSubmitApplication));
            Continue();
            return new ApplicationSubmittedPage(context);
        }
    }
}
