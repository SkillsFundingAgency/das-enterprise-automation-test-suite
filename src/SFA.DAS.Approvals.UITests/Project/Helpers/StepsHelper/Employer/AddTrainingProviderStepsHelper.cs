using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using System;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer
{
    public class AddTrainingProviderStepsHelper
    {

        public AddTrainingProviderStepsHelper()
        {

        }

        public Func<AddAnApprenitcePage, AddTrainingProviderDetailsPage> AddTrainingProviderDetailsUsingTransfersFunc() => (x) => x.StartNowToCreateApprenticeViaTransfersFunds().SelectYesIWantToUseTransferFunds();

        internal Func<AddAnApprenitcePage, AddTrainingProviderDetailsPage> AddTrainingProviderDetailsFunc() => (x) => x.StartNowToAddTrainingProvider();
    }
}