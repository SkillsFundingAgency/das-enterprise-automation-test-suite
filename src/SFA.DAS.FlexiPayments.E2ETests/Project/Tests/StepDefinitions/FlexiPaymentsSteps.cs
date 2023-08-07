using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FlexiPayments.E2ETests.Project.Helpers;
using SFA.DAS.FlexiPayments.E2ETests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.FlexiPayments.E2ETests.Project.Tests.TestSupport;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions;
using SFA.DAS.TestDataExport.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly NonLevyReservationStepsHelper _nonLevyReservationStepsHelper;
        private readonly CommitmentsSqlDataHelper _commitmentsSqlDataHelper;
        private readonly EarningsSqlDbHelper _earningsSqlDbHelper;
        private readonly ApprenticeshipsSqlDbHelper _apprenticeshipsSqlDbHelper;
        private readonly ExistingAccountSteps _existingAccountSteps;
        private readonly FlexiPaymentProviderSteps _flexiPaymentProviderSteps;
        private ApprenticeDetailsPage _apprenticeDetailsPage;
        private readonly List<(int key, string uln)> UlnKey;

        public FlexiPaymentsSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _employerStepsHelper = new EmployerStepsHelper(_context);
            _providerStepsHelper = new ProviderStepsHelper(_context);
            _nonLevyReservationStepsHelper = new NonLevyReservationStepsHelper(_context);
            _commitmentsSqlDataHelper = new CommitmentsSqlDataHelper(context.Get<DbConfig>());
            _earningsSqlDbHelper = context.Get<EarningsSqlDbHelper>();
            _apprenticeshipsSqlDbHelper = context.Get<ApprenticeshipsSqlDbHelper>();
            _existingAccountSteps = new ExistingAccountSteps(_context);
            _flexiPaymentProviderSteps = new FlexiPaymentProviderSteps(_context);
            UlnKey = new List<(int key, string uln)>();
        }

        [Given(@"fully approved apprentices with the below data")]
        public void GivenFullyApprovedApprenticesWithTheBelowData(Table table)
        {
            _existingAccountSteps.GivenTheEmployerLoginsUsingExistingAccount("Levy");

            _employerStepsHelper.EmployerAddApprentice(ReadApprenticeData(table));

            _employerStepsHelper.EmployerFirstApproveCohortAndNotifyProvider();

            _flexiPaymentProviderSteps.GivenProviderLogsInToReviewTheCohort();

            int index = 0;

            foreach (var row in table.Rows)
            {
                index++;
                var inputData = row.CreateInstance<FlexiPaymentsInputDataModel>();
                if (inputData.PilotStatus) _flexiPaymentProviderSteps.ProviderAddsUlnAndOptLearnerIntoThePilot(index);
                else _flexiPaymentProviderSteps.ProviderAddsUlnAndOptLearnerOutOfThePilot(index);
            }

            _flexiPaymentProviderSteps.ThenProviderApprovesTheCohort();
        }

        [Given(@"the Employer has an approved (Pilot|NonPilot) apprentice")]
        public void EmployerHasFullyApprovedPilotApprentice(string pilotStatus)
        {
            _existingAccountSteps.GivenTheEmployerLoginsUsingExistingAccount("Levy");

            _employerStepsHelper.EmployerAddApprentice(1);

            _employerStepsHelper.EmployerFirstApproveCohortAndNotifyProvider();

            _flexiPaymentProviderSteps.GivenProviderLogsInToReviewTheCohort();

            if (pilotStatus == "Pilot") _flexiPaymentProviderSteps.ProviderAddsUlnAndOptLearnerIntoThePilot(1);
            else _flexiPaymentProviderSteps.ProviderAddsUlnAndOptLearnerOutOfThePilot(1);

            _flexiPaymentProviderSteps.ThenProviderApprovesTheCohort();
        }


        [Given(@"Employer adds apprentices to the cohort with the following details")]
        public void GivenEmployerAddsApprenticesToTheCohortWithTheFollowingDetails(Table table) => _employerStepsHelper.EmployerAddApprentice(ReadApprenticeData(table));

        [Given(@"Pilot Provider adds apprentices to the cohort witht the following details")]
        public void GivenPilotProviderAddsApprenticesToTheCohortWithtTheFollowingDetails(Table table) => _providerStepsHelper.PilotProviderAddApprentice(ReadApprenticeData(table));

        [When(@"employer reviews and approves the cohort")]
        public void WhenEmployerReviewsAndApprovesTheCohort() => new EmployerStepsHelper(_context).EmployerReviewCohort().EmployerDoesSecondApproval();

        [Given(@"the Employer uses the reservation to create and approve apprentices with the following details")]
        public void WhenTheEmployerUsesTheReservationToCreateAndApproveApprenticesWithTheFollowingDetails(Table table) => _nonLevyReservationStepsHelper.NonLevyEmployerAddsApprenticesUsingReservations(ReadApprenticeData(table), false);

        [Then(@"validate the following data is created in the commitments database")]
        public void ThenValidateTheFollowingDataIsCreatedInTheCommitmentsDatabase(Table table)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                var inputCommitmentData = table.Rows[i].CreateInstance<FlexiPaymentsCommitmentsDataModel>();

                int ulnKey = inputCommitmentData.ULNKey;

                var (isPilot, fromDate, toDate, cost) = _commitmentsSqlDataHelper.GetFlexiPaymentsCommitmentData(GetApprenticeULN(ulnKey));

                Assert.Multiple(() => 
                {
                    Assert.That(Boolean.Parse(isPilot), Is.EqualTo(inputCommitmentData.IsPilot), ErrorMessage("Incorrect Pilot status found in commitments db", ulnKey));
                    Assert.That(DataHelpers.TryParseDate(fromDate), Is.EqualTo(inputCommitmentData.PriceEpisodeFromDate), ErrorMessage("Incorrect PriceEpisode From Date found in commitments db", ulnKey));
                    Assert.That(DataHelpers.TryParseDate(toDate), Is.EqualTo(inputCommitmentData.PriceEpisodeToDate), ErrorMessage("Incorrect PriceEpisode To Date found in commitments db", ulnKey));
                    Assert.That(double.Parse(cost), Is.EqualTo(inputCommitmentData.PriceEpisodeCost), ErrorMessage("Incorrect PriceEpisode Cost found in commitments db", ulnKey));
                });
            }
        }

        private string ErrorMessage(string message, int ulnKey) => $"'{message}' for ulnkey '{ulnKey}', uln '{GetApprenticeULN(ulnKey)}'";

        [Then(@"validate the following data is created in the earnings database")]
        public void ThenValidateTheFollowingDataIsCreatedInTheEarningsDatabase(Table table)
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
        public void ThenValidateTheFollowingDataInEarningsApprenticeshipDatabase(Table table)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                var inputApprenticeshipsData = table.Rows[i].CreateInstance<FlexiPaymnetsApprenticeshipsDataModel>();

                int ulnKey = inputApprenticeshipsData.ULNKey;

                (string isPilot, string actualStartDate, string plannedStartDate, string plannedEndDate, string agreedPrice, string FundingType, string FundingBandMax) apprenticeshipDbData = _apprenticeshipsSqlDbHelper.GetEarningsApprenticeshipDetails(_objectContext.Get(GetApprenticeULN(ulnKey)));

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
        public void ThenValidateEarningsAreNotGeneratedForTheLearners(Table table)
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

        [When(@"Employer searches learner (.*) on Manage your apprentices page")]
        public void WhenEmployerSearchesLearnerOnManageYourApprenticesPage(int learnerNumber)
        {
            _flexiPaymentProviderSteps.SetApprenticeDetailsInContext(learnerNumber);

            _apprenticeDetailsPage = _employerStepsHelper.ViewCurrentApprenticeDetails(true);
        }

        [Then(@"Employer (can|cannot) make changes to fully approved learner (.*)")]
        public void ThenEmployerCannotMakeChangesToFullyApprovedLearner(string action, int learnerNumber)
        {
            _flexiPaymentProviderSteps.SetApprenticeDetailsInContext(learnerNumber);

            _apprenticeDetailsPage.ValidateEmployerEditApprovedApprentice(action == "can");
        }

        public List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)> ReadApprenticeData(Table table)
        {
            List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)> listOfApprentice = new();

            foreach (var row in table.Rows) listOfApprentice.Add(ReadApprenticeData(row));

            _context.Set(listOfApprentice);

            return listOfApprentice;
        }

        private (ApprenticeDataHelper, ApprenticeCourseDataHelper) ReadApprenticeData(TableRow data)
        {
            var inputData = data.CreateInstance<FlexiPaymentsInputDataModel>();

            var apprenticeDatahelper = new ApprenticeDataHelper(new ApprenticePPIDataHelper(_context.ScenarioInfo.Tags, inputData.DateOfBirth), _objectContext, _context.Get<CommitmentsSqlDataHelper>(), inputData.AgreedPrice);

            var apprenticeCourseDataHelper = new ApprenticeCourseDataHelper(new RandomCourseDataHelper(), inputData.StartDate, inputData.DurationInMonths, inputData.TrainingCode);

            UlnKey.Add((inputData.ULNKey, apprenticeDatahelper.ApprenticeULN));

            return (apprenticeDatahelper, apprenticeCourseDataHelper);
        }

        private string GetApprenticeULN(int key) => UlnKey.FirstOrDefault(x => x.key == key).uln;
    }
}
