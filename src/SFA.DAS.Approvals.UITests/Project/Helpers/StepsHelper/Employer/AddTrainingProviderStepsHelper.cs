using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using System;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer
{
    public class AddTrainingProviderStepsHelper
    {

        public AddTrainingProviderStepsHelper() { }

        public static Func<AddOrSendLearnerRequestPage, ChooseYourMainTrainingProviderPage> AddTrainingProviderDetailsUsingDirectTransfersFunc() => (x) => x.StartNowToSelectFunding().SelectFundingType(FundingType.DirectTransferFundsFromConnection);
        public static Func<AddOrSendLearnerRequestPage, ChooseYourMainTrainingProviderPage> AddTrainingProviderDetailsViaCurrentLevyFundsFunc() => (x) => x.StartNowToSelectFunding().SelectFundingType(FundingType.CurrentLevyFunds);
        internal static Func<AddOrSendLearnerRequestPage, ChooseYourMainTrainingProviderPage> AddTrainingProviderDetailsFunc() => (x) => x.StartNowToAddTrainingProvider();
        internal static Func<AddOrSendLearnerRequestPage, ChooseYourMainTrainingProviderPage> AddTrainingProviderDetailsViaReserveNewFundsFunc() => (x) => x.StartNowToSelectFunding().SelectFundingType(FundingType.ReservedFunds);
    }
}