using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Login.Service
{
    public static class ScenarioContextExtension
    {
        public static void SetNonAccountLoginUser<T>(this ScenarioContext context, T value) => SetUser(context, value);

        public static void SetAccountUser(this ScenarioContext context, AccountUser value)
        {
            if (value == null) return;

            value.LegalEntities = GetAccountLegalEntities(context, value.Username);

            value.OrganisationName = value.LegalEntities.FirstOrDefault();

            SetUser(context, value);
        }

        public static void SetAccountUser(this ScenarioContext context, MultipleAccountUser value)
        {
            if (value == null) return;

            value.LegalEntities = GetAccountLegalEntities(context, value.Username);

            value.OrganisationName = value.LegalEntities.FirstOrDefault();

            if (value.LegalEntities.Count > 1) { value.SecondOrganisationName = value.LegalEntities[1]; }

            SetUser(context, value);
        }

        public static T GetUser<T>(this ScenarioContext context) => context.Get<T>(Key<T>());

        private static List<string> GetAccountLegalEntities(ScenarioContext context, string username)
        {
          var legalEntities = new LegalEntitiesSqlDataHelper(context.Get<DbConfig>()).GetAccountLegalEntities(username);

            return legalEntities.Select(x => RegexHelper.ReplaceMultipleSpace(x)).ToList();
        }

        private static void SetUser<T>(ScenarioContext context, T data) => context.Set(data, Key(data.GetType()));

        private static string Key<T>() => Key(typeof(T));

        private static string Key(Type t) => t.FullName;
    }
}
