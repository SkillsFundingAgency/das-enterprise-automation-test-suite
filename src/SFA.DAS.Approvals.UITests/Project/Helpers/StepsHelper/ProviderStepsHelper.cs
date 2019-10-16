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

        public ProviderStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _tabHelper = new TabHelper(context.GetWebDriver());
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _login = new ProviderLogin { Username = _config.AP_ProviderUserId, Password = _config.AP_ProviderPassword, Ukprn = _config.AP_ProviderUkprn };
            _loginHelper = new ProviderPortalLoginHelper(_context);
            _reviewYourCohortStepsHelper = new ReviewYourCohortStepsHelper(_context.Get<AssertHelper>());
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

        public void AddApprenticeAndSendToEmployerForApproval(int numberOfApprentices)
        {
            var providerReviewYourCohortPage = AddApprentice(numberOfApprentices);

            providerReviewYourCohortPage.SelectSaveAndContinue()
                .SubmitApproveAndSendToEmployerForApproval()
                .SendInstructionsToEmployerForAnApprovedCohort();
        }

        public void AddApprenticeAndSavesWithoutSendingEmployerForApproval(int numberOfApprentices)
        {
            AddApprentice(numberOfApprentices)
                .SelectSaveAndContinue()
                .SubmitSaveButDontSendToEmployer();
        }

        public ProviderReviewYourCohortPage AddApprentice(int numberOfApprentices)
        {
            var providerReviewYourCohortPage = CurrentCohortDetails();

            for (int i = 0; i < numberOfApprentices; i++)
            {
                providerReviewYourCohortPage.SelectAddAnApprentice()
                        .SubmitValidApprenticeDetails();
            }

            _objectContext.SetNoOfApprentices(_reviewYourCohortStepsHelper.NoOfApprentice(providerReviewYourCohortPage, numberOfApprentices));
            _objectContext.SetApprenticeTotalCost(_reviewYourCohortStepsHelper.ApprenticeTotalCost(providerReviewYourCohortPage));

            return providerReviewYourCohortPage;
        }

        public ProviderReviewYourCohortPage CurrentCohortDetails()
        {
            return GoToProviderHomePage()
                    .GoToProviderYourCohortsPage()
                    .GoToCohortsToReviewPage()
                    .SelectViewCurrentCohortDetails();
        }

        public ProviderReviewYourCohortPage EditApprentice()
        {
            var providerReviewYourCohortPage = CurrentCohortDetails();

            var totalNoOfApprentices = providerReviewYourCohortPage.TotalNoOfApprentices();

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

        public ProviderReviewYourCohortPage EditAllDetailsOfApprentice()
        {
            var providerReviewYourCohortPage = CurrentCohortDetails();

            var totalNoOfApprentices = providerReviewYourCohortPage.TotalNoOfApprentices();

            for (int i = 0; i < totalNoOfApprentices; i++)
                providerReviewYourCohortPage = providerReviewYourCohortPage.SelectEditApprentice(i)
                                         .EditAllApprenticeDetails();

            return providerReviewYourCohortPage;
        }

        public ProviderReviewYourCohortPage DeleteApprentice()
        {
            var providerReviewYourCohortPage = new ProviderReviewYourCohortPage(_context);
            var totalNoOfApprentices = providerReviewYourCohortPage.TotalNoOfApprentices();

            for (int i = 0; i < totalNoOfApprentices; i++)
                providerReviewYourCohortPage.SelectEditApprentice(0)
                                          .DeleteApprentice()
                                          .ConfirmDeleteAndSubmit();

            return new ProviderReviewYourCohortPage(_context);
        }

        public void DeleteCohort()
        {
            var providerReviewYourCohortPage = new ProviderReviewYourCohortPage(_context);

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
    }
}
