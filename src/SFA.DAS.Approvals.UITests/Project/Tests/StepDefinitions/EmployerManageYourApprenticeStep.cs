using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
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

        [Given(@"A Employer has navigated to Manage your apprentice page")]
        public void GivenAEmployerHasNavigatedToManageYourApprenticePage()
        {
            _loginHelper.Login(_context.GetUser<LevyUser>(), true);
            _employerStepsHelper.GoToManageYourApprenticesPage();
        }
        
        [When(@"the employer filters by '(.*)'")]
        public void WhenTheEmployerFiltersBy(string filterselection)
        {
            _employerStepsHelper.FilterAndPaginate(filterselection);
        }
        
        [Then(@"the employer is presented with first page with no filters applied")]
        public void ThenTheEmployerIsPresentedWithFirstPageWithNoFiltersApplied()
        {           
            var linkDisplayed = _employerStepsHelper.VerifyDownloadAllLinkIsDisplayed();

            Assert.IsTrue(linkDisplayed, "Download all data");
        }
    }
}
