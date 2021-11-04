using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Login.Service
{
    public static class ScenarioContextExtension
    {
        public static void SetProviderUser<T>(this ScenarioContext context, T value) => context.Set(value, Key<T>());

        public static void SetUser(this ScenarioContext context, LoginUser value)
        {
            if (value == null) return;

            value.LegalEntities = GetAccountLegalEntities(context, value.Username);

            value.OrganisationName = value.LegalEntities.FirstOrDefault();

            SetUser<LoginUser>(context, value);
        }

        public static void SetUser(this ScenarioContext context, MultipleAccountUser value)
        {
            if (value == null) return;

            value.LegalEntities = GetAccountLegalEntities(context, value.Username);

            value.OrganisationName = value.LegalEntities.FirstOrDefault();

            if (value.LegalEntities.Count > 1) { value.SecondOrganisationName = value.LegalEntities[1]; }

            SetUser<MultipleAccountUser>(context, value);
        }

        public static T GetUser<T>(this ScenarioContext context) => context.Get<T>(Key<T>());

        private static List<string> GetAccountLegalEntities(ScenarioContext context, string username) => new LegalEntitiesSqlDataHelper(context.Get<DbConfig>()).GetAccountLegalEntities(username);

        private static void SetUser<T>(ScenarioContext context, T data) => context.Set(data, Key(data.GetType()));

        private static string Key<T>() => Key(typeof(T));

        private static string Key(Type t) => t.FullName;
    }
}
