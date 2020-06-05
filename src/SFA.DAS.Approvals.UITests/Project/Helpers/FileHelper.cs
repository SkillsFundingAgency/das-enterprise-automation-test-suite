using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Approvals.UITests.Project.Helpers
{
    public static class FileHelper
    {
        public static string GetSql(string source)
        {
            String sqlScriptFile = AppDomain.CurrentDomain.BaseDirectory
                        + "\\Project\\Helpers\\SqlScripts\\"
                        + source
                        + ".sql";
            String sqlScript = System.IO.File.ReadAllText(sqlScriptFile);
            sqlScript = sqlScript.Replace("\r\n", " ").Replace("\t", " ");
            return sqlScript;
        }
    }
}
