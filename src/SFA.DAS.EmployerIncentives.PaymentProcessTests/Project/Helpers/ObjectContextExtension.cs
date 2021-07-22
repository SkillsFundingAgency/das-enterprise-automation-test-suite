using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string AccountIdKey = "accountid";
        private const string ApprenticeshipIdKey = "apprenticeshipid";        
        #endregion

        internal static void SetAccountId(this ObjectContext objectContext, long value) => objectContext.Replace(AccountIdKey, value);
        public static long? GetAccountId(this ObjectContext objectContext)
        {
            if (!long.TryParse(objectContext.Get(AccountIdKey), out long id))
            {
                return null;
            }

            return id;
        }

        internal static void SetApprenticeshipId(this ObjectContext objectContext, long value) => objectContext.Replace(ApprenticeshipIdKey, value);
        public static long? GetApprenticeshipId(this ObjectContext objectContext)
        {
            if (!long.TryParse(objectContext.Get(ApprenticeshipIdKey), out long id))
            {
                return null;
            }

            return id;
        }        
    }
}
