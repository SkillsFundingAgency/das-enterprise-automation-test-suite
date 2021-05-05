using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
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
                               .GoToYourCohorts();
        }

        [Then(@"the user can view apprentice details ready for review page when user clicks on with employer box")]
        public void ThenTheUserCanViewApprenticeDetailsReadyForReviewPageWhenUserClicksOnWithEmployerBox()
        {
            new ProviderYourCohortsPage(_context, true).GoToCohortsWithEmployers()
                                                        .SelectViewCurrentCohortDetails();
        }

        [Then(@"the user can view apprentice details ready for review page when user clicks on drafts box")]
        public void ThenTheUserCanViewApprenticeDetailsReadyForReviewPageWhenUserClicksOnDraftsBox()
        {
            new ProviderYourCohortsPage(_context, true).GoToDraftCohorts()
                                                        .SelectViewCurrentCohortDetails();
        }

        [Then(@"the user can view apprentice details ready for review page when user clicks on with transfer sending employers box")]
        public void ThenTheUserCanViewApprenticeDetailsReadyForReviewPageWhenUserClicksOnWithTransferSendingEmployersBox()
        {
            new ProviderYourCohortsPage(_context, true).GoToCohortsWithTransferSendingEmployers()
                                                        .SelectViewCurrentCohortDetails();
        }

        [Then(@"the user can view view your cohort page by clicking view link on view your cohort page selecting the employers box")]
        public void ThenTheUserCanViewViewYourCohortPageByClickingViewLinkOnViewYourCohortPageSelectingTheEmployersBox()
        {
            new ProviderYourCohortsPage(_context, true).GoToCohortsWithTransferSendingEmployers()
                                                        .SelectViewCurrentCohortDetails()
                                                        .SelectViewApprentice();
        }

        [Then(@"the user can view view your cohort page by clicking view link on view your cohort page selecting with transfer sending employers box")]
        public void ThenTheUserCanViewViewYourCohortPageByClickingViewLinkOnViewYourCohortPageSelectingWithTransferSendingEmployersBox()
        {
            new ProviderYourCohortsPage(_context, true).GoToCohortsWithTransferSendingEmployers()
                                                        .SelectViewCurrentCohortDetails()
                                                        .SelectViewApprentice();
        }


        [Then(@"the user can view review your cohort page when user clicks on details link from apprentice details ready for review page selecting with employers box")]
        public void ThenTheUserCanViewReviewYourCohortPageWhenUserClicksOnDetailsLinkFromApprenticeDetailsReadyForReviewPageSelectingWithEmployersBox()
        {
            new ProviderYourCohortsPage(_context, true).GoToCohortsToReviewPage()
                                                        .SelectViewCurrentCohortDetails();
        }

        [Then(@"the user can view review your cohort page when user clicks on details link from apprentice details ready for review page selecting drafts box")]
        public void ThenTheUserCanViewReviewYourCohortPageWhenUserClicksOnDetailsLinkFromApprenticeDetailsReadyForReviewPageSelectingDraftsBox()
        {
            new ProviderYourCohortsPage(_context, true).GoToDraftCohorts()
                                                        .SelectViewCurrentCohortDetails();
        }        

        [Then(@"the user cannot edit an apprentice in a cohort")]
        public void ThenTheUserCannotEditAnApprenticeInACohort()
        {

            var editLinkPresent = new ProviderYourCohortsPage(_context, true).GoToCohortsToReviewPage()
                                                        .SelectViewCurrentCohortDetails()
                                                        .IsEditApprenticeLinkDisplayed();

            if (editLinkPresent)
            {
                new ProviderYourCohortsPage(_context, true).GoToCohortsToReviewPage()
                                                        .SelectViewCurrentCohortDetails()
                                                        .SelectEditApprenticeGoesToAccessDenied()
                                                        .GoBackToTheServiceHomePage();

            }
                                                       
        }

        [Then(@"the user cannot bulk upload apprentices via csv file")]
        public void ThenTheUserCannotBulkUploadApprenticesViaCsvFile()
        {
            new ProviderYourCohortsPage(_context, true).GoToCohortsToReviewPage()
                                                        .SelectViewCurrentCohortDetails()
                                                        .SelectBulkUploadApprenticesGoesToAccessDenied()
                                                        .GoBackToTheServiceHomePage();
        }


        [Then(@"the user cannot send a cohort to employer")]
        public void ThenTheUserCannotSendACohortToEmployer()
        {
            new ProviderYourCohortsPage(_context, true).GoToCohortsToReviewPage()
                                                        .SelectViewCurrentCohortDetails()
                                                        .SelectAddAnApprenticeGoesToAccessDenied()
                                                        .GoBackToTheServiceHomePage();
        }

        [Then(@"the user cannot delete a cohort")]
        public void ThenTheUserCannotDeleteACohort()
        {
            new ProviderYourCohortsPage(_context, true).GoToCohortsToReviewPage()
                                                        .SelectViewCurrentCohortDetails()
                                                        .SelectDeleteCohortGoesToAccessDenied()
                                                        .GoBackToTheServiceHomePage();
        }

        [Then(@"the user can add apprentice to a cohort")]
        public void ThenTheUserCanAddApprenticeToACohort()
        {          
            new ProviderYourCohortsPage(_context, true).GoToCohortsToReviewPage()
                                                     .SelectViewCurrentCohortDetails()
                                                     .SelectAddAnApprentice();                                                   
        }

        [Then(@"the user can bulk upload apprentices")]
        public void ThenTheUserCanBulkUploadApprentices()
        {
            new ProviderYourCohortsPage(_context, true).GoToCohortsToReviewPage()
                                                        .SelectViewCurrentCohortDetails()
                                                        .SelectBulkUploadApprentices();
        }

        [Then(@"the user can edit an existing apprenticeship record by selecting edit apprentice link selecting with employers or drafts boxes")]
        public void ThenTheUserCanEditAnExistingApprenticeshipRecordBySelectingEditApprenticeLinkSelectingWithEmployersOrDraftsBoxes()
        {

            var editLinkPresent = new ProviderYourCohortsPage(_context, true).GoToCohortsToReviewPage()
                                                        .SelectViewCurrentCohortDetails()
                                                        .IsEditApprenticeLinkDisplayed();

            if (editLinkPresent)
            {
                new ProviderYourCohortsPage(_context, true).GoToCohortsToReviewPage()
                                                        .SelectViewCurrentCohortDetails()
                                                        .SelectEditApprentice()
                                                        .EnterUlnAndSave();

            }
        }

        [Then(@"the user can delete a cohort")]
        public void ThenTheUserCanDeleteACohort()
        {
           
            new ProviderYourCohortsPage(_context, true).GoToDraftCohorts()
                                                        .SelectViewCurrentCohortDetails()
                                                        .SelectDeleteCohort()
                                                        .ConfirmDeleteAndSubmit();            
        }

        [Then(@"the user can delete an apprentice in a cohort")]
        public void ThenTheUserCanDeleteAnApprenticeInACohort()
        {
            var editLinkPresent = new ProviderYourCohortsPage(_context, true).GoToCohortsToReviewPage()
                                                        .SelectViewCurrentCohortDetails()
                                                        .IsEditApprenticeLinkDisplayed();

            if (editLinkPresent)
            {              
                new ProviderYourCohortsPage(_context, true).GoToCohortsToReviewPage()
                                                       .SelectViewCurrentCohortDetails()
                                                       .SelectEditApprentice()
                                                       .DeleteApprentice();
            }
        }

        [Then(@"the user can send a cohort to employer")]
        public void ThenTheUserCanSendACohortToEmployer()
        {
            new ProviderYourCohortsPage(_context, true).GoToDraftCohorts()
                                                        .SelectViewCurrentCohortDetails()
                                                        .SelectSaveAndContinue()
                                                        .SubmitSaveButDontSendToEmployer();                                                        
        }
    }
}
