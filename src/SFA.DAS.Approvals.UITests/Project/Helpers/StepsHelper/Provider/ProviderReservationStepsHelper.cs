using Polly;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider
{
    public class ProviderReservationStepsHelper
    {
        private readonly ScenarioContext _context;

        private readonly ProviderCommonStepsHelper _providerCommonStepsHelper;

        private ProviderApprenticeshipTrainingPage _providerApprenticeshipTrainingPage;

        public ProviderReservationStepsHelper(ScenarioContext context)
        {
            _context = context;

            _providerCommonStepsHelper = new ProviderCommonStepsHelper(context);
        }

        public ProviderMakingChangesPage ProviderMakeReservation(ApprovalsProviderHomePage approvalsProviderHomePage)
        {
            return approvalsProviderHomePage
                   .GoToProviderGetFunding()
                   .StartReservedFunding()
                   .ChooseAnEmployer("NonLevy")
                   .ConfirmNonLevyEmployer()
                   .AddTrainingCourse()
                   .SelectDate()
                   .ClickSaveAndContinueButton()
                   .ConfirmReserveFunding()
                   .VerifySucessMessage();
        }

        public ProviderAddApprenticeDetailsPage ProviderMakeReservation(ProviderLoginUser login)
        {
            return ProviderMakeReservation(_providerCommonStepsHelper.GoToProviderHomePage(login, false)).GoToSelectStandardPage().ProviderSelectsAStandard();
        }

        public void StartCreateReservationAndGoToStartTrainingPage(ApprovalsProviderHomePage approvalsProviderHomePage)
        {
            _providerApprenticeshipTrainingPage = approvalsProviderHomePage
                   .GoToProviderGetFunding()
                   .StartReservedFunding()
                   .ChooseAnEmployer("NonLevy")
                   .ConfirmNonLevyEmployer();
        }

        public void VerifyReserveFromMonth(DateTime? reserveFromMonth)
        {
            _providerApprenticeshipTrainingPage.VerifyReserveFromMonth(reserveFromMonth);
        }

        public void VerifySuggestedStartMonthOptions(DateTime? firstMonth, DateTime? secondMonth, DateTime? thirdMonth)
        {
            _providerApprenticeshipTrainingPage.VerifySuggestedStartMonthOptions(firstMonth, secondMonth, thirdMonth);
        }

        public void CompleteCreateReservationFromStartTrainingPage()
        {
            _providerApprenticeshipTrainingPage
                .AddTrainingCourse()
                .SelectDate()
                .ClickSaveAndContinueButton()
                .ConfirmReserveFunding()
                .VerifySucessMessage();
        }

        public void VerifyCreateReservationCannotBeCompleted()
        {
            _providerApprenticeshipTrainingPage
                .AddTrainingCourse()
                .ClickSaveAndContinueButtonAndExpectProblem()
                .VerifyProblem("You must select a start date");
        }

    }
}