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
        private const string UkprnKey = "ukprnkey";
        #endregion

        internal static void SetEmail(this ObjectContext objectContext, string email) => objectContext.Replace(EmailKey, email);
        internal static void SetUkprn(this ObjectContext objectContext, string Ukprn) => objectContext.Replace(UkprnKey, Ukprn);

        internal static string GetEmail(this ObjectContext objectContext) => objectContext.Get(EmailKey);
        internal static string GetUkprn(this ObjectContext objectContext) => objectContext.Get(UkprnKey);
    }
}
