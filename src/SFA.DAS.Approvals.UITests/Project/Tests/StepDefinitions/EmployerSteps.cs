using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ProjectConfig _projectConfig;
        private readonly AddAnApprenticeHelper _addAnApprenticeHelper;
        private readonly TabHelper _tabHelper;
        private readonly LoginHelper _loginHelper;

        public EmployerSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _projectConfig = context.GetProjectConfig<ProjectConfig>();
            var assertHelper = _context.Get<AssertHelper>();
            _tabHelper = new TabHelper(context.GetWebDriver());
            _addAnApprenticeHelper = new AddAnApprenticeHelper(assertHelper);
            _loginHelper = new LoginHelper(context);
        }

        [When(@"the Employer adds (.*) cohort and sends to provider")]
        public void WhenTheEmployerAddsCohortAndSendsToProvider(int numberOfApprentices)
        {
            var employerReviewYourCohortPage = _addAnApprenticeHelper.EmployerNavigateToAddAnApprentice(new ApprenticesHomePage(_context, true));

            employerReviewYourCohortPage = _addAnApprenticeHelper.AddApprentices(employerReviewYourCohortPage, numberOfApprentices, _objectContext);

            var cohortReference = employerReviewYourCohortPage.SaveAndContinue()
                .SubmitSendToTrainingProviderForReview()
                .SendInstructionsToProviderForCohortToBeReviewed()
                .CohortReference();

            _addAnApprenticeHelper.SetCohortReference(_objectContext, cohortReference);
        }

        [Then(@"the Employer approves the cohorts")]
        public void ThenTheEmployerApprovesTheCohorts()
        {
            _tabHelper.OpenInNewtab(_projectConfig.RE_BaseUrl);

            if (_loginHelper.IsIndexPageDisplayed())
            {
                var loginUsername = _objectContext.GetLoginUsername();
                var loginpassword = _objectContext.GetLoginPassword();

                _loginHelper.Login(new LoggedInUser { Username = loginUsername, Password = loginpassword });
            }
            
            var employerReviewYourCohortPage = new ApprenticesHomePage(_context, true)
                .ClickYourCohortsLink()
                .GoToCohortsReadyForReview()
                .SelectViewCurrentCohortDetails();

            _addAnApprenticeHelper.SetApprenticeTotalCost(employerReviewYourCohortPage);

            employerReviewYourCohortPage.SelectContinueToApproval()
                .SubmitApprove();
        }
    }
}
