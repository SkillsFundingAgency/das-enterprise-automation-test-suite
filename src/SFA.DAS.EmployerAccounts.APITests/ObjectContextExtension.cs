using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.EmployerAccounts.APITests
{
    public static class ObjectContextExtension
    {
        private const string AccountIdKey = "accountid";
        private const string InternalAccountIdKey = "internalaccountid";
        private const string LegalEntityIdKey = "legalentityid";

        internal static void SetAccountId(this ObjectContext objectContext, string value) => objectContext.Replace(AccountIdKey, value);
        internal static void SetInternalAccountId(this ObjectContext objectContext, string value) => objectContext.Replace(InternalAccountIdKey, value);
        internal static void SetLegalEntityId(this ObjectContext objectContext, string value) => objectContext.Replace(LegalEntityIdKey, value);


        internal static string GetAccountId(this ObjectContext objectContext) => objectContext.Get(AccountIdKey);
        internal static string GetInternalAccountId(this ObjectContext objectContext) => objectContext.Get(InternalAccountIdKey);
        internal static string GetLegalEntityId(this ObjectContext objectContext) => objectContext.Get(LegalEntityIdKey);
    } 
}
