using System.Text.RegularExpressions;

namespace SFA.DAS.FrameworkHelpers;

public static partial class SqlDbConfigHelper
{
    private static string SqlLoginDbNameKey => "Database";
    private static string MFALoginDbNameKey => "Initial Catalog";
    
    public static string GetDbNameKey(bool useSqlLogin) => useSqlLogin ? SqlLoginDbNameKey : MFALoginDbNameKey;

    internal static string GetDbName(string connectionstring)
    {
        var dbName = connectionstring.Split(";").ToList().Single(x => x.Contains($"{SqlLoginDbNameKey}=") || x.Contains($"{MFALoginDbNameKey}="));

        return dbName.Split("=")[1];
    }

    internal static string WriteDebugMessage(string connectionString) => ConnectionStringRegex().Replace(connectionString, "Password=<*******>;Trusted_Connection");

    [GeneratedRegex(@"Password=.*;Trusted_Connection")]
    private static partial Regex ConnectionStringRegex();
}
