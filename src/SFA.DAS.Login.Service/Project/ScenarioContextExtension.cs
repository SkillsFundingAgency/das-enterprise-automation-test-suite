using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
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
        public static void SetNonEasLoginUser<T>(this ScenarioContext context, T value) => SetUser(context, value);

        public static void SetNonEasLoginUser<T>(this ScenarioContext context, List<T> value)
        {
            foreach (T item in value) SetUser(context, item);
        }

        public static void SetEPAOAssessorPortalUser(this ScenarioContext context, List<EPAOAssessorPortalUser> users)
        {
            var signInIds = new AssessorStubLoginSqlDataHelper(context.Get<ObjectContext>(), context.Get<DbConfig>()).GetSignInIds(users.Select(x => x.Username).ToList());

            for (int i = 0; i < users.Count; i++)
            {
                users[i].IdOrUserRef = signInIds[i].signInId;

                users[i].FullName = signInIds[i].displayName;

                SetUser(context, users[i]);
            }
        }

        public static void SetEasLoginUser(this ScenarioContext context, List<EasAccountUser> users)
        {
            var notNullUsers = users.Where(x => x != null).ToList();

            if (notNullUsers.Count == 0) return;

            var legalentities = context.GetAccountLegalEntities(notNullUsers.Select(x => x.Username).ToList());

            for (int i = 0; i < notNullUsers.Count; i++)
            {
                notNullUsers[i].IdOrUserRef = legalentities[i].idOrUserRef;

                notNullUsers[i].LegalEntities = legalentities[i].listoflegalEntities;

                SetUser(context, notNullUsers[i]);
            }
        }

        public static T GetUser<T>(this ScenarioContext context) => context.Get<T>(Key<T>());

        public static List<(List<string> listoflegalEntities, string idOrUserRef)>  GetAccountLegalEntities(this ScenarioContext context, List<string> username)
        {
            var accountDetails = new EasAccountsSqlDataHelper(context.Get<ObjectContext>(), context.Get<DbConfig>()).GetAccountDetails(username);

            return accountDetails.Select(x => (x.listoflegalEntities.Select(y => RegexHelper.ReplaceMultipleSpace(y)).ToList(), x.idOrUserRef)).ToList();
        }

        private static void SetUser<T>(ScenarioContext context, T data) => context.Set(data, data == null ? Key<T>() : Key(data.GetType()));

        private static string Key<T>() => Key(typeof(T));

        private static string Key(Type t) => t.FullName;
    }
}
