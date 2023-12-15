using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerManageYourApprenticeStep(ScenarioContext context)
    {
        private readonly EmployerPortalLoginHelper _loginHelper = new(context);
        private ManageYourApprenticesPage _manageYourApprenticesPage;
        private readonly ApprenticeHomePageStepsHelper _apprenticeHomePageStepsHelper = new(context);

        [Given(@"An employer has navigated to Manage your apprentice page")]
        public void AnEmployerHasNavigatedToManageYourApprenticePage()
        {
            _loginHelper.Login(context.GetUser<LevyUser>(), true);

            _manageYourApprenticesPage = _apprenticeHomePageStepsHelper.GoToManageYourApprenticesPage();
        }

        [Given(@"the employer filters by '(.*)'")]
        [When(@"the employer filters by '(.*)'")]
        public void TheEmployerFiltersBy(string filterselection) => _manageYourApprenticesPage.Filter(filterselection);

        [Then(@"the employer is presented with first page with filters applied")]
        public void TheEmployerIsPresentedWithFirstPageWithFiltersApplied() => Assert.IsTrue(_manageYourApprenticesPage.DownloadFilteredDataLinkIsDisplayed(), "Download filtered data");
    }
}
