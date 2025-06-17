using FluentAssertions.Execution;
using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
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
    public class FlexiPaymentsValidationSteps(ScenarioContext context)
    {
        private readonly CommitmentsSqlDataHelper _commitmentsSqlDataHelper = context.Get<CommitmentsSqlDataHelper>();
        private readonly EarningsSqlDbHelper _earningsSqlDbHelper = context.Get<EarningsSqlDbHelper>();
        private readonly ApprenticeshipsSqlDbHelper _apprenticeshipsSqlDbHelper = context.Get<ApprenticeshipsSqlDbHelper>();
        private readonly ApprenticeDataHelper _apprenticeDataHelper = context.GetValue<ApprenticeDataHelper>();

        [Then(@"validate the following data is created in the commitments database")]
        public void ValidateTheFollowingDataIsCreatedInTheCommitmentsDatabase(Table table)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                var inputCommitmentData = table.Rows[i].CreateInstance<FlexiPaymentsCommitmentsDataModel>();

                int ulnKey = inputCommitmentData.ULNKey;

                var (StartDate, ActualStartDate, EndDate, isPilot, trainingPrice, endpointAssessmentPrice, fromDate, toDate, cost) = _commitmentsSqlDataHelper.GetFlexiPaymentsCommitmentData(GetApprenticeULN(ulnKey));

                Assert.Multiple(() =>
                {
                    Assert.That(Boolean.Parse(isPilot), Is.EqualTo(inputCommitmentData.IsPilot), ErrorMessage("Incorrect Pilot status found in commitments db", ulnKey));
                    Assert.That(trainingPrice, Is.EqualTo(inputCommitmentData.TrainingPrice), ErrorMessage("Incorrect Training Price found in commitments db", ulnKey));
                    Assert.That(endpointAssessmentPrice, Is.EqualTo(inputCommitmentData.EndpointAssessmentPrice), ErrorMessage("Incorrect Endpoint Assessment Price found in commitments db", ulnKey));
                    Assert.That(DataHelpers.TryParseDate(fromDate), Is.EqualTo(inputCommitmentData.PriceEpisodeFromDate), ErrorMessage("Incorrect PriceEpisode From Date found in commitments db", ulnKey));
                    Assert.That(DataHelpers.TryParseDate(toDate), Is.EqualTo(inputCommitmentData.PriceEpisodeToDate), ErrorMessage("Incorrect PriceEpisode To Date found in commitments db", ulnKey));
                    Assert.That(double.Parse(cost), Is.EqualTo(inputCommitmentData.PriceEpisodeCost), ErrorMessage("Incorrect PriceEpisode Cost found in commitments db", ulnKey));
                });
            }
        }

        [Then(@"validate the new training dates have been updated in the Apprenticeship table of Commitment db")]
        public void ValidateNewTrainingDatesHaveBeenUpdatedInTheApprenticeshipTableOfCommitmentDb()
        {
            var (StartDate, ActualStartDate, EndDate, isPilot, trainingPrice, endpointAssessmentPrice, fromDate, toDate, cost) = _commitmentsSqlDataHelper.GetFlexiPaymentsCommitmentData(GetApprenticeULN(1));

            var expectedActualStartDate = DateTime.Now;

            DateTime dbStartDate = DateTime.ParseExact(StartDate, "dd/MM/yyyy HH:mm:ss", null);
            DateTime dbActualStartDate = DateTime.ParseExact(ActualStartDate, "dd/MM/yyyy HH:mm:ss", null);
            DateTime dbFromDate = DateTime.ParseExact(fromDate, "dd/MM/yyyy HH:mm:ss", null);

            Assert.Multiple(() =>
            {
                Assert.That(dbStartDate.ToString("yyyy-MM-dd"), Is.EqualTo(new DateTime(expectedActualStartDate.Year, expectedActualStartDate.Month, 1).ToString("yyyy-MM-dd")), "Incorrect Start Date found in Apprenticeship table, Commitment db");
                Assert.That(dbActualStartDate.ToString("yyyy-MM-dd"), Is.EqualTo(expectedActualStartDate.ToString("yyyy-MM-dd")), "Incorrect Actual Start Date found in Apprenticeship table, Commitment db");
                Assert.That(dbFromDate.ToString("yyyy-MM-dd"), Is.EqualTo(expectedActualStartDate.ToString("yyyy-MM-dd")), "Incorrect From Date found in PriceHistory table, Commitment db");
            });
        }

        [Then(@"validate the approved Change of Price values have been updated in the Apprenticeship table of Commitment db")]
        public void ValidateTheApprovedChangeOfPriceValuesHaveBeenUpdatedInTheApprenticeshipTableOfCommitmentDb()
        {
            var (StartDate, ActualStartDate, EndDate, isPilot, trainingPrice, endpointAssessmentPrice, fromDate, toDate, cost) = _commitmentsSqlDataHelper.GetFlexiPaymentsCommitmentData(GetApprenticeULN(1));

            var newTrainingPrice = context.Get<Decimal>("NewTrainingPrice");

            var newTotalPrice = newTrainingPrice + Decimal.Parse(_apprenticeDataHelper.EndpointAssessmentPrice);

            Assert.Multiple(() =>
            {
                Assert.That(Decimal.Parse(trainingPrice), Is.EqualTo(newTrainingPrice), "Incorrect Training price found in Commitments db");
                Assert.That(Decimal.Parse(endpointAssessmentPrice), Is.EqualTo(Decimal.Parse(_apprenticeDataHelper.EndpointAssessmentPrice)), "Incorrect End-point Assessment price found in Commitments db");
                Assert.That(Decimal.Parse(cost), Is.EqualTo(newTotalPrice), "Incorrect Total Price found in Commitments db");
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

                (string isPilot, string plannedStartDate, string plannedEndDate, string agreedPrice, string FundingType, string FundingBandMax) apprenticeshipDbData = _apprenticeshipsSqlDbHelper.GetEarningsApprenticeshipDetails(GetApprenticeULN(ulnKey));

                Assert.Multiple(() =>
                {
                    Assert.That(apprenticeshipDbData.isPilot.ToEnum<FundingPlatform>(), Is.EqualTo(inputApprenticeshipsData.FundingPlatform), ErrorMessage("Incorrect pilot status found in Apprenticeships db", ulnKey));
                    Assert.That(DataHelpers.TryParseDate(apprenticeshipDbData.plannedStartDate), Is.EqualTo(inputApprenticeshipsData.StartDate), ErrorMessage("Incorrect planned start date found in Apprenticeships db", ulnKey));
                    Assert.That(DataHelpers.TryParseDate(apprenticeshipDbData.plannedEndDate), Is.EqualTo(inputApprenticeshipsData.PlannedEndDate), ErrorMessage("Incorrect planned end date found in Apprenticeships db", ulnKey));
                    Assert.That(double.Parse(apprenticeshipDbData.agreedPrice), Is.EqualTo(inputApprenticeshipsData.AgreedPrice), ErrorMessage("Incorrect agreed price found in Apprenticeships db", ulnKey));
                    Assert.That(apprenticeshipDbData.FundingType.ToEnum<FundingType>(), Is.EqualTo(inputApprenticeshipsData.FundingType), ErrorMessage("Incorrect funding type found in Apprenticeships db", ulnKey));
                    Assert.That(double.Parse(apprenticeshipDbData.FundingBandMax), Is.EqualTo(inputApprenticeshipsData.FundingBandMaximum), ErrorMessage("Incorrect funding band max found in Apprenticeships db", ulnKey));
                });
            }
        }

        [Then(@"validate there is no data in Apprenticeship database")]
        public void ThenValidateThereIsNoDataInApprenticeshipDatabase(Table table)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                var inputApprenticeshipsData = table.Rows[i].CreateInstance<FlexiPaymnetsApprenticeshipsDataModel>();

                int ulnKey = inputApprenticeshipsData.ULNKey;

                (string isPilot, string plannedStartDate, string plannedEndDate, string agreedPrice, string FundingType, string FundingBandMax) apprenticeshipDbData = _apprenticeshipsSqlDbHelper.GetEarningsApprenticeshipDetails(GetApprenticeULN(ulnKey));

                Assert.Multiple(() =>
                {
                    Assert.IsEmpty(apprenticeshipDbData.isPilot, ErrorMessage("Unexpected Pilot status found in apprenticeships db", ulnKey));
                    Assert.IsEmpty(apprenticeshipDbData.plannedStartDate, ErrorMessage("Unexpected Start Date found in apprenticeships db", ulnKey));
                    Assert.IsEmpty(apprenticeshipDbData.plannedEndDate, ErrorMessage("Unexpected End Date found in apprenticeships db", ulnKey));
                    Assert.IsEmpty(apprenticeshipDbData.agreedPrice, ErrorMessage("Unexpected Agreed Price found in apprenticeships db", ulnKey));
                    Assert.IsEmpty(apprenticeshipDbData.FundingType, ErrorMessage("Unexpected Funding Type found in apprenticeships db", ulnKey));
                    Assert.IsEmpty(apprenticeshipDbData.FundingBandMax, ErrorMessage("Unexpected Funding Band Max found in apprenticeships db", ulnKey));
                });
            }
        }


        [When(@"Provider initiated Change of Price request details are saved in the PriceHistory table")]
        public void ProviderInitiatedChangeOfPriceRequestDetailsAreSavedInThePriceHistoryTable()
        {
            var (TrainingPrice, AssessmentPrice, TotalPrice, EffectiveFromDate, reason, status) = _apprenticeshipsSqlDbHelper.GetChangeOfPriceRequestData(GetApprenticeULN(1));

            var newTrainingPrice = context.Get<Decimal>("NewTrainingPrice");

            var newTotalPrice = newTrainingPrice + Decimal.Parse(_apprenticeDataHelper.EndpointAssessmentPrice);

            var expectedDate = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime actualDate = DateTime.ParseExact(EffectiveFromDate, "dd/MM/yyyy HH:mm:ss", null);

            Assert.Multiple(() =>
            {
                Assert.That(Decimal.Parse(TrainingPrice), Is.EqualTo(newTrainingPrice), "Incorrect Training price found");
                Assert.That(Decimal.Parse(AssessmentPrice), Is.EqualTo(Decimal.Parse(_apprenticeDataHelper.EndpointAssessmentPrice)), "Incorrect End-point Assessment price found");
                Assert.That(Decimal.Parse(TotalPrice), Is.EqualTo(newTotalPrice), "Incorrect Total Price found");
                Assert.That(actualDate.ToString("yyyy-MM-dd"), Is.EqualTo(expectedDate), "Incorrect Effective From Date found");
                Assert.That(reason, Is.EqualTo(context.ScenarioInfo.Title), "Incorrect reason found");
                Assert.That(status, Is.EqualTo("Created"), "Incorrect Change of Price record status found");
            });
        }

        [When(@"Change of Start Date request details are saved in the StartDateChange table")]
        public void ChangeOfStartDateRequestDetailsAreSavedInTheStartDateChangeTable()
        {
            var (ActualStartDate, Reason, RequestStatus) = _apprenticeshipsSqlDbHelper.GetChangeOfStartDateRequestData(GetApprenticeULN(1));

            var expectedDate = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime actualDate = DateTime.ParseExact(ActualStartDate, "dd/MM/yyyy HH:mm:ss", null);

            Assert.Multiple(() =>
            {
                Assert.That(actualDate.ToString("yyyy-MM-dd"), Is.EqualTo(expectedDate), "Incorrect Actual Start Date found");
                Assert.That(Reason, Is.EqualTo(context.ScenarioInfo.Title), "Incorrect reason found");
                Assert.That(RequestStatus, Is.EqualTo("Created"), "Incorrect Change of Price record status found");
            });
        }


        [When(@"Employer initiated Change of Price request details are saved in the PriceHistory table")]
        public void EmployerInitiatedChangeOfPriceRequestDetailsAreSavedInThePriceHistoryTable()
        {
            var (TrainingPrice, AssessmentPrice, TotalPrice, EffectiveFromDate, reason, status) = _apprenticeshipsSqlDbHelper.GetChangeOfPriceRequestData(GetApprenticeULN(1));

            var totalPrice = Decimal.Parse(_apprenticeDataHelper.TrainingCost) - 500;

            var expectedDate = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime actualDate = DateTime.ParseExact(EffectiveFromDate, "dd/MM/yyyy HH:mm:ss", null);

            Assert.Multiple(() =>
            {
                Assert.That(TrainingPrice, Is.EqualTo(String.Empty), "Incorrect Training price found");
                Assert.That(AssessmentPrice, Is.EqualTo(String.Empty), "Incorrect End-point Assessment price found");
                Assert.That(Decimal.Parse(TotalPrice), Is.EqualTo(totalPrice), "Incorrect Total Price found");
                Assert.That(actualDate.ToString("yyyy-MM-dd"), Is.EqualTo(expectedDate), "Incorrect Effective From Date found");
                Assert.That(reason, Is.EqualTo(context.ScenarioInfo.Title), "Incorrect reason found");
                Assert.That(status, Is.EqualTo("Created"), "Incorrect Change of Price record status found");
            });
        }


        [Then(@"the approved Change of Price request is saved in the PriceHistory table")]
        public void ThenTheApprovedChangeOfPriceRequestIsSavedInThePriceHistoryTable()
        {
            var (_, _, _, _, _, status) = _apprenticeshipsSqlDbHelper.GetChangeOfPriceRequestData(GetApprenticeULN(1));

            Assert.That(status, Is.EqualTo("Approved"), "Incorrect Change of Price record status found");
        }

        [Then(@"the approved Change of Start Date request is saved in the StartDateChange table of Apprenticeship db")]
        public void ThenTheApprovedChangeOfStartDateRequestIsSavedInTheStartDateChangeTable()
        {
            var (_, _, RequestStatus) = _apprenticeshipsSqlDbHelper.GetChangeOfStartDateRequestData(GetApprenticeULN(1));

            Assert.That(RequestStatus, Is.EqualTo("Approved"), "Incorrect Change of Start Date record status found");
        }

        [Then(@"validate the new training dates have been updated in the Apprenticeship table of Apprenticeship db")]
        public void ThenValidateTheNewTrainingDatesHaveBeenUpdatedInTheApprenticeshipTable()
        {
            var (StartDate, _) = _apprenticeshipsSqlDbHelper.GetApprenticeshipTrainingDates(GetApprenticeULN(1));

            var expectedStartDate = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime actualStartDate = DateTime.ParseExact(StartDate, "dd/MM/yyyy HH:mm:ss", null);

            Assert.That(actualStartDate.ToString("yyyy-MM-dd"), Is.EqualTo(expectedStartDate), "Incorrect Actual Start Date found in Apprenticeship table, Apprenticeships db");
        }

        [Then(@"provider payment status is successfully updated to (Active|Inactive) in apprenticeships db")]
        public void ThenProviderPaymentStatusIsSuccessfullyUpdatedToInactiveInApprenticeshipsDb(string paymentFreezeStatus)
        {
            bool dbPaymentUnfreezeStatus = _apprenticeshipsSqlDbHelper.GetProviderPaymentStatus(GetApprenticeULN(1));

            bool expectedStatus = paymentFreezeStatus == "Active";

            Assert.AreEqual(expectedStatus, dbPaymentUnfreezeStatus, "Incorrect Provider Payment status found!");
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

        [Then(@"validate earnings instalments are updated to reflect the new agreed price of (.*)")]
        public void ValidateEarningsInstalmentsAreUpdatedToReflectTheNewAgreedPrice(int agreedPrice)
        {
            var expectedTotalOnProgrammePayment = agreedPrice * 0.8;
            var actualTotalOnProgrammePayment = _earningsSqlDbHelper.GetTotalInstalmentsAmount(GetApprenticeULN(1), true);

            Assert.AreEqual(expectedTotalOnProgrammePayment, double.Parse(actualTotalOnProgrammePayment));
        }

        [Then(@"validate instalments amounts have been updated in the earnings db to reflect the new agreed price of (.*)")]
        public void ValidateInstalmentsAmountsHaveBeenUpdatedInTheEarningsDbToReflectTheNewAgreedPriceOf(double newAgreedPrice)
        {
            var actualTotalOnProgrammePayment = _earningsSqlDbHelper.GetTotalInstalmentsAmount(GetApprenticeULN(1), true);

            var expectedOnProgrammePayment = newAgreedPrice * 0.8;

            var roundedActualTotalPayment = Math.Round(decimal.Parse(actualTotalOnProgrammePayment));
            var roundedExpectedTotalPayment = Math.Round(expectedOnProgrammePayment);

            Assert.AreEqual(roundedExpectedTotalPayment, roundedActualTotalPayment, $"Expected total on-programme payment to be: {roundedExpectedTotalPayment} but found {roundedActualTotalPayment} in earnings db");
        }

        [Then("apprenticeship is marked as withdrawn")]
        public void ApprenticeshipIsMarkedAsWithdrawn()
        {
            var (learningStatus, reason, lastDayOfLearning) = _apprenticeshipsSqlDbHelper.GetWithdrawalRequestData(GetApprenticeULN(1));

            Assert.AreEqual("Withdrawn", learningStatus, "Incorrect Learning status found!");
        }

                [Then("the approval of the apprenticeship is maintained but it is removed from private beta")]
        public void ApprovalOfTheApprenticeshipIsMaintainedButItIsRemovedFromPrivateBeta()
        {
            var (StartDate, ActualStartDate, EndDate, isPilot, trainingPrice, endpointAssessmentPrice, fromDate, toDate, cost) = _commitmentsSqlDataHelper.GetFlexiPaymentsCommitmentData(GetApprenticeULN(1));

            Assert.IsFalse(Boolean.Parse(isPilot), ErrorMessage("Incorrect Pilot status found in commitments db", 1));
        }

        private string ErrorMessage(string message, int ulnKey) => $"'{message}' for ulnkey '{ulnKey}', uln '{GetApprenticeULN(ulnKey)}'";

        private string GetApprenticeULN(int key) => context.Get<ObjectContext>().GetULNKeyInformations().Single(x => x.key == key).uln;
    }
}
