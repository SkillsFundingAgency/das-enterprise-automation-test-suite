using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class StartAddingApprenticesPage : BasePage
    {
        protected override string PageTitle => "Start adding apprentices";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public StartAddingApprenticesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

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
            _formCompletionHelper.SelectRadioOptionByText(RadioLabels, "I will add apprentices");
            return this;
        }

        private StartAddingApprenticesPage EmployerSendsToProviderToAdd()
        {
            _formCompletionHelper.SelectRadioOptionByText(RadioLabels, "I would like my provider to add apprentices");
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