using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.EmployerAccounts.APITests
{
    public static class ObjectContextExtension
    {
        private const string AccountIdKey = "accountid";
        private const string InternalAccountIdKey = "internalaccountid";
        private const string LegalEntityIdKey = "legalentityid";
        private const string PayeSchemeRef = "payeschemeref";

        internal static void SetHashedAccountId(this ObjectContext objectContext, string value) => objectContext.Replace(AccountIdKey, value);
        internal static void SetAccountId(this ObjectContext objectContext, string value) => objectContext.Replace(InternalAccountIdKey, value);
        internal static void SetLegalEntityId(this ObjectContext objectContext, string value) => objectContext.Replace(LegalEntityIdKey, value);
        internal static void SetPayeSchemeRef(this ObjectContext objectContext, string value) => objectContext.Replace(PayeSchemeRef, value);


        internal static string GetHashedAccountId(this ObjectContext objectContext) => objectContext.Get(AccountIdKey);
        internal static string GetAccountId(this ObjectContext objectContext) => objectContext.Get(InternalAccountIdKey);
        internal static string GetLegalEntityId(this ObjectContext objectContext) => objectContext.Get(LegalEntityIdKey);
        internal static string GetPayeSchemeRefId(this ObjectContext objectContext) => objectContext.Get(PayeSchemeRef);
    } 
}
