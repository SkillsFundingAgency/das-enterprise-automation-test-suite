using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
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
        private readonly ApprenticeshipsSqlDbHelper _apprenticeshipsSqlDbHelper;
        private FlexiPaymentsInputDataModel _inputData;

        public FlexiPaymentsSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _employerStepsHelper = new EmployerStepsHelper(_context);
            _commitmentsSqlDataHelper = new CommitmentsSqlDataHelper(context.Get<DbConfig>());
            _earningsSqlDbHelper = context.Get<EarningsSqlDbHelper>();
            _apprenticeshipsSqlDbHelper = context.Get<ApprenticeshipsSqlDbHelper>();
        }

        [Given(@"Employer adds apprentices to the cohort with the following details")]
        public void GivenEmployerAddsApprenticesToTheCohortWithTheFollowingDetails(Table table)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                _inputData = ReadApprenticeData(table.Rows[i]);

                if (i == 0) _employerStepsHelper.EmployerAddApprenticeFromHomePage();
                else _employerStepsHelper.EmployerAddAnotherApprenticeToCohort();
            }
            _objectContext.SetNoOfApprentices(table.RowCount);
        }

        [Given(@"the Employer uses the reservation to create and approve apprentices with the following details")]
        public void WhenTheEmployerUsesTheReservationToCreateAndApproveApprenticesWithTheFollowingDetails(Table table)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                _inputData = ReadApprenticeData(table.Rows[i]);

                if (i == 0) _employerStepsHelper.NonLevyEmployerAddsFirstApprenticesUsingReservations();
                else _employerStepsHelper.NonLevyEmployerAddsAnotherApprenticesUsingReservations(i+1);
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

                Assert.That(inputCommitmentData.IsPilot, Is.EqualTo(Boolean.Parse(commitmentDbData.isPilot)), "Incorrect Pilot status found in commitments db");
                Assert.That(inputCommitmentData.PriceEpisodeFromDate, Is.EqualTo(DataHelpers.TryParse(commitmentDbData.fromDate)), "Incorrect PriceEpisode From Date found in commitments db");
                Assert.That(inputCommitmentData.PriceEpisodeToDate_Date, Is.EqualTo(DataHelpers.TryParse(commitmentDbData.toDate)), "Incorrect PriceEpisode To Date found in commitments db");
                Assert.That(inputCommitmentData.PriceEpisodeCost, Is.EqualTo(double.Parse(commitmentDbData.cost)), "Incorrect PriceEpisode Cost found in commitments db");
            }
        }

        [Then(@"validate the following data is created in the earnings database")]
        public void ThenValidateTheFollowingDataIsCreatedInTheEarningsDatabase(Table table)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                var inputEarningsData = table.Rows[i].CreateInstance<FlexiPaymentsEarningDataModel>();

                var earningsDbData = _earningsSqlDbHelper.GetEarnings(_objectContext.Get($"ULN{inputEarningsData.ULNKey}"));

                Assert.That(inputEarningsData.TotalOnProgramPayment, Is.EqualTo(double.Parse(earningsDbData.totalOnProgramPayment)), "Incorrect total on-program payment found in earnings db");
                Assert.That(inputEarningsData.MonthlyOnProgramPayment, Is.EqualTo(double.Parse(earningsDbData.monthlyOnProgramPayment)), "Incorrect monthly on-program payment found in earnings db");
                Assert.That(inputEarningsData.NumberOfDeliveryMonths, Is.EqualTo(Int32.Parse(earningsDbData.numberOfDeliveryMonths)), "Incorrect number of delivery months found in earnings db");
            }
        }

        [Then(@"validate the following data in Earnings Apprenticeship database")]
        public void ThenValidateTheFollowingDataInEarningsApprenticeshipDatabase(Table table)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                var inputApprenticeshipsData = table.Rows[i].CreateInstance<FlexiPaymnetsApprenticeshipsDataModel>();

                var apprenticeshipDbData = _apprenticeshipsSqlDbHelper.GetEarningsApprenticeshipDetails(_objectContext.Get($"ULN{inputApprenticeshipsData.ULNKey}"));

                Assert.That(inputApprenticeshipsData.StartDate, Is.EqualTo(DataHelpers.TryParse(apprenticeshipDbData.actualStartDate)), "Incorrect actual start date found in Apprenticeships db");
                Assert.That(inputApprenticeshipsData.PlannedEndDate, Is.EqualTo(DataHelpers.TryParse(apprenticeshipDbData.plannedEndDate)), "Incorrect planned end date found in Apprenticeships db");
                Assert.That(inputApprenticeshipsData.AgreedPrice, Is.EqualTo(double.Parse(apprenticeshipDbData.agreedPrice)), "Incorrect agreed price found in Apprenticeships db");
                Assert.That(inputApprenticeshipsData.FundingType, Is.EqualTo(apprenticeshipDbData.FundingType.ToEnum<FundingType>()), "Incorrect funding type found in Apprenticeships db");
                Assert.That(inputApprenticeshipsData.FundingBandMaximum, Is.EqualTo(double.Parse(apprenticeshipDbData.FundingBandMax)), "Incorrect funding band max found in Apprenticeships db");
            }
        }


        [Then(@"validate earnings are not generated for the learners")]
        public void ThenValidateEarningsAreNotGeneratedForTheLearners(Table table)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                var inputEarningsData = table.Rows[i].CreateInstance<FlexiPaymentsEarningDataModel>();

                var earningsDbData = _earningsSqlDbHelper.GetEarnings(_objectContext.Get($"ULN{inputEarningsData.ULNKey}"));

                Assert.IsEmpty(earningsDbData.totalOnProgramPayment, "Incorrect total on-program payment found in earnings db");
                Assert.IsEmpty(earningsDbData.monthlyOnProgramPayment, "Incorrect total on-program payment found in earnings db");
                Assert.IsEmpty(earningsDbData.numberOfDeliveryMonths, "Incorrect total on-program payment found in earnings db");
            }
        }

        private FlexiPaymentsInputDataModel ReadApprenticeData (TableRow data)
        {
            var inputData = data.CreateInstance<FlexiPaymentsInputDataModel>();

            var apprenticeDatahelper = new ApprenticeDataHelper(new ApprenticePPIDataHelper(inputData.DateOfBirth), _objectContext, _context.Get<CommitmentsSqlDataHelper>(), inputData.AgreedPrice);

            var apprenticeCourseDataHelper = new ApprenticeCourseDataHelper(new RandomCourseDataHelper(), ApprenticeStatus.Live, inputData.StartDate, inputData.EndDate, inputData.TrainingCode);

            _context.Replace<ApprenticeDataHelper>(apprenticeDatahelper);
            _context.Replace<ApprenticeCourseDataHelper>(apprenticeCourseDataHelper);

            _objectContext.Set($"ULN{inputData.ULNKey}", apprenticeDatahelper.Uln());

            return inputData;
        }
    }
}
