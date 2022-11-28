using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FlexiPayments.E2ETests.Project.Helpers;
using SFA.DAS.FlexiPayments.E2ETests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.FlexiPayments.E2ETests.Project.Tests.TestSupport;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.TestDataExport.Helper;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FlexiPaymentsSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private EmployerStepsHelper _employerStepsHelper;
        private readonly CommitmentsSqlDataHelper _commitmentsSqlDataHelper;
        private readonly EarningsSqlDbHelper _earningsSqlDbHelper;

        public FlexiPaymentsSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _employerStepsHelper = new EmployerStepsHelper(_context);
            _commitmentsSqlDataHelper = new CommitmentsSqlDataHelper(context.Get<DbConfig>());
            _earningsSqlDbHelper = context.Get<EarningsSqlDbHelper>();
        }

        [Given(@"Employer adds apprentices to the cohort with the following details")]
        public void GivenEmployerAddsApprenticesToTheCohortWithTheFollowingDetails(Table table)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                var inputData = table.Rows[i].CreateInstance<FlexiPaymentsInputDataModel>();

                var apprenticeDatahelper = new ApprenticeDataHelper(new ApprenticePPIDataHelper(inputData.DateOfBirth), _objectContext, _context.Get<CommitmentsSqlDataHelper>(), inputData.AgreedPrice);

                var apprenticeCourseDataHelper = new ApprenticeCourseDataHelper(new RandomCourseDataHelper(), ApprenticeStatus.Live, inputData.ActualStartDate, inputData.PlannedEndDate, inputData.TrainingCode);

                _context.Replace<ApprenticeDataHelper>(apprenticeDatahelper);
                _context.Replace<ApprenticeCourseDataHelper>(apprenticeCourseDataHelper);

                if (i == 0) _employerStepsHelper.EmployerAddApprenticeFromHomePage();
                else _employerStepsHelper.EmployerAddAnotherApprenticeToCohort();

                _objectContext.Set($"ULN{inputData.ULNKey}", apprenticeDatahelper.Uln());
            }
            _objectContext.SetNoOfApprentices(table.RowCount);
        }

        [Then(@"validate the following data is created in the commitments database")]
        public void ThenValidateTheFollowingDataIsCreatedInTheCommitmentsDatabase(Table table)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                var inputCommitmentData = table.Rows[i].CreateInstance<FlexiPaymentsCommitmentsDataModel>();

                var commitmentDbData = _commitmentsSqlDataHelper.GetFlexiPaymentsCommitmentData(_objectContext.Get($"ULN{inputCommitmentData.ULNKey}"));

                Assert.That(inputCommitmentData.IsPilot, Is.EqualTo(Boolean.Parse(commitmentDbData.isPilot)), "Incorrect Pilot status found");
                Assert.That(inputCommitmentData.PriceEpisodeFromDate, Is.EqualTo(DateHelpers.TryParse(commitmentDbData.fromDate)), "Incorrect PriceEpisode From Date found");
                Assert.That(inputCommitmentData.PriceEpisodeToDate_Date, Is.EqualTo(DateHelpers.TryParse(commitmentDbData.toDate)), "Incorrect PriceEpisode To Date found");
                Assert.That(inputCommitmentData.PriceEpisodeCost, Is.EqualTo(double.Parse(commitmentDbData.cost)), "Incorrect PriceEpisode Cost found");
            }
        }

        [Then(@"validate the following data is created in the earnings database")]
        public void ThenValidateTheFollowingDataIsCreatedInTheEarningsDatabase(Table table)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                var inputEarningsData = table.Rows[i].CreateInstance<FlexiPaymentsEarningDataModel>();

                var earningsDbData = _earningsSqlDbHelper.GetEarnings(_objectContext.Get($"ULN{inputEarningsData.ULNKey}"));

                Assert.That(inputEarningsData.TotalOnProgramPayment, Is.EqualTo(double.Parse(earningsDbData.totalOnProgramPayment)), "Incorrect total on-program payment found");
                Assert.That(inputEarningsData.MonthlyOnProgramPayment, Is.EqualTo(double.Parse(earningsDbData.monthlyOnProgramPayment)), "Incorrect monthly on-program payment found");
                Assert.That(inputEarningsData.NumberOfDeliveryMonths, Is.EqualTo(Int32.Parse(earningsDbData.numberOfDeliveryMonths)), "Incorrect number of delivery months found");
            }
        }

    }
}
