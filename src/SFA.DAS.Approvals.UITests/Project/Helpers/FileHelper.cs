using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Approvals.UITests.Project.Helpers
{
    public class FileHelper
    {
        public List<string> Get(string source)
        {
            var file = System.IO.File.ReadAllLines($"Data\\{source}.txt");
            return file.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        }

        public string GetSql(string source)
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
