using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using System;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider
{
    public class ProviderReservationStepsHelper
    {
        private ProviderApprenticeshipTrainingPage _providerApprenticeshipTrainingPage;

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