using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderRolesApprenticeRequetsSteps
    {
        private readonly ScenarioContext _context;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly ApprenticeDataHelper _dataHelper;
        private readonly ProviderRoleApprenticeDataHelper _providerRoleApprenticeDataHelper;

        public ProviderRolesApprenticeRequetsSteps(ScenarioContext context)
        {
            _context = context;
            _providerStepsHelper = new ProviderStepsHelper(context);
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _providerRoleApprenticeDataHelper = new ProviderRoleApprenticeDataHelper();
        }
      
        [When(@"the user clicks on apprentice request link from homepage or apprentice request link")]
        public void WhenTheUserClicksOnApprenticeRequestLinkFromHomepageOrApprenticeRequestLink()
        {
            _providerStepsHelper.NavigateToProviderHomePage()
                               .GoToApprenticeRequestsPage();
        }

        [Then(@"the user can view apprentice details ready for review page when user clicks on with employer box")]
        public void ThenTheUserCanViewApprenticeDetailsReadyForReviewPageWhenUserClicksOnWithEmployerBox()
        {
            new ProviderApprenticeRequestsPage(_context, true).GoToCohortsWithEmployers()
                                                        .SelectViewCurrentCohortDetails();
        }

        [Then(@"the user can view apprentice details ready for review page when user clicks on drafts box")]
        public void ThenTheUserCanViewApprenticeDetailsReadyForReviewPageWhenUserClicksOnDraftsBox()
        {
            new ProviderApprenticeRequestsPage(_context, true).GoToDraftCohorts()
                                                        .SelectViewCurrentCohortDetails();
        }

        [Then(@"the user can view apprentice details ready for review page when user clicks on with transfer sending employers box")]
        public void ThenTheUserCanViewApprenticeDetailsReadyForReviewPageWhenUserClicksOnWithTransferSendingEmployersBox()
        {
            new ProviderApprenticeRequestsPage(_context, true).GoToCohortsWithTransferSendingEmployers()
                                                        .SelectViewCurrentCohortDetails();
        }

        [Then(@"the user can view view your cohort page by clicking view link on view your cohort page selecting the employers box")]
        public void ThenTheUserCanViewViewYourCohortPageByClickingViewLinkOnViewYourCohortPageSelectingTheEmployersBox()
        {
            new ProviderApprenticeRequestsPage(_context, true).GoToCohortsWithTransferSendingEmployers()
                                                        .SelectViewCurrentCohortDetails();
        }

        [Then(@"the user can view view your cohort page by clicking view link on view your cohort page selecting with transfer sending employers box")]
        public void ThenTheUserCanViewViewYourCohortPageByClickingViewLinkOnViewYourCohortPageSelectingWithTransferSendingEmployersBox()
        {
            new ProviderApprenticeRequestsPage(_context, true).GoToCohortsWithTransferSendingEmployers()
                                                        .SelectViewCurrentCohortDetails();
        }


        [Then(@"the user can view review your cohort page when user clicks on details link from apprentice details ready for review page selecting with employers box")]
        public void ThenTheUserCanViewReviewYourCohortPageWhenUserClicksOnDetailsLinkFromApprenticeDetailsReadyForReviewPageSelectingWithEmployersBox()
        {
            new ProviderApprenticeRequestsPage(_context, true).GoToCohortsToReviewPage();
        }

        [Then(@"the user can view review your cohort page when user clicks on details link from apprentice details ready for review page selecting drafts box")]
        public void ThenTheUserCanViewReviewYourCohortPageWhenUserClicksOnDetailsLinkFromApprenticeDetailsReadyForReviewPageSelectingDraftsBox()
        {
            new ProviderApprenticeRequestsPage(_context, true).GoToDraftCohorts()
                                                        .SelectViewCurrentCohortDetails();
        }        

        [Then(@"the user cannot edit an apprentice in a cohort")]
        public void ThenTheUserCannotEditAnApprenticeInACohort()
        {

            var editLinkPresent = new ProviderApprenticeRequestsPage(_context, true).GoToCohortsToReviewPage()
                                                        .SelectViewCurrentCohortDetails()
                                                        .IsEditApprenticeLinkDisplayed();

            if (editLinkPresent)
            {
                new ProviderApprenticeRequestsPage(_context, true).GoToCohortsToReviewPage()
                                                        .SelectViewCurrentCohortDetails()
                                                        .SelectEditApprenticeGoesToAccessDenied()
                                                        .GoBackToTheServiceHomePage();

            }
                                                       
        }

        [Then(@"the user cannot bulk upload apprentices via csv file")]
        public void ThenTheUserCannotBulkUploadApprenticesViaCsvFile()
        {
            _providerStepsHelper.NavigateToProviderHomePage()
                .GotoSelectJourneyPageGoesToAccessDenied()
                .GoBackToTheServiceHomePage();
        }


        [Then(@"the user cannot send a cohort to employer")]
        public void ThenTheUserCannotSendACohortToEmployer()
        {
            new ProviderApprenticeRequestsPage(_context, true).GoToCohortsToReviewPage()
                                                        .SelectViewCurrentCohortDetails()
                                                        .SelectAddAnApprenticeGoesToAccessDenied()
                                                        .GoBackToTheServiceHomePage();
        }

        [Then(@"the user cannot delete a cohort")]
        public void ThenTheUserCannotDeleteACohort()
        {
            new ProviderApprenticeRequestsPage(_context, true).GoToCohortsToReviewPage()
                                                        .SelectViewCurrentCohortDetails()
                                                        .SelectDeleteCohortGoesToAccessDenied()
                                                        .GoBackToTheServiceHomePage();
        }

        [Then(@"the user can add apprentice to a cohort")]
        public void ThenTheUserCanAddApprenticeToACohort()
        {          
            new ProviderApprenticeRequestsPage(_context, true).GoToCohortsToReviewPage()
                                                     .SelectViewCurrentCohortDetails()
                                                     .SelectAddAnApprentice();                                                   
        }

        [Then(@"the user can bulk upload apprentices")]
        public void ThenTheUserCanBulkUploadApprentices()
        {
            _providerStepsHelper.NavigateToProviderHomePage()
                 .GotoSelectJourneyPage()
                 .SelectBulkUpload()
                 .ContinueToUploadCsvFilePage();
        }

        [Then(@"the user can edit an existing apprenticeship record by selecting edit apprentice link selecting with employers or drafts boxes")]
        public void ThenTheUserCanEditAnExistingApprenticeshipRecordBySelectingEditApprenticeLinkSelectingWithEmployersOrDraftsBoxes()
        {

            var editLinkPresent = new ProviderApprenticeRequestsPage(_context, true).GoToCohortsToReviewPage()
                                                        .SelectViewCurrentCohortDetails()
                                                        .IsEditApprenticeLinkDisplayed();

            if (editLinkPresent)
            {
                new ProviderApprenticeRequestsPage(_context, true).GoToCohortsToReviewPage()
                                                        .SelectViewCurrentCohortDetails()
                                                        .SelectEditApprentice()
                                                        .EnterUlnAndSave(false);

            }
        }

        [Then(@"the user can delete a cohort")]
        public void ThenTheUserCanDeleteACohort()
        {
           
            bool canDeleteCohort = new ProviderApprenticeRequestsPage(_context, true)
                                                        .GoToDraftCohorts()
                                                        .SelectViewCurrentCohortDetails()
                                                        .SelectDeleteCohort()
                                                        .IsDeleteOptionDisplayed();

            if (!canDeleteCohort)
                throw new Exception("unable to find option to delete cohort!");
            
        }

        [Then(@"the user can delete an apprentice in a cohort")]
        public void ThenTheUserCanDeleteAnApprenticeInACohort()
        {
            var editLinkPresent = new ProviderApprenticeRequestsPage(_context, true).GoToCohortsToReviewPage()
                                                        .SelectViewCurrentCohortDetails()
                                                        .IsEditApprenticeLinkDisplayed();

            if (editLinkPresent)
            {              
                new ProviderApprenticeRequestsPage(_context, true).GoToCohortsToReviewPage()
                                                       .SelectViewCurrentCohortDetails()
                                                       .SelectEditApprentice()
                                                       .DeleteApprentice();
            }
        }

        [Then(@"the user can send a cohort to employer")]
        public void ThenTheUserCanSendACohortToEmployer()
        {
            new ProviderApprenticeRequestsPage(_context, true).GoToDraftCohorts()
                                                        .SelectViewCurrentCohortDetails()
                                                        .SubmitSaveButDontSendToEmployer();                                                        
        }
    }
}
