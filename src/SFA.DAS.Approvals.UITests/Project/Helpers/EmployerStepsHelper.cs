using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers
{
    internal class EmployerStepsHelper
    {
        private readonly AssertHelper _assertHelper;
        private readonly EmployerPortalLoginHelper _loginHelper;
        private readonly TabHelper _tabHelper;
        private readonly ObjectContext _objectContext;
        private readonly ScenarioContext _context;
        private readonly ProjectConfig _projectConfig;

        internal EmployerStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _assertHelper = _context.Get<AssertHelper>();
            _projectConfig = _context.GetProjectConfig<ProjectConfig>();
            _tabHelper = _context.Get<TabHelper>();
            _loginHelper = new EmployerPortalLoginHelper(_context);
        }

        internal ApprenticesHomePage GoToEmployerApprenticesHomePage()
        {
            _tabHelper.OpenInNewtab(_projectConfig.RE_BaseUrl);

            if (_loginHelper.IsSignInPageDisplayed())
            {
                _loginHelper.ReLogin();
            }

            return new ApprenticesHomePage(_context, true);
        }

        internal EditedApprenticeDetailsPage ApproveChangesAndSubmit(ApprenticeDetailsPage apprenticeDetailsPage)
        {
            return apprenticeDetailsPage
                .ClickReviewChanges()
                .SelectApproveChangesAndSubmit();
        }

        internal ApprenticeDetailsPage ViewCurrentApprenticeDetails()
        {
            return GoToEmployerApprenticesHomePage()
                    .ClickManageYourApprenticesLink()
                    .SelectViewCurrentApprenticeDetails();
        }

        internal EditApprenticePage EditApprenticeDetailsPagePostApproval()
        {
            return ViewCurrentApprenticeDetails()
                .ClickEditApprenticeDetailsLink();
        }

        internal ReviewYourCohortPage EmployerReviewCohort()
        {
            var employerReviewYourCohortPage = GoToEmployerApprenticesHomePage()
                .ClickYourCohortsLink()
                .GoToCohortsReadyForReview()
                .SelectViewCurrentCohortDetails();

            _objectContext.SetApprenticeTotalCost(SetApprenticeTotalCost(employerReviewYourCohortPage));

            return employerReviewYourCohortPage;
        }

        internal void EmployerCreateCohortAndSendsToProvider()
        {
            var cohortSentYourTrainingProviderPage = EmployerCreateCohort();
            var cohortReference = cohortSentYourTrainingProviderPage.CohortReference();
            SetCohortReference(cohortReference);
        }

        internal ReviewYourCohortPage EmployerAddApprentice(int numberOfApprentices)
        {
          var employerReviewYourCohortPage = ConfirmProviderDetailsAreCorrect(new ApprenticesHomePage(_context, true))
                .EmployerAddsApprentices();
            return AddApprentices(employerReviewYourCohortPage, numberOfApprentices);
        }

        internal string EmployerApproveAndSendToProvider(ReviewYourCohortPage employerReviewYourCohortPage)
        {
            return employerReviewYourCohortPage.SaveAndContinue()
                .SubmitApproveAndSendToTrainingProvider()
                .SendInstructionsToProviderForAnApprovedCohort()
                .CohortReference();
        }

        internal void SetCohortReference(string cohortReference)
        {
            _objectContext.SetCohortReference(cohortReference);

            TestContext.Progress.WriteLine($"Cohort Reference: {cohortReference}");
        }

        internal string SetApprenticeTotalCost(ReviewYourCohortPage employerReviewYourCohortPage)
        {
            string apprenticeTotalCost = string.Empty;

            _assertHelper.RetryOnNUnitException(() =>
            {
                apprenticeTotalCost = employerReviewYourCohortPage.ApprenticeTotalCost();

                Assert.AreNotEqual("£0", apprenticeTotalCost, "Apprentice cost is not added");
            });

            return apprenticeTotalCost;
        }

        internal string SetNoOfApprentice(ReviewYourCohortPage employerReviewYourCohortPage, int count)
        {
            string noOfApprentice = string.Empty;

            _assertHelper.RetryOnNUnitException(() =>
            {
                noOfApprentice = employerReviewYourCohortPage.NoOfApprentice();

                Assert.AreEqual(count.ToString(), noOfApprentice, "Apprentice count is not added");
            });

            return noOfApprentice;
        }

        private StartAddingApprenticesPage ConfirmProviderDetailsAreCorrect(ApprenticesHomePage apprenticesHomePage)
        {
            return apprenticesHomePage
                .AddAnApprentice()
                .StartNow()
                .SubmitValidUkprn()
                .ConfirmProviderDetailsAreCorrect();
        }

        private ReviewYourCohortPage AddApprentices(ReviewYourCohortPage employerReviewYourCohortPage, int numberOfApprentices)
        {
            string noOfApprentice = string.Empty, apprenticeTotalCost = string.Empty;

            for (int i = 1; i <= numberOfApprentices; i++)
            {
                var x = AddAnApprentice(employerReviewYourCohortPage, i);
                noOfApprentice = x.noOfApprentice;
                apprenticeTotalCost = x.apprenticeTotalCost;
            }

            _objectContext.SetNoOfApprentices(noOfApprentice);
            _objectContext.SetApprenticeTotalCost(apprenticeTotalCost);

            return employerReviewYourCohortPage;
        }
        private (string noOfApprentice, string apprenticeTotalCost) AddAnApprentice(ReviewYourCohortPage employerReviewYourCohortPage, int count)
        {
            employerReviewYourCohortPage
                .SelectAddAnApprentice()
                .SubmitValidApprenticeDetails();

            string apprenticeTotalCost = SetApprenticeTotalCost(employerReviewYourCohortPage);

            string noOfApprentice = SetNoOfApprentice(employerReviewYourCohortPage, count);

            return (noOfApprentice, apprenticeTotalCost);
        }
        private CohortSentYourTrainingProviderPage EmployerCreateCohort()
        {
            return ConfirmProviderDetailsAreCorrect(new ApprenticesHomePage(_context, true))
               .EmployerSendsToProviderToAddApprentices()
               .SendInstructionsToProviderForEmptyCohort();
        }
    }
}
