using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.FrameworkHelpers;
using System;
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

        public void EmployerCreateCohortAndSendsToProvider()
        {
            var cohortSentYourTrainingProviderPage = EmployerCreateCohort(false);

            var cohortReference = cohortSentYourTrainingProviderPage.CohortReference();

            _cohortReferenceHelper.SetCohortReference(cohortReference);
        }

        public void EmployerCreateCohortsAndSendsToProvider(int numberOfCohorts, bool isTransferReciverEmployer)
        {
            for (var i = 1; i <= numberOfCohorts; i++)
            {
                var cohortSentYourTrainingProviderPage = EmployerCreateCohort(isTransferReciverEmployer);

                var cohortReference = cohortSentYourTrainingProviderPage.CohortReference();

                _objectContext.SetCohortReferenceList(cohortReference);
            }
        }

        private CohortSentYourTrainingProviderPage EmployerCreateCohort(bool isTransferReceiverEmployer)
        {
            return _confirmProviderDetailsHelper.ConfirmProviderDetailsAreCorrect(isTransferReceiverEmployer, AddTrainingProviderDetailsFunc())
               .EmployerSendsToProviderToAddApprentices()
               .SendInstructionsToProviderForEmptyCohort();
        }

        protected virtual Func<AddAnApprenitcePage, AddTrainingProviderDetailsPage> AddTrainingProviderDetailsFunc() => new AddTrainingProviderStepsHelper().AddTrainingProviderDetailsFunc();
    }
}