using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class StartAddingApprenticesPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Start adding apprentices";
        protected override bool TakeFullScreenShot => false;
        protected override By ContinueButton => By.Id("continue-button");
        private static By MessageBox => By.Name("message");

        public SelectStandardPage EmployerAddsApprentices()
        {
            EmployerAgreesToAdds();
            Continue();
            return new SelectStandardPage(context);
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
            formCompletionHelper.SelectRadioOptionByText(RadioLabels, "I will add apprentices");
            return this;
        }

        private StartAddingApprenticesPage EmployerSendsToProviderToAdd()
        {
            formCompletionHelper.SelectRadioOptionByText(RadioLabels, "I would like my provider to add apprentices");
            return this;
        }

        public SelectStandardPage NonLevyEmployerAddsApprentices()
        {
            EmployerAgreesToAdds();
            Continue();
            return new SelectStandardPage(context);
        }

        public ChooseAReservationPage DynamicHomePageNonLevyEmployerAddsApprentices()
        {
            EmployerAgreesToAdds();
            Continue();
            return new ChooseAReservationPage(context);
        }
    }
}
