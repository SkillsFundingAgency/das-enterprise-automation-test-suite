using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class StartAddingApprenticesPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "How would you like to add learners?";
        protected override bool TakeFullScreenShot => false;
        protected override By ContinueButton => By.Id("continue-button");
        private static By MessageBox => By.Name("message");

        public EmployerSelectStandardPage EmployerAddsApprentices()
        {
            EmployerAgreesToAdds();
            Continue();
            return new EmployerSelectStandardPage(context);
        }

        public CohortSentYourTrainingProviderPage EmployerSendsToProviderToAddApprentices()
        {
            EmployerSendsToProviderToAdd();
            formCompletionHelper.EnterText(MessageBox, apprenticeDataHelper.MessageToProvider);
            Continue();
            return new CohortSentYourTrainingProviderPage(context);
        }

        private StartAddingApprenticesPage EmployerAgreesToAdds()
        {
            formCompletionHelper.SelectRadioOptionByText(RadioLabels, "Add them myself");
            return this;
        }

        private StartAddingApprenticesPage EmployerSendsToProviderToAdd()
        {
            formCompletionHelper.SelectRadioOptionByText(RadioLabels, "Send a request to my training provider");
            return this;
        }

        public EmployerSelectStandardPage NonLevyEmployerAddsApprentices()
        {
            EmployerAgreesToAdds();
            Continue();
            return new EmployerSelectStandardPage(context);
        }

        public EmployerSelectStandardPage DynamicHomePageNonLevyEmployerAddsApprentices()
        {
            EmployerAgreesToAdds();
            Continue();
            return new EmployerSelectStandardPage(context);
        }
    }
}
