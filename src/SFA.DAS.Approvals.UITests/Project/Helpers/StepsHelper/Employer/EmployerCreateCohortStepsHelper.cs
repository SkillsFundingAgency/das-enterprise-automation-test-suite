using System;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer
{
    public class EmployerCreateCohortStepsHelper
    {
        private readonly ObjectContext _objectContext;
        protected readonly ScenarioContext context;

        private readonly CohortReferenceHelper _cohortReferenceHelper;
        private readonly ConfirmProviderDetailsHelper _confirmProviderDetailsHelper;


        public EmployerCreateCohortStepsHelper(ScenarioContext context)
        {
            this.context = context;
            _objectContext = context.Get<ObjectContext>();
            _cohortReferenceHelper = new CohortReferenceHelper(context);
            _confirmProviderDetailsHelper = new ConfirmProviderDetailsHelper(this.context);
        }

        public void EmployerCreateCohortViaLevyFundsAndSendsToProvider()
        {
            var cohortSentYourTrainingProviderPage = EmployerCreateCohortViaLevyFunds(false);

            var cohortReference = cohortSentYourTrainingProviderPage.CohortReference();

            _cohortReferenceHelper.SetCohortReference(cohortReference);
        }

        public void EmployerCreateMultipleCohortsViaLevyFundsAndSendsToProvider(int numberOfCohorts = 1)
        {
            for (var i = 1; i <= numberOfCohorts; i++)
            {
                var cohortSentYourTrainingProviderPage = EmployerCreateCohortViaLevyFunds(false);

                var cohortReference = cohortSentYourTrainingProviderPage.CohortReference();

                _objectContext.SetCohortReferenceList(cohortReference);
            }

        }

        public void EmployerCreateCohortsViaDirectTransferAndSendsToProvider(int numberOfCohorts = 1)
        {
            for (var i = 1; i <= numberOfCohorts; i++)
            {
                var cohortSentYourTrainingProviderPage = EmployerCreateCohortsViaDirectTransfer();

                var cohortReference = cohortSentYourTrainingProviderPage.CohortReference();

                _objectContext.SetCohortReferenceList(cohortReference);
            }
        }

        public void EmployerCreateCohortsViaReserveNewFundsOptionAndSendsToProvider(int numberOfCohorts = 1)
        {
            for (var i = 1; i <= numberOfCohorts; i++)
            {
                var cohortSentYourTrainingProviderPage = EmployerCreateCohortsViaReserveNewFundsOption();

                var cohortReference = cohortSentYourTrainingProviderPage.CohortReference();

                _objectContext.SetCohortReferenceList(cohortReference);
            }
        }

        private CohortSentYourTrainingProviderPage EmployerCreateCohortViaLevyFunds(bool isTransferReceiverEmployer)
        {
            return _confirmProviderDetailsHelper
               .ConfirmProviderDetailsAreCorrect(isTransferReceiverEmployer, AddTrainingProviderDetailsFunc())
               .EmployerSendsToProviderToAddApprentices()
               .VerifyMessageForTrainingProvider(context.GetValue<ApprenticeDataHelper>().MessageToProvider);
        }

        private CohortSentYourTrainingProviderPage EmployerCreateCohortsViaDirectTransfer()
        {
            return _confirmProviderDetailsHelper
               .ConfirmProviderDetailsAreCorrect(true, AddTrainingProviderDetailsViaDirectTransfersRouteFunc())
               .EmployerSendsToProviderToAddApprentices()
               .VerifyMessageForTrainingProvider(context.GetValue<ApprenticeDataHelper>().MessageToProvider);
        }

        private CohortSentYourTrainingProviderPage EmployerCreateCohortsViaReserveNewFundsOption()
        {
            return new ApprenticesHomePage(context)
                .ClickAddAnApprentice()
                .StartNowToSelectFunding()
                .SelectFundingType(FundingType.ReservedFunds)
                .SubmitValidUkprn()
                .ConfirmProviderDetailsAreCorrect()
                .EmployerSendsToProviderToAddApprentices()
                .VerifyMessageForTrainingProvider(context.GetValue<ApprenticeDataHelper>().MessageToProvider);

        }

        public StartAddingApprenticesPage NonLevyEmployerTriesToAddApprentice()
        {
            return _confirmProviderDetailsHelper
               .ConfirmProviderDetailsAreCorrect(false, AddTrainingProviderDetailsFuncWithoutSelectFundingOption());
        }

        public void NonLevyEmployerTriesToAddApprenticeButHitsReservationShutterPage()
        {
            new StartAddingApprenticesPage(context).NonLevyEmployerTriesToAddApprenticeButHitsReservationShutterPage();
        }

        protected virtual Func<AddAnApprenitcePage, AddTrainingProviderDetailsPage> AddTrainingProviderDetailsFunc() => AddTrainingProviderStepsHelper.AddTrainingProviderDetailsViaCurrentLevyFundsFunc();
        protected virtual Func<AddAnApprenitcePage, AddTrainingProviderDetailsPage> AddTrainingProviderDetailsFuncWithoutSelectFundingOption() => AddTrainingProviderStepsHelper.AddTrainingProviderDetailsFunc();
        protected virtual Func<AddAnApprenitcePage, AddTrainingProviderDetailsPage> AddTrainingProviderDetailsViaCreateReservationsRouteFunc() => AddTrainingProviderStepsHelper.AddTrainingProviderDetailsViaReserveNewFundsFunc();
        protected virtual Func<AddAnApprenitcePage, AddTrainingProviderDetailsPage> AddTrainingProviderDetailsViaDirectTransfersRouteFunc() => AddTrainingProviderStepsHelper.AddTrainingProviderDetailsUsingDirectTransfersFunc();
    }
}