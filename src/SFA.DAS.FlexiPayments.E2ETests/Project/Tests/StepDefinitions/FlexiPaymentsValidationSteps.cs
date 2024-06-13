using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.FlexiPayments.E2ETests.Project.Helpers;
using SFA.DAS.FlexiPayments.E2ETests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.FlexiPayments.E2ETests.Project.Tests.TestSupport;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Linq;
using System.Xml.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FlexiPaymentsValidationSteps(ScenarioContext context)
    {
        private readonly CommitmentsSqlDataHelper _commitmentsSqlDataHelper = context.Get<CommitmentsSqlDataHelper>();
        private readonly EarningsSqlDbHelper _earningsSqlDbHelper = context.Get<EarningsSqlDbHelper>();
        private readonly ApprenticeshipsSqlDbHelper _apprenticeshipsSqlDbHelper = context.Get<ApprenticeshipsSqlDbHelper>();
        private ApprenticeDataHelper _apprenticeDataHelper = context.GetValue<ApprenticeDataHelper>();

        [Then(@"validate the following data is created in the commitments database")]
        public void ValidateTheFollowingDataIsCreatedInTheCommitmentsDatabase(Table table)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                var inputCommitmentData = table.Rows[i].CreateInstance<FlexiPaymentsCommitmentsDataModel>();

                int ulnKey = inputCommitmentData.ULNKey;

                var commitmentDbData = _commitmentsSqlDataHelper.GetFlexiPaymentsCommitmentData(GetApprenticeULN(ulnKey));

                Assert.Multiple(() =>
                {
                    Assert.That(Boolean.Parse(commitmentDbData.isPilot), Is.EqualTo(inputCommitmentData.IsPilot), ErrorMessage("Incorrect Pilot status found in commitments db", ulnKey));
                    Assert.That(commitmentDbData.trainingPrice, Is.EqualTo(inputCommitmentData.TrainingPrice), ErrorMessage("Incorrect Training Price found in commitments db", ulnKey));
                    Assert.That(commitmentDbData.endpointAssessmentPrice, Is.EqualTo(inputCommitmentData.EndpointAssessmentPrice), ErrorMessage("Incorrect Endpoint Assessment Price found in commitments db", ulnKey));
                    Assert.That(DataHelpers.TryParseDate(commitmentDbData.fromDate), Is.EqualTo(inputCommitmentData.PriceEpisodeFromDate), ErrorMessage("Incorrect PriceEpisode From Date found in commitments db", ulnKey));
                    Assert.That(DataHelpers.TryParseDate(commitmentDbData.toDate), Is.EqualTo(inputCommitmentData.PriceEpisodeToDate), ErrorMessage("Incorrect PriceEpisode To Date found in commitments db", ulnKey));
                    Assert.That(double.Parse(commitmentDbData.cost), Is.EqualTo(inputCommitmentData.PriceEpisodeCost), ErrorMessage("Incorrect PriceEpisode Cost found in commitments db", ulnKey));
                });
            }
        }

        [Then(@"validate the new training dates have been updated in the Apprenticeship table of Commitment db")]
        public void ValidateNewTrainingDatesHaveBeenUpdatedInTheApprenticeshipTableOfCommitmentDb()
        {
            var commitmentDbData = _commitmentsSqlDataHelper.GetFlexiPaymentsCommitmentData(GetApprenticeULN(1));

            var expectedActualStartDate = DateTime.Now;

            DateTime dbStartDate = DateTime.ParseExact(commitmentDbData.StartDate, "dd/MM/yyyy HH:mm:ss", null);
            DateTime dbActualStartDate = DateTime.ParseExact(commitmentDbData.ActualStartDate, "dd/MM/yyyy HH:mm:ss", null);
            DateTime dbFromDate = DateTime.ParseExact(commitmentDbData.fromDate, "dd/MM/yyyy HH:mm:ss", null);

            Assert.Multiple(() =>
            {
                //Assert.That(dbStartDate.ToString("yyyy-MM-dd"), Is.EqualTo(new DateTime(expectedActualStartDate.Year, expectedActualStartDate.Month, 1).ToString("yyyy-MM-dd")), "Incorrect Start Date found in Apprenticeship table, Commitment db");
                Assert.That(dbActualStartDate.ToString("yyyy-MM-dd"), Is.EqualTo(expectedActualStartDate.ToString("yyyy-MM-dd")), "Incorrect Actual Start Date found in Apprenticeship table, Commitment db");
                Assert.That(dbFromDate.ToString("yyyy-MM-dd"), Is.EqualTo(expectedActualStartDate.ToString("yyyy-MM-dd")), "Incorrect From Date found in PriceHistory table, Commitment db");
            });
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

        [When(@"Provider initiated Change of Price request details are saved in the PriceHistory table")]
        public void ProviderInitiatedChangeOfPriceRequestDetailsAreSavedInThePriceHistoryTable()
        {
            var dbData = _apprenticeshipsSqlDbHelper.GetChangeOfPriceRequestData(GetApprenticeULN(1));

            var newTrainingPrice = context.Get<Decimal>("NewTrainingPrice");

            var newTotalPrice = newTrainingPrice + Decimal.Parse(_apprenticeDataHelper.EndpointAssessmentPrice);

            var expectedDate = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime actualDate = DateTime.ParseExact(dbData.EffectiveFromDate, "dd/MM/yyyy HH:mm:ss", null);

            Assert.Multiple(() =>
            {
                Assert.That(Decimal.Parse(dbData.TrainingPrice), Is.EqualTo(newTrainingPrice), "Incorrect Training price found");
                Assert.That(Decimal.Parse(dbData.AssessmentPrice), Is.EqualTo(Decimal.Parse(_apprenticeDataHelper.EndpointAssessmentPrice)),"Incorrect End-point Assessment price found");
                Assert.That(Decimal.Parse(dbData.TotalPrice), Is.EqualTo(newTotalPrice), "Incorrect Total Price found");
                Assert.That(actualDate.ToString("yyyy-MM-dd"), Is.EqualTo(expectedDate), "Incorrect Effective From Date found");
                Assert.That(dbData.reason, Is.EqualTo(context.ScenarioInfo.Title), "Incorrect reason found");
                Assert.That(dbData.status, Is.EqualTo("Created"), "Incorrect Change of Price record status found");
            });
        }

        [When(@"Change of Start Date request details are saved in the StartDateChange table")]
        public void ChangeOfStartDateRequestDetailsAreSavedInTheStartDateChangeTable()
        {
            var dbData = _apprenticeshipsSqlDbHelper.GetChangeOfStartDateRequestData(GetApprenticeULN(1));

            var expectedDate = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime actualDate = DateTime.ParseExact(dbData.ActualStartDate, "dd/MM/yyyy HH:mm:ss", null);

            Assert.Multiple(() =>
            {
                Assert.That(actualDate.ToString("yyyy-MM-dd"), Is.EqualTo(expectedDate), "Incorrect Actual Start Date found");
                Assert.That(dbData.Reason, Is.EqualTo(context.ScenarioInfo.Title), "Incorrect reason found");
                Assert.That(dbData.RequestStatus, Is.EqualTo("Created"), "Incorrect Change of Price record status found");
            });
        }


        [When(@"Employer initiated Change of Price request details are saved in the PriceHistory table")]
        public void EmployerInitiatedChangeOfPriceRequestDetailsAreSavedInThePriceHistoryTable()
        {
            var dbData = _apprenticeshipsSqlDbHelper.GetChangeOfPriceRequestData(GetApprenticeULN(1));

            var totalPrice = Decimal.Parse(_apprenticeDataHelper.TrainingCost) - 500;

            var expectedDate = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime actualDate = DateTime.ParseExact(dbData.EffectiveFromDate, "dd/MM/yyyy HH:mm:ss", null);

            Assert.Multiple(() =>
            {
                Assert.That(dbData.TrainingPrice, Is.EqualTo(String.Empty), "Incorrect Training price found");
                Assert.That(dbData.AssessmentPrice,Is.EqualTo(String.Empty), "Incorrect End-point Assessment price found");
                Assert.That(Decimal.Parse(dbData.TotalPrice), Is.EqualTo(totalPrice), "Incorrect Total Price found");
                Assert.That(actualDate.ToString("yyyy-MM-dd"), Is.EqualTo(expectedDate), "Incorrect Effective From Date found");
                Assert.That(dbData.reason, Is.EqualTo(context.ScenarioInfo.Title), "Incorrect reason found");
                Assert.That(dbData.status, Is.EqualTo("Created"), "Incorrect Change of Price record status found");
            });
        }


        [Then(@"the approved Change of Price request is saved in the PriceHistory table")]
        public void ThenTheApprovedChangeOfPriceRequestIsSavedInThePriceHistoryTable()
        {
            var dbData = _apprenticeshipsSqlDbHelper.GetChangeOfPriceRequestData(GetApprenticeULN(1));

            Assert.That(dbData.status, Is.EqualTo("Approved"), "Incorrect Change of Price record status found");
        }

        [Then(@"the approved Change of Start Date request is saved in the StartDateChange table of Apprenticeship db")]
        public void ThenTheApprovedChangeOfStartDateRequestIsSavedInTheStartDateChangeTable()
        {
            var dbData = _apprenticeshipsSqlDbHelper.GetChangeOfStartDateRequestData(GetApprenticeULN(1));

            Assert.That(dbData.RequestStatus, Is.EqualTo("Approved"), "Incorrect Change of Start Date record status found");
        }

        [Then(@"validate the new training dates have been updated in the Apprenticeship table of Apprenticeship db")]
        public void ThenValidateTheNewTrainingDatesHaveBeenUpdatedInTheApprenticeshipTable()
        {
            var trainingDates = _apprenticeshipsSqlDbHelper.GetApprenticeshipTrainingDates(GetApprenticeULN(1));

            var expectedStartDate = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime actualStartDate = DateTime.ParseExact(trainingDates.ActualStartDate, "dd/MM/yyyy HH:mm:ss", null);

            Assert.That(actualStartDate.ToString("yyyy-MM-dd"), Is.EqualTo(expectedStartDate), "Incorrect Actual Start Date found in Apprenticeship table, Apprenticeships db");
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

        private string GetApprenticeULN(int key) => context.Get<ObjectContext>().GetULNKeyInformations().Single(x => x.key == key).uln;
    }
}
