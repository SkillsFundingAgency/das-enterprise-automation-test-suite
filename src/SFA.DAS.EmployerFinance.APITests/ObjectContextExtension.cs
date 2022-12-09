using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.EmployerFinance.APITests
{
    public static class ObjectContextExtension
    {
        private const string AccountIdKey = "accountid";
        private const string EmpRefKey = "empref";

        internal static void SetAccountId(this ObjectContext objectContext, string value) => objectContext.Replace(AccountIdKey, value);
        internal static void SetEmpRef(this ObjectContext objectContext, string value) => objectContext.Replace(EmpRefKey, value);

        internal static string GetAccountId(this ObjectContext objectContext) => objectContext.Get(AccountIdKey);
        internal static string GetEmpRef(this ObjectContext objectContext) => objectContext.Get(EmpRefKey);
    }
}