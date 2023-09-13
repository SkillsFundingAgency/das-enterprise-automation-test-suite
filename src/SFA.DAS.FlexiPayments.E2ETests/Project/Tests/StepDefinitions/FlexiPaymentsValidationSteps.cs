using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.FlexiPayments.E2ETests.Project.Helpers;
using SFA.DAS.FlexiPayments.E2ETests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.FlexiPayments.E2ETests.Project.Tests.TestSupport;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FlexiPaymentsValidationSteps
    {
        private readonly ScenarioContext _context;
        private readonly CommitmentsSqlDataHelper _commitmentsSqlDataHelper;
        private readonly EarningsSqlDbHelper _earningsSqlDbHelper;
        private readonly ApprenticeshipsSqlDbHelper _apprenticeshipsSqlDbHelper;

        public FlexiPaymentsValidationSteps(ScenarioContext context)
        {
            _context = context;
            _commitmentsSqlDataHelper = context.Get<CommitmentsSqlDataHelper>();
            _earningsSqlDbHelper = context.Get<EarningsSqlDbHelper>();
            _apprenticeshipsSqlDbHelper = context.Get<ApprenticeshipsSqlDbHelper>();
        }

        [Then(@"validate the following data is created in the commitments database")]
        public void ValidateTheFollowingDataIsCreatedInTheCommitmentsDatabase(Table table)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                var inputCommitmentData = table.Rows[i].CreateInstance<FlexiPaymentsCommitmentsDataModel>();

                int ulnKey = inputCommitmentData.ULNKey;

                var (isPilot, trainingPrice, endpointAssessmentPrice, fromDate, toDate, cost) = _commitmentsSqlDataHelper.GetFlexiPaymentsCommitmentData(GetApprenticeULN(ulnKey));

                Assert.Multiple(() =>
                {
                    Assert.That(Boolean.Parse(isPilot), Is.EqualTo(inputCommitmentData.IsPilot), ErrorMessage("Incorrect Pilot status found in commitments db", ulnKey));
                    Assert.That(double.Parse(trainingPrice), Is.EqualTo(inputCommitmentData.TrainingPrice), ErrorMessage("Incorrect Training Price found in commitments db", ulnKey));
                    Assert.That(double.Parse(endpointAssessmentPrice), Is.EqualTo(inputCommitmentData.EndpointAssessmentPrice), ErrorMessage("Incorrect Endpoint Assessment Price found in commitments db", ulnKey));
                    Assert.That(DataHelpers.TryParseDate(fromDate), Is.EqualTo(inputCommitmentData.PriceEpisodeFromDate), ErrorMessage("Incorrect PriceEpisode From Date found in commitments db", ulnKey));
                    Assert.That(DataHelpers.TryParseDate(toDate), Is.EqualTo(inputCommitmentData.PriceEpisodeToDate), ErrorMessage("Incorrect PriceEpisode To Date found in commitments db", ulnKey));
                    Assert.That(double.Parse(cost), Is.EqualTo(inputCommitmentData.PriceEpisodeCost), ErrorMessage("Incorrect PriceEpisode Cost found in commitments db", ulnKey));
                });
            }
        }

        [Then(@"validate the following data is created in the earnings database")]
        public void ValidateTheFollowingDataIsCreatedInTheEarningsDatabase(Table table)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                var inputEarningsData = table.Rows[i].CreateInstance<FlexiPaymentsEarningDataModel>();

                int ulnKey = inputEarningsData.ULNKey;

                var (monthlyOnProgramPayment, totalOnProgramPayment, numberOfDeliveryMonths) = _earningsSqlDbHelper.GetEarnings(GetApprenticeULN(ulnKey), true);

                Assert.Multiple(() =>
                {
                    Assert.That(Math.Round(double.Parse(totalOnProgramPayment)), Is.EqualTo(inputEarningsData.TotalOnProgramPayment), ErrorMessage("Incorrect total on-program payment found in earnings db", ulnKey));
                    Assert.That(Math.Round(double.Parse(monthlyOnProgramPayment)), Is.EqualTo(inputEarningsData.MonthlyOnProgramPayment), ErrorMessage("Incorrect monthly on-program payment found in earnings db", ulnKey));
                    Assert.That(Int32.Parse(numberOfDeliveryMonths), Is.EqualTo(inputEarningsData.NumberOfDeliveryMonths), ErrorMessage("Incorrect number of delivery months found in earnings db", ulnKey));
                });
            }
        }

        [Then(@"validate the following data in Earnings Apprenticeship database")]
        public void ValidateTheFollowingDataInEarningsApprenticeshipDatabase(Table table)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                var inputApprenticeshipsData = table.Rows[i].CreateInstance<FlexiPaymnetsApprenticeshipsDataModel>();

                int ulnKey = inputApprenticeshipsData.ULNKey;

                (string isPilot, string actualStartDate, string plannedStartDate, string plannedEndDate, string agreedPrice, string FundingType, string FundingBandMax) apprenticeshipDbData = _apprenticeshipsSqlDbHelper.GetEarningsApprenticeshipDetails(GetApprenticeULN(ulnKey));

                Assert.Multiple(() =>
                {
                    Assert.That(apprenticeshipDbData.isPilot.ToEnum<FundingPlatform>(), Is.EqualTo(inputApprenticeshipsData.FundingPlatform), ErrorMessage("Incorrect pilot status found in Apprenticeships db", ulnKey));
                    Assert.That(DataHelpers.TryParseDate(apprenticeshipDbData.actualStartDate), Is.EqualTo(inputApprenticeshipsData.ActualStartDate), ErrorMessage("Incorrect actual start date found in Apprenticeships db", ulnKey));
                    Assert.That(DataHelpers.TryParseDate(apprenticeshipDbData.plannedStartDate), Is.EqualTo(inputApprenticeshipsData.StartDate), ErrorMessage("Incorrect planned start date found in Apprenticeships db", ulnKey));
                    Assert.That(DataHelpers.TryParseDate(apprenticeshipDbData.plannedEndDate), Is.EqualTo(inputApprenticeshipsData.PlannedEndDate), ErrorMessage("Incorrect planned end date found in Apprenticeships db", ulnKey));
                    Assert.That(double.Parse(apprenticeshipDbData.agreedPrice), Is.EqualTo(inputApprenticeshipsData.AgreedPrice), ErrorMessage("Incorrect agreed price found in Apprenticeships db", ulnKey));
                    Assert.That(apprenticeshipDbData.FundingType.ToEnum<FundingType>(), Is.EqualTo(inputApprenticeshipsData.FundingType), ErrorMessage("Incorrect funding type found in Apprenticeships db", ulnKey));
                    Assert.That(double.Parse(apprenticeshipDbData.FundingBandMax), Is.EqualTo(inputApprenticeshipsData.FundingBandMaximum), ErrorMessage("Incorrect funding band max found in Apprenticeships db", ulnKey));
                });
            }
        }

        [Then(@"validate earnings are not generated for the learners")]
        public void ValidateEarningsAreNotGeneratedForTheLearners(Table table)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                var inputEarningsData = table.Rows[i].CreateInstance<FlexiPaymentsEarningDataModel>();

                int ulnKey = inputEarningsData.ULNKey;

                var (monthlyOnProgramPayment, totalOnProgramPayment, numberOfDeliveryMonths) = _earningsSqlDbHelper.GetEarnings(GetApprenticeULN(ulnKey), false);

                Assert.Multiple(() =>
                {
                    Assert.IsEmpty(totalOnProgramPayment, ErrorMessage("Incorrect total on-program payment found in earnings db", ulnKey));
                    Assert.IsEmpty(monthlyOnProgramPayment, ErrorMessage("Incorrect total on-program payment found in earnings db", ulnKey));
                    Assert.IsEmpty(numberOfDeliveryMonths, ErrorMessage("Incorrect total on-program payment found in earnings db", ulnKey));
                });
            }
        }

        private string ErrorMessage(string message, int ulnKey) => $"'{message}' for ulnkey '{ulnKey}', uln '{GetApprenticeULN(ulnKey)}'";

        private string GetApprenticeULN(int key) => _context.Get<ObjectContext>().GetULNKeyInformations().Single(x => x.key == key).uln;
    }
}
