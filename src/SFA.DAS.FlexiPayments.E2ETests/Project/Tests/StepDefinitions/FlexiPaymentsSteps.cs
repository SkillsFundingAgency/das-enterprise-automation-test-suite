using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FlexiPayments.E2ETests.Project.Helpers;
using SFA.DAS.FlexiPayments.E2ETests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.FlexiPayments.E2ETests.Project.Tests.TestSupport;
using SFA.DAS.TestDataExport.Helper;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FlexiPaymentsSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly NonLevyReservationStepsHelper _nonLevyReservationStepsHelper;
        private readonly CommitmentsSqlDataHelper _commitmentsSqlDataHelper;
        private readonly EarningsSqlDbHelper _earningsSqlDbHelper;
        private readonly ApprenticeshipsSqlDbHelper _apprenticeshipsSqlDbHelper;

        public FlexiPaymentsSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _employerStepsHelper = new EmployerStepsHelper(_context);
            _nonLevyReservationStepsHelper = new NonLevyReservationStepsHelper(_context);
            _commitmentsSqlDataHelper = new CommitmentsSqlDataHelper(context.Get<DbConfig>());
            _earningsSqlDbHelper = context.Get<EarningsSqlDbHelper>();
            _apprenticeshipsSqlDbHelper = context.Get<ApprenticeshipsSqlDbHelper>();
        }

        [Given(@"Employer adds apprentices to the cohort with the following details")]
        public void GivenEmployerAddsApprenticesToTheCohortWithTheFollowingDetails(Table table) => _employerStepsHelper.EmployerAddApprentice(ReadApprenticeData(table));

        [Given(@"the Employer uses the reservation to create and approve apprentices with the following details")]
        public void WhenTheEmployerUsesTheReservationToCreateAndApproveApprenticesWithTheFollowingDetails(Table table) => _nonLevyReservationStepsHelper.NonLevyEmployerAddsApprenticesUsingReservations(ReadApprenticeData(table), false);


        [Then(@"validate the following data is created in the commitments database")]
        public void ThenValidateTheFollowingDataIsCreatedInTheCommitmentsDatabase(Table table)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                var inputCommitmentData = table.Rows[i].CreateInstance<FlexiPaymentsCommitmentsDataModel>();

                var commitmentDbData = _commitmentsSqlDataHelper.GetFlexiPaymentsCommitmentData(_objectContext.Get($"ULN{inputCommitmentData.ULNKey}"));

                Assert.That(Boolean.Parse(commitmentDbData.isPilot), Is.EqualTo(inputCommitmentData.IsPilot), "Incorrect Pilot status found in commitments db");
                Assert.That(DataHelpers.TryParseDate(commitmentDbData.fromDate), Is.EqualTo(inputCommitmentData.PriceEpisodeFromDate), "Incorrect PriceEpisode From Date found in commitments db");
                Assert.That(DataHelpers.TryParseDate(commitmentDbData.toDate), Is.EqualTo(inputCommitmentData.PriceEpisodeToDate), "Incorrect PriceEpisode To Date found in commitments db");
                Assert.That(double.Parse(commitmentDbData.cost), Is.EqualTo(inputCommitmentData.PriceEpisodeCost), "Incorrect PriceEpisode Cost found in commitments db");
            }
        }

        [Then(@"validate the following data is created in the earnings database")]
        public void ThenValidateTheFollowingDataIsCreatedInTheEarningsDatabase(Table table)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                var inputEarningsData = table.Rows[i].CreateInstance<FlexiPaymentsEarningDataModel>();

                var earningsDbData = _earningsSqlDbHelper.GetEarnings(_objectContext.Get($"ULN{inputEarningsData.ULNKey}"));

                Assert.That(double.Parse(earningsDbData.totalOnProgramPayment), Is.EqualTo(inputEarningsData.TotalOnProgramPayment), "Incorrect total on-program payment found in earnings db");
                Assert.That(double.Parse(earningsDbData.monthlyOnProgramPayment), Is.EqualTo(inputEarningsData.MonthlyOnProgramPayment), "Incorrect monthly on-program payment found in earnings db");
                Assert.That(Int32.Parse(earningsDbData.numberOfDeliveryMonths), Is.EqualTo(inputEarningsData.NumberOfDeliveryMonths), "Incorrect number of delivery months found in earnings db");
            }
        }

        [Then(@"validate the following data in Earnings Apprenticeship database")]
        public void ThenValidateTheFollowingDataInEarningsApprenticeshipDatabase(Table table)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                var inputApprenticeshipsData = table.Rows[i].CreateInstance<FlexiPaymnetsApprenticeshipsDataModel>();

                var apprenticeshipDbData = _apprenticeshipsSqlDbHelper.GetEarningsApprenticeshipDetails(_objectContext.Get($"ULN{inputApprenticeshipsData.ULNKey}"));

                Assert.Multiple(() =>
                {
                    Assert.That(DataHelpers.TryParseDate(apprenticeshipDbData.actualStartDate), Is.EqualTo(inputApprenticeshipsData.StartDate), "Incorrect actual start date found in Apprenticeships db");
                    Assert.That(DataHelpers.TryParseDate(apprenticeshipDbData.plannedEndDate), Is.EqualTo(inputApprenticeshipsData.PlannedEndDate), "Incorrect planned end date found in Apprenticeships db");
                    Assert.That(double.Parse(apprenticeshipDbData.agreedPrice), Is.EqualTo(inputApprenticeshipsData.AgreedPrice), "Incorrect agreed price found in Apprenticeships db");
                    Assert.That(apprenticeshipDbData.FundingType.ToEnum<FundingType>(), Is.EqualTo(inputApprenticeshipsData.FundingType), "Incorrect funding type found in Apprenticeships db");
                    Assert.That(double.Parse(apprenticeshipDbData.FundingBandMax), Is.EqualTo(inputApprenticeshipsData.FundingBandMaximum), "Incorrect funding band max found in Apprenticeships db");
                });
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

        private List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)> ReadApprenticeData(Table table)
        {
            List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)> listOfApprentice = new();

            foreach (var row in table.Rows) listOfApprentice.Add(ReadApprenticeData(row));

            _context.Set(listOfApprentice);

            return listOfApprentice;
        }

        private (ApprenticeDataHelper, ApprenticeCourseDataHelper) ReadApprenticeData(TableRow data)
        {
            var inputData = data.CreateInstance<FlexiPaymentsInputDataModel>();

            var apprenticeDatahelper = new ApprenticeDataHelper(new ApprenticePPIDataHelper(inputData.DateOfBirth), _objectContext, _context.Get<CommitmentsSqlDataHelper>(), inputData.AgreedPrice);

            var apprenticeCourseDataHelper = new ApprenticeCourseDataHelper(new RandomCourseDataHelper(), inputData.StartDate, inputData.DurationInMonths, inputData.TrainingCode);

            _objectContext.Set($"ULN{inputData.ULNKey}", apprenticeDatahelper.Uln());

            return (apprenticeDatahelper, apprenticeCourseDataHelper);
        }
    }
}
