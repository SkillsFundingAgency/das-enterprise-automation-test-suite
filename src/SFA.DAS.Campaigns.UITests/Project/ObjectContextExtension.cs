using SFA.DAS.ConfigurationBuilder;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.Campaigns.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string VacancyTitle = "emailkey";
        #endregion

        internal static void SetVacancyTitle(this ObjectContext objectContext, string value) => objectContext.Replace(VacancyTitle, value);
       
        internal static string GetVacancyTitle(this ObjectContext objectContext) => objectContext.Get(VacancyTitle);
    }
}
