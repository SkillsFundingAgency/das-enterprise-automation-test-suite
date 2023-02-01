using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.EmployerFinance.APITests
{
    public static class ObjectContextExtension
    {
        private const string AccountIdKey = "accountid";
        private const string AccountHashedIdKey = "accounthashedid";
        private const string EmpRefKey = "empref";

        internal static void SetHashedAccountId(this ObjectContext objectContext, string value) => objectContext.Replace(AccountHashedIdKey, value);
        internal static void SetAccountId(this ObjectContext objectContext, string value) => objectContext.Replace(AccountIdKey, value);
        internal static void SetEmpRef(this ObjectContext objectContext, string value) => objectContext.Replace(EmpRefKey, value);

        internal static string GetHashedAccountId(this ObjectContext objectContext) => objectContext.Get(AccountHashedIdKey);
        internal static string GetAccountId(this ObjectContext objectContext) => objectContext.Get(AccountIdKey);
        internal static string GetEmpRef(this ObjectContext objectContext) => objectContext.Get(EmpRefKey);
    }
}