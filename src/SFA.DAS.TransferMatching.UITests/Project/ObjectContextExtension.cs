using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.TransferMatching.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string AvailablePledgeAmount = "availablepledgeamount";
        private const string PledgeId = "pledgeid";
        #endregion

        internal static void SetAvailablePledgeAmount(this ObjectContext objectContext, int value) => objectContext.Replace(AvailablePledgeAmount, value);

        public static int GetAvailablePledgeAmount(this ObjectContext objectContext) => objectContext.Get<int>(AvailablePledgeAmount);

        internal static void SetPledgeId(this ObjectContext objectContext, string value) => objectContext.Set(PledgeId, value);

        public static string GetPledgeId(this ObjectContext objectContext) => objectContext.Get(PledgeId);
    }
}
