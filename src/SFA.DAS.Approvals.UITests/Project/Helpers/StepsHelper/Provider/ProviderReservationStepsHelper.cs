using System;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ProviderLogin.Service.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider
{
    public class ProviderReservationStepsHelper(ScenarioContext context)
    {
        private readonly ProviderCommonStepsHelper _providerCommonStepsHelper = new(context);

        private readonly ReplaceApprenticeDatahelper _replaceApprenticeDatahelper = new(context);

        private ProviderApprenticeshipTrainingPage _providerApprenticeshipTrainingPage;

        public ProviderApproveApprenticeDetailsPage AddApprentice(ProviderAddApprenticeDetailsPage _providerAddApprenticeDetailsPage, int numberOfApprentices)
        {
            var providerApproveApprenticeDetailsPage = _providerAddApprenticeDetailsPage.SubmitValidApprenticeDetails();

            for (int i = 1; i < numberOfApprentices; i++)
            {
                _replaceApprenticeDatahelper.ReplaceApprenticeDataInContext(i);

                var page = providerApproveApprenticeDetailsPage.SelectAddAnApprenticeUsingReservation().SelectAddManuallyViaCreateNewReservation().CreateANewReservation();

                var page1 = VerifySuccessMessage(page);

                providerApproveApprenticeDetailsPage = page1.GoToSelectStandardPage().ProviderSelectsAStandard().SubmitValidApprenticeDetails();

            }

            return _providerCommonStepsHelper.SetApprenticeDetails(providerApproveApprenticeDetailsPage, numberOfApprentices);
        }

        public ProviderMakingChangesPage ProviderMakeReservation(ApprovalsProviderHomePage approvalsProviderHomePage)
        {           
            return VerifySuccessMessage(StartCreateReservationAndGoToStartTrainingPage(approvalsProviderHomePage));
        }

        private static ProviderMakingChangesPage VerifySuccessMessage(ProviderApprenticeshipTrainingPage page)
        {
            return page.AddTrainingCourse().SelectDate().ClickSaveAndContinueButton().ConfirmReserveFunding().VerifySucessMessage();
        }

        public ProviderAddApprenticeDetailsPage ProviderMakeReservation(ProviderLoginUser login)
        {
            return ProviderMakeReservation(_providerCommonStepsHelper.GoToProviderHomePage(login, false)).GoToAddApprenticeDetailsHowPage().SelectFirstLearner();
        }

        public ProviderAddApprenticeDetailsPage ProviderAccountOwnerUserMakeReservation(ProviderAccountOwnerUser login)
        {
            return ProviderMakeReservation(_providerCommonStepsHelper.GoToProviderHomePage(login, false)).GoToAddApprenticeDetailsHowPage().SelectFirstLearner();
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

        public void CompleteCreateReservationFromStartTrainingPage() => VerifySuccessMessage(_providerApprenticeshipTrainingPage);

        public void VerifyCreateReservationCannotBeCompleted()
        {
            _providerApprenticeshipTrainingPage
                .AddTrainingCourse()
                .ClickSaveAndContinueButtonAndExpectProblem()
                .VerifyProblem("You must select a start date");
        }

    }
}