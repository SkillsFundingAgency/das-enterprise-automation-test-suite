global using TechTalk.SpecFlow;
global using SFA.DAS.ConfigurationBuilder;
global using System.Collections.Generic;
global using SFA.DAS.FrameworkHelpers;
global using System.Linq;
global using System;
global using SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.BaseSqlDbHelper;
global using SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.TestDataCleanUpSqlDataHelper;
global using SFA.DAS.TestDataCleanup.Project.Helpers.StepsHelper;

namespace SFA.DAS.TestDataCleanup;

public static class ObjectContextExtension
{
    #region Constants
    private const string AfterScenarioTestDataTearDown = "afterscenariotestdatateardown";
    #endregion

    public static void SetDbNameToTearDown(this ObjectContext objectContext, string dbName, string value)
    {
        var dictionary = objectContext.GetDbNameToTearDown();

        if (!dictionary.ContainsKey(dbName)) dictionary.Add(dbName, new HashSet<string> { });

        dictionary[dbName].Add(value);
    }

    public static Dictionary<string, HashSet<string>> GetDbNameToTearDown(this ObjectContext objectContext) => objectContext.Get<Dictionary<string, HashSet<string>>>(AfterScenarioTestDataTearDown);

    public static void SetAfterScenarioTestDataTearDown(this ObjectContext objectContext) => objectContext.Set(AfterScenarioTestDataTearDown, new Dictionary<string, HashSet<string>>());
}