using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.TransferMatching.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string EmployerTotalPledgeAmount = "employertotalpledgeamount";
        private const string PledgeId = "pledgeid";
        private const string PledgeAmount = "pledgeamount";
        #endregion

        internal static void SetEmployerTotalPledgeAmount(this ObjectContext objectContext, int value) => objectContext.Replace(EmployerTotalPledgeAmount, value);

        public static int GetEmployerTotalPledgeAmount(this ObjectContext objectContext) => objectContext.Get<int>(EmployerTotalPledgeAmount);

        internal static void SetPledgeId(this ObjectContext objectContext, string value) => objectContext.Set(PledgeId, value);

        public static string GetPledgeId(this ObjectContext objectContext) => objectContext.Get(PledgeId);

        internal static void SetPledgeAmount(this ObjectContext objectContext, int value) => objectContext.Replace(PledgeAmount, value);

        public static int GetPledgeAmount(this ObjectContext objectContext) => objectContext.Get<int>(PledgeAmount);

    }
}
