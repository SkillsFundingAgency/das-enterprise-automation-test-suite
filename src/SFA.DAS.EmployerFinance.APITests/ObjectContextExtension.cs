using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.EmployerFinance.APITests
{
    public static class ObjectContextExtension
    {
        private const string AccountIdKey = "accountid";
        private const string HashedAccountIdKey = "hashedaccountid";

        internal static void SetAccountId(this ObjectContext objectContext, string value) => objectContext.Replace(AccountIdKey, value);
        internal static void SetHashedAccountId(this ObjectContext objectContext, string value) => objectContext.Replace(HashedAccountIdKey, value);

        internal static string GetAccountId(this ObjectContext objectContext) => objectContext.Get(AccountIdKey);
        internal static string GetHashedAccountId(this ObjectContext objectContext) => objectContext.Get(HashedAccountIdKey);
    }
}