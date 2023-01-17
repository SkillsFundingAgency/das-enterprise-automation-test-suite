using Polly;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers
{
    public class RofjaaDbSqlHelper : SqlDbHelper
    {

        public RofjaaDbSqlHelper(DbConfig dBConfig) : base(dBConfig.RofjaaDbConnectionString){}

        public string GetAccountLegalEntityId(string removalReason) => GetDataAsString($"SELECT LegalEntityId FROM Agency WHERE RemovalReason = '{removalReason}'");

        public void RemoveFJAAEmployerFromRegister()
        {
            var removalReason = "Automation";
            var accountLegalEntityId = GetAccountLegalEntityId(removalReason);
            string query = $"UPDATE Agency SET EffectiveTo = '2022-12-09 12:00:00.0000000' where LegalEntityId = {accountLegalEntityId}";
            ExecuteSqlCommand(query);      
        }

        public void AddFJAAEmployerToRegister()
        {
            var removalReason = "Automation";
            var accountLegalEntityId = GetAccountLegalEntityId(removalReason);
            string query = $"UPDATE Agency SET EffectiveTo = NULL where LegalEntityId = {accountLegalEntityId}";
            ExecuteSqlCommand(query);
        }
    }
}
