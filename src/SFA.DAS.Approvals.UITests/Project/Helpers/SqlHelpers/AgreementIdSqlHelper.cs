using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers
{
    class AgreementIdSqlHelper : SqlDbHelper
    {
        private readonly ScenarioContext _context;
        private readonly string _connectionString;
         
        public AgreementIdSqlHelper(RegistrationConfig registrationConfig) : base(registrationConfig.RE_AccountsDbConnectionString)
        {
            _connectionString = registrationConfig.RE_AccountsDbConnectionString;
        }

        public string GetAgreementId(string email, string name)
        {
            string sqlQueryFromFile = FileHelper.GetSql("GetAgreementId");

            Dictionary<string, string> sqlParameters = new Dictionary<string, string> { { "@email", email }, { "@name", name } };

            List<object[]> responseData = SqlDatabaseConnectionHelper.ReadDataFromDataBase(sqlQueryFromFile, _connectionString, sqlParameters);

            if (responseData.Count == 0)
                return null;
            else
                return responseData[0][0].ToString();
        }


    }
}
