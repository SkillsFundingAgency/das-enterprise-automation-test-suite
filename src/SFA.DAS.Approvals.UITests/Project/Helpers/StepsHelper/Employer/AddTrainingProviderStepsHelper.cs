using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using System;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer
{
    public class AddTrainingProviderStepsHelper
    {

        public AddTrainingProviderStepsHelper() { }

        public static Func<AddAnApprenitcePage, AddTrainingProviderDetailsPage> AddTrainingProviderDetailsUsingDirectTransfersFunc() => (x) => x.StartNowToSelectFunding().SelectFundingType(FundingType.DirectTransferFundsFromConnection);
        public static Func<AddAnApprenitcePage, AddTrainingProviderDetailsPage> AddTrainingProviderDetailsViaCurrentLevyFundsFunc() => (x) => x.StartNowToSelectFunding().SelectFundingType(FundingType.CurrentLevyFunds);
        internal static Func<AddAnApprenitcePage, AddTrainingProviderDetailsPage> AddTrainingProviderDetailsFunc() => (x) => x.StartNowToAddTrainingProvider();
        internal static Func<AddAnApprenitcePage, AddTrainingProviderDetailsPage> AddTrainingProviderDetailsViaReserveNewFundsFunc() => (x) => x.StartNowToSelectFunding().SelectFundingType(FundingType.ReservedFunds);
    }
}