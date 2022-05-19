using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class StartAddingApprenticesPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Start adding apprentices";

        protected override bool TakeFullScreenShot => false;

        protected override By ContinueButton => By.Id("continue-button");

        public StartAddingApprenticesPage(ScenarioContext context) : base(context)  { }

        public SelectStandardPage EmployerAddsApprentices()
        {
            EmployerAgreesToAdds();
            Continue();
            return new SelectStandardPage(context);
        }

        public MessageForYourTrainingProviderPage EmployerSendsToProviderToAddApprentices()
        {
            EmployerSendsToProviderToAdd();
            Continue();
            return new MessageForYourTrainingProviderPage(context);
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

        public AddApprenticeDetailsPage NonLevyEmployerAddsApprentices()
        {
            EmployerAgreesToAdds();
            Continue();
            return new AddApprenticeDetailsPage(context);
        }
        public ChooseAReservationPage DynamicHomePageNonLevyEmployerAddsApprentices()
        {
            EmployerAgreesToAdds();
            Continue();
            return new ChooseAReservationPage(context);
        }
    }
}
