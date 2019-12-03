using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper
{
    public class ProviderStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly TabHelper _tabHelper;
        private readonly ApprovalsConfig _config;
        private readonly ProviderPortalLoginHelper _loginHelper;
        private readonly ReviewYourCohortStepsHelper _reviewYourCohortStepsHelper;
        private readonly ProviderLogin _login;
		private readonly ProviderAddApprenticeDetailsPage _providerAddApprenticeDetailsPage;

		public ProviderStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _tabHelper = _context.Get<TabHelper>();
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _login = new ProviderLogin { Username = _config.AP_ProviderUserId, Password = _config.AP_ProviderPassword, Ukprn = _config.AP_ProviderUkprn };
            _loginHelper = new ProviderPortalLoginHelper(_context);
			_reviewYourCohortStepsHelper = new ReviewYourCohortStepsHelper(_context.Get<AssertHelper>());
        }

        public ProviderHomePage NavigateToProviderHomePage()
        {
            return new ProviderHomePage(_context, true);
        }

        public ProviderHomePage GoToProviderHomePage()
        {
            return GoToProviderHomePage(_login);
        }

        public ProviderHomePage GoToProviderHomePage(ProviderLogin login)
        {
            _tabHelper.OpenInNewtab(_config.ProviderBaseUrl);

            _objectContext.SetUkprn(login.Ukprn);

            if (_loginHelper.IsSignInPageDisplayed())
            {
                return _loginHelper.ReLogin(login);
            }
            else if (_loginHelper.IsIndexPageDisplayed())
            {
                return _loginHelper.Login(login);
            }
            return new ProviderHomePage(_context);
        }

        public ProviderAddApprenticeDetailsPage ProviderMakeReservation(ProviderLogin login)
        {
            return GoToProviderHomePage(login)
                   .GoToProviderGetFunding()
                   .StartReservedFunding()
                   .ChooseAnEmployerNonLevyEOI()
                   .ConfirmNonLevyEmployer()
                   .AddTrainingCourseAndDate()
                   .ConfirmReserveFunding()
                   .VerifySucessMessage()
                   .GoToAddApprenticeDetailsPage();
        }

        public void AddApprenticeAndSendToEmployerForApproval(int numberOfApprentices)
        {
            var providerReviewYourCohortPage = AddApprentice(numberOfApprentices);

            providerReviewYourCohortPage.SelectSaveAndContinue()
                .SubmitApproveAndSendToEmployerForApproval()
                .SendInstructionsToEmployerForAnApprovedCohort();
        }

        public ProviderReviewYourCohortPage AddApprenticeAndSavesWithoutSendingEmployerForApproval(int numberOfApprentices)
        {
           return AddApprentice(numberOfApprentices)
                .SelectSaveAndContinue()
                .SubmitSaveButDontSendToEmployer()
                .SelectViewCurrentCohortDetails();
        }

        public ProviderReviewYourCohortPage AddApprentice(ProviderAddApprenticeDetailsPage _providerAddApprenticeDetailsPage, int numberOfApprentices)
        {
            //var providerAddApprenticeDetailsPage = providerHomePage.GoToManageYourFunding().AddApprenticeWithReservedFunding();

            var providerReviewYourCohortPage = _providerAddApprenticeDetailsPage.SubmitValidApprenticeDetails();

            for (int i = 1; i < numberOfApprentices; i++)
            {
                providerReviewYourCohortPage = providerReviewYourCohortPage
                    .SelectAddAnApprenticeUsingReservation()
                    .CreateANewReservation()
                    .AddTrainingCourseAndDate()
                    .ConfirmReserveFunding()
                    .VerifySucessMessage()
                    .GoToAddApprenticeDetailsPage()
                    .SubmitValidApprenticeDetails();
            }

            return SetApprenticeDetails(providerReviewYourCohortPage, numberOfApprentices);
        }

        public ProviderReviewYourCohortPage AddApprentice(int numberOfApprentices)
        {
			var providerReviewYourCohortPage = CurrentCohortDetails();
			
            for(int i = 0; i < numberOfApprentices; i++)
            {	
				providerReviewYourCohortPage = providerReviewYourCohortPage.SelectAddAnApprentice()
                        .SubmitValidApprenticeDetails();
            }

            return SetApprenticeDetails(providerReviewYourCohortPage, numberOfApprentices);
        }

        public ProviderReviewYourCohortPage CurrentCohortDetails()
        {
            return GoToProviderHomePage()
                .GoToProviderYourCohortsPage()
                .GoToCohortsToReviewPage()
                .SelectViewCurrentCohortDetails();
        }

        public ProviderReviewYourCohortPage EditApprentice(ProviderReviewYourCohortPage providerReviewYourCohortPage)
        {
            var totalNoOfApprentices = _objectContext.GetNoOfApprentices();

            for (int i = 0; i < totalNoOfApprentices; i++)
            {
                int j = 0;
                var ulnFields = providerReviewYourCohortPage.ApprenticeUlns();
                foreach (IWebElement uln in ulnFields)
                {
                    if (uln.Text.Equals("–"))
                    {
                        providerReviewYourCohortPage = providerReviewYourCohortPage.SelectEditApprentice(j)
                                                      .EnterUlnAndSave();
                        break;
                    }
                    j++;
                }
            }

            return providerReviewYourCohortPage;
        }

        public ProviderReviewYourCohortPage EditApprentice()
        {
            return EditApprentice(CurrentCohortDetails());
        }

        public ProviderReviewYourCohortPage EditAllDetailsOfApprentice(ProviderReviewYourCohortPage providerReviewYourCohortPage)
        {
            var totalNoOfApprentices = _objectContext.GetNoOfApprentices();

            for (int i = 0; i < totalNoOfApprentices; i++)
                providerReviewYourCohortPage = providerReviewYourCohortPage.SelectEditApprentice(i)
                                         .EditAllApprenticeDetails();

            return providerReviewYourCohortPage;
        }

        public ProviderReviewYourCohortPage DeleteApprentice(ProviderReviewYourCohortPage providerReviewYourCohortPage)
        {
            var totalNoOfApprentices = _objectContext.GetNoOfApprentices();

            for (int i = 0; i < totalNoOfApprentices; i++)
            {
                providerReviewYourCohortPage = providerReviewYourCohortPage.SelectEditApprentice(0)
                                          .DeleteApprentice()
                                          .ConfirmDeleteAndSubmit();
            }

            return providerReviewYourCohortPage;
        }

        public void DeleteCohort(ProviderReviewYourCohortPage providerReviewYourCohortPage)
        {
            providerReviewYourCohortPage.SelectDeleteCohort()
                .ConfirmDeleteAndSubmit();
        }

        public void Approve()
        {
            EditApprentice()
                .SelectContinueToApproval()
                .SubmitApprove();
        }

        public void ApprovesTheCohortsAndSendsToEmployer()
        {
            EditApprentice()
                .SelectContinueToApproval()
                .SubmitApproveAndSendToEmployerForApproval()
                .SendInstructionsToEmployerForAnApprovedCohort();
        }

        public void ViewApprentices()
        {
            ProviderViewYourCohortPage _providerViewYourCohortPage = new ProviderViewYourCohortPage(_context);
            int totalApprentices = _providerViewYourCohortPage.TotalNoOfApprentices();
            for (int i = 0; i < totalApprentices; i++)
            {
                _providerViewYourCohortPage.SelectViewApprentice(i)
                    .SelectReturnToCohortView();
            }
        }

        private ProviderReviewYourCohortPage SetApprenticeDetails(ProviderReviewYourCohortPage providerReviewYourCohortPage, int numberOfApprentices)
        {
            _objectContext.SetNoOfApprentices(_reviewYourCohortStepsHelper.NoOfApprentice(providerReviewYourCohortPage, numberOfApprentices));
            _objectContext.SetApprenticeTotalCost(_reviewYourCohortStepsHelper.ApprenticeTotalCost(providerReviewYourCohortPage));

            return providerReviewYourCohortPage;
        }
    }
}
