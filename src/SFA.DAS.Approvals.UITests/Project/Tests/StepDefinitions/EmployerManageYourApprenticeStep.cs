using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Login.Service.Project;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerManageYourApprenticeStep(ScenarioContext context)
    {
        private readonly EmployerPortalLoginHelper _loginHelper = new(context);
        private ManageYourLearnersPage _manageYourLearnersPage;
        private readonly ApprenticeHomePageStepsHelper _apprenticeHomePageStepsHelper = new(context);

        [Given(@"An employer has navigated to Manage your learners page")]
        public void AnEmployerHasNavigatedToManageYourLearnersPage()
        {
            _loginHelper.Login(context.GetUser<LevyUser>(), true);

            _manageYourLearnersPage = _apprenticeHomePageStepsHelper.GoToManageYourLearnersPage();
        }

        [Given(@"the employer filters by '(.*)'")]
        [When(@"the employer filters by '(.*)'")]
        public void TheEmployerFiltersBy(string filterselection) => _manageYourLearnersPage.Filter("selectedStatus", filterselection);

        [Then(@"the employer is presented with first page with filters applied")]
        public void TheEmployerIsPresentedWithFirstPageWithFiltersApplied() => Assert.IsTrue(_manageYourLearnersPage.DownloadFilteredDataLinkIsDisplayed(), "Download filtered data");

        [Then("Employer is able to download the results in a csv file")]
        public void ThenEmployerCanDownloadResultsInCSVFile()
        {
            _manageYourLearnersPage.Filter("selectedApprenticeConfirmation", "Confirmed");
            _manageYourLearnersPage.ClickOnDownloadFilteredDataCSVAndWaitForDownload();
        }

        [Then("Employer can confirm number of rows in Apprentices csv file")]
        public void ThenEmployerConfirmsNumberOfRowsInApprenticeCSV()
        {
            _manageYourLearnersPage.DoesDownloadFileExistAndValidateRowCount();
        }
    }
}
