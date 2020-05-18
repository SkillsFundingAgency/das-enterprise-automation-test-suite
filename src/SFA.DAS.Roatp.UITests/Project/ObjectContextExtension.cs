using SFA.DAS.ConfigurationBuilder;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.Roatp.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string EmailKey = "emailkey";
        private const string ProviderNameKey = "providernamekey";
        private const string OrganisationTypeKey = "organisationtypekey";
        private const string UkprnKey = "ukprnkey";
        private const string ApplicationReference = "applicationreference";
        #endregion

        internal static void SetEmail(this ObjectContext objectContext, string email) => objectContext.Replace(EmailKey, email);
        internal static void SetProviderName(this ObjectContext objectContext, string providername) => objectContext.Replace(ProviderNameKey, providername);
        internal static void UpdateOrganisationType(this ObjectContext objectContext, string organisationType) => objectContext.Replace(OrganisationTypeKey, organisationType);
        internal static void SetUkprn(this ObjectContext objectContext, string Ukprn) => objectContext.Replace(UkprnKey, Ukprn);
        internal static void SetApplicationReference(this ObjectContext objectContext, string applicationReference) => objectContext.Replace(ApplicationReference, applicationReference);
        
        public static string GetProviderName(this ObjectContext objectContext) => objectContext.Get(ProviderNameKey);
        internal static string GetOrganisationType(this ObjectContext objectContext) => objectContext.Get(OrganisationTypeKey);
        internal static string GetEmail(this ObjectContext objectContext) => objectContext.Get(EmailKey);
        internal static string GetUkprn(this ObjectContext objectContext) => objectContext.Get(UkprnKey);
        internal static string GetApplicationReference(this ObjectContext objectContext) => objectContext.Get(ApplicationReference);
    }
}
