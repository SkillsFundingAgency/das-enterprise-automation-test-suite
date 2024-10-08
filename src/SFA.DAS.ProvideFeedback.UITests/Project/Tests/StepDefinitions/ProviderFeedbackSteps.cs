using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.ProvideFeedback.UITests.Project.Models;
using SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ProviderLogin.Service.Project;
using TechTalk.SpecFlow.Assist;

namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderFeedbackSteps(ScenarioContext context)
    {
        [When(@"The provider logs in to the provider portal")]
        public void GivenTheProviderLogsInToTheProviderPortal()
        {
            var providerCommonStepsHelper = new ProviderCommonStepsHelper(context);
            providerCommonStepsHelper.GoToProviderHomePage(false);
        }

        [When(@"the provider opts to view their feedback")]
        public void WhenTheProviderOptsToViewTheirFeedback()
        {
            var homePage = new FeedbackProviderHomePage(context);
            homePage.SelectYourFeedback();
        }

        [Given(@"the provider has been rated by apprentices as follows")]
        public void GivenTheProviderHasBeenRatedByApprenticesAsFollows(Table table)
        {
            var objectContext = context.Get<ObjectContext>();
            var dbConfig = context.Get<DbConfig>();
            var providerConfig = context.GetProviderConfig<ProviderConfig>();
            var ukprn = providerConfig.Ukprn;
            var providerName = providerConfig.Name;

            var sqlHelper = new ApprenticeFeedbackSqlHelper(objectContext, dbConfig);

            var data = table.CreateSet<ProviderRating>().ToList();

            sqlHelper.ClearProviderFeedback(ukprn);
            var apprenticeshipId = 0;
            foreach (var rating in data)
            {
                apprenticeshipId++;
                sqlHelper.CreateApprenticeProviderFeedback(apprenticeshipId, ukprn, providerName, rating);
            }
            sqlHelper.GenerateFeedbackSummaries();
        }

        [Given(@"the provider has been rated by employers as follows")]
        public void GivenTheProviderHasBeenRatedByEmployersAsFollows(Table table)
        {
            var objectContext = context.Get<ObjectContext>();
            var dbConfig = context.Get<DbConfig>();
            var providerConfig = context.GetProviderConfig<ProviderConfig>();
            var ukprn = providerConfig.Ukprn;

            var sqlHelper = new EmployerFeedbackSqlHelper(objectContext, dbConfig);

            var data = table.CreateSet<ProviderRating>().ToList();

            sqlHelper.ClearProviderFeedback(ukprn);
            var accountId = 0;
            foreach (var rating in data)
            {
                accountId++;
                sqlHelper.CreateEmployerProviderFeedback(ukprn, accountId, rating);
            }
            sqlHelper.GenerateFeedbackSummaries();
        }


        [Then(@"their overall apprentice feedback score is '([^']*)'")]
        public void ThenTheirOverallScoreIs(string rating)
        {
            var summaryPage = new FeedbackOverviewPage(context);
            summaryPage.VerifyApprenticeFeedbackRating("All", rating);
        }


        [When(@"they select the apprentice feedback tab for the current academic year")]
        public void WhenTheySelectTheTabForTheCurrentAcademicYear()
        {
            var academicYearHelper = new AcademicYearHelper();
            var academicYear = academicYearHelper.GetCurrentAcademicYear();

            var objectContext = context.Get<ObjectContext>();
            objectContext.Set("academic-year", academicYear);

            var summaryPage = new FeedbackOverviewPage(context);
            summaryPage.SelectApprenticeTabForAcademicYear(academicYear);
        }

        [When(@"they select the apprentice feedback tab for the previous academic year")]
        public void WhenTheySelectTheTabForThePreviousAcademicYear()
        {
            var academicYearHelper = new AcademicYearHelper();
            var academicYear = academicYearHelper.GetPreviousAcademicYear();

            var objectContext = context.Get<ObjectContext>();
            objectContext.Replace("academic-year", academicYear);

            var summaryPage = new FeedbackOverviewPage(context);
            summaryPage.SelectApprenticeTabForAcademicYear(academicYear);
        }


        [Then(@"their apprentice feedback score for that year is '([^']*)'")]
        public void ThenTheirScoreForThatYearIs(string rating)
        {
            var objectContext = context.Get<ObjectContext>();
            var academicYear = objectContext.Get("academic-year");

            var summaryPage = new FeedbackOverviewPage(context);
            summaryPage.VerifyApprenticeFeedbackRating(academicYear, rating);
        }
    }
}
