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
            _login = new ProviderLogin { Username = _config.AP_ProviderLoginId, Password = _config.AP_ProviderLoginPassword, Ukprn = _config.AP_ProviderUkprn };
            _loginHelper = new ProviderPortalLoginHelper(_context);
            _reviewYourCohortStepsHelper = new ReviewYourCohortStepsHelper(_context.Get<AssertHelper>());
        }

        public ProviderHomePage GoToProviderHomePage()
        {
            return GoToProviderHomePage(_login);
        }

        public ProviderHomePage GoToProviderHomePage(ProviderLogin login)
        {
            _tabHelper.OpenInNewtab(_config.AP_ProviderAppUrl);

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
    }
}
