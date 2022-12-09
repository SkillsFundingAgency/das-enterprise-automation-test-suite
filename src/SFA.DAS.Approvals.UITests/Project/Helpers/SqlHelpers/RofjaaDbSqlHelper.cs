using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers
{
    public class RofjaaDbSqlHelper : SqlDbHelper
    {
        public RofjaaDbSqlHelper(DbConfig dBConfig) : base(dBConfig.RofjaaDbConnectionString) { }

        // POC Method below unlikely I'll be using this, just wanting to check if query executes
        // against Rofjaa dbo.agency
        public int GetCountFJAAEmployers()
        {
            string query = "SELECT Count(LegalEntityId) from [dbo].[Agency]";
            return ExecuteSqlCommand(query);
        }

        public void RemoveFJAAEmployerFromRegister()
        {
            string query = "UPDATE Agency SET EffectiveTo = '2022-12-09 12:00:00.0000000' where LegalEntityId = 18562";
            ExecuteSqlCommand(query);
        }

        public void AddFJAAEmployerToRegister()
        {
            string query = "UPDATE Agency SET EffectiveTo = NULL where LegalEntityId = 18562";
            ExecuteSqlCommand(query);
        }
    }
}
