using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using System;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper
{
    public class AddTrainingProviderStepsHelper
    {

        public AddTrainingProviderStepsHelper()
        {

        }

        public Func<AddAnApprenitcePage, AddTrainingProviderDetailsPage> AddTrainingProviderDetailsFunc(string transferOrgName) => (x) => x.StartNowToCreateApprenticeViaTransfersFunds().SelectYesIWantToUseTransferFunds(transferOrgName);

        internal Func<AddAnApprenitcePage, AddTrainingProviderDetailsPage> AddTrainingProviderDetailsFunc() => (x) => x.StartNowToAddTrainingProvider();
    }
}