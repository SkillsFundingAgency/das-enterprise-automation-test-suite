using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class StartAddingApprenticesPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Start adding apprentices";
        protected override By ContinueButton => By.Id("continue-button");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public StartAddingApprenticesPage(ScenarioContext context) : base(context) => _context = context;

        public AddApprenticeDetailsPage EmployerAddsApprentices()
        {
            EmployerAgreesToAdds();
            Continue();
            return new AddApprenticeDetailsPage(_context);
        }

        public MessageForYourTrainingProviderPage EmployerSendsToProviderToAddApprentices()
        {
            EmployerSendsToProviderToAdd();
            Continue();
            return new MessageForYourTrainingProviderPage(_context);
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
            return new AddApprenticeDetailsPage(_context);
        }
        public ChooseAReservationPage DynamicHomePageNonLevyEmployerAddsApprentices()
        {
            EmployerAgreesToAdds();
            Continue();
            return new ChooseAReservationPage(_context);
        }
    }
}
