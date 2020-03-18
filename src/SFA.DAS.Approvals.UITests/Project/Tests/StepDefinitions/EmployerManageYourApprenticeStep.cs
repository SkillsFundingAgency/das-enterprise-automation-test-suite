using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerManageYourApprenticeStep
    {
        private readonly ScenarioContext _context;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private EmployerPortalLoginHelper _loginHelper;

        public EmployerManageYourApprenticeStep(ScenarioContext context)
        {
            _context = context;
            _employerStepsHelper = new EmployerStepsHelper(context);   
            _loginHelper = new EmployerPortalLoginHelper(context);
        }

        [Given(@"An employer has navigated to Manage your apprentice page")]
        public void AnEmployerHasNavigatedToManageYourApprenticePage()
        {
            _loginHelper.Login(_context.GetUser<LevyUser>(), true);
            _employerStepsHelper.GoToManageYourApprenticesPage();
        }

        [Given(@"the employer filters by '(.*)'")]
        [When(@"the employer filters by '(.*)'")]
        public void TheEmployerFiltersBy(string filterselection)
        {
            _employerStepsHelper.Filter(filterselection);
        }

        [When(@"the employer click the back link on apprenticeship details page")]
        public void TheEmployerClicksOnBackLinkOnApprenticeshipDetails()
        {
            _employerStepsHelper.ClickApprenticeDetailsBackLink(new ApprenticeDetailsPage(_context, false));
        }

        [Then(@"the employer is presented with first page with filters applied")]
        public void TheEmployerIsPresentedWithFirstPageWithFiltersApplied()
        {
            Assert.IsTrue(_employerStepsHelper.VerifyDownloadFilteredLinkIsDisplayed(), "Download filtered data");
        }

    }
}
