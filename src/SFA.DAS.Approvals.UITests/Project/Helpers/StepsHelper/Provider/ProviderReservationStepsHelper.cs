using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider
{
    public class ProviderReservationStepsHelper
    {
        private readonly ProviderCommonStepsHelper _providerCommonStepsHelper;

        private readonly ReplaceApprenticeDatahelper _replaceApprenticeDatahelper;

        private ProviderApprenticeshipTrainingPage _providerApprenticeshipTrainingPage;

        public ProviderReservationStepsHelper(ScenarioContext context)
        {
            _providerCommonStepsHelper = new ProviderCommonStepsHelper(context);

            _replaceApprenticeDatahelper = new ReplaceApprenticeDatahelper(context);
        }

        public ProviderApproveApprenticeDetailsPage AddApprentice(ProviderAddApprenticeDetailsPage _providerAddApprenticeDetailsPage, int numberOfApprentices)
        {
            var providerApproveApprenticeDetailsPage = _providerAddApprenticeDetailsPage.SubmitValidApprenticeDetails();

            for (int i = 1; i < numberOfApprentices; i++)
            {
                _replaceApprenticeDatahelper.ReplaceApprenticeDataInContext(i);

                var page = providerApproveApprenticeDetailsPage.SelectAddAnApprenticeUsingReservation().CreateANewReservation();

                var page1 = VerifySucessMessage(page);

                providerApproveApprenticeDetailsPage = page1.GoToSelectStandardPage().ProviderSelectsAStandard().SubmitValidApprenticeDetails();

            }

            return _providerCommonStepsHelper.SetApprenticeDetails(providerApproveApprenticeDetailsPage, numberOfApprentices);
        }

        public ProviderMakingChangesPage ProviderMakeReservation(ApprovalsProviderHomePage approvalsProviderHomePage)
        {
            return VerifySucessMessage(StartCreateReservationAndGoToStartTrainingPage(approvalsProviderHomePage));
        }

        private ProviderMakingChangesPage VerifySucessMessage(ProviderApprenticeshipTrainingPage page)
        {
            return page.AddTrainingCourse().SelectDate().ClickSaveAndContinueButton().ConfirmReserveFunding().VerifySucessMessage();
        }

        public ProviderAddApprenticeDetailsPage ProviderMakeReservation(ProviderLoginUser login)
        {
            return ProviderMakeReservation(_providerCommonStepsHelper.GoToProviderHomePage(login, false)).GoToSelectStandardPage().ProviderSelectsAStandard();
        }

        public ProviderApprenticeshipTrainingPage StartCreateReservationAndGoToStartTrainingPage(ApprovalsProviderHomePage approvalsProviderHomePage)
        {
            return _providerApprenticeshipTrainingPage = approvalsProviderHomePage
                   .GoToProviderGetFunding()
                   .StartReservedFunding()
                   .ChooseNonLevyEmployer()
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

        public void CompleteCreateReservationFromStartTrainingPage() => VerifySucessMessage(_providerApprenticeshipTrainingPage);

        public void VerifyCreateReservationCannotBeCompleted()
        {
            _providerApprenticeshipTrainingPage
                .AddTrainingCourse()
                .ClickSaveAndContinueButtonAndExpectProblem()
                .VerifyProblem("You must select a start date");
        }

    }
}