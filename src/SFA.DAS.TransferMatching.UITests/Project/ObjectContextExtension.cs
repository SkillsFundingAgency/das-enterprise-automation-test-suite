using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;

namespace SFA.DAS.TransferMatching.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string AvailablePledgeAmount = "availablepledgeamount";
        #endregion

        internal static void SetAvailablePledgeAmount(this ObjectContext objectContext, string accountid) => objectContext.Replace(AvailablePledgeAmount, accountid);

        public static string GetAvailablePledgeAmount(this ObjectContext objectContext) => objectContext.Get(AvailablePledgeAmount);
    }
}
