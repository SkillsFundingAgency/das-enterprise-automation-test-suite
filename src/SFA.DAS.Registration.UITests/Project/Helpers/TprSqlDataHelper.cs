using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.MongoDb.DataGenerator;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    internal class TprSqlDataHelper
    {
        private readonly DbConfig _dbConfig;
        private readonly ObjectContext _objectContext;
        private readonly RegistrationDataHelper _registrationDataHelper;

        public TprSqlDataHelper(DbConfig dbConfig, ObjectContext objectContext, RegistrationDataHelper registrationDataHelper)
        {
            _dbConfig = dbConfig;
            _objectContext = objectContext;
            _registrationDataHelper = registrationDataHelper;
        }

        public void CreateSingleOrgAornData() => CreateAornData("SingleOrg");

        public void CreateMultiOrgAORNData()
        {
            CreateAornData("MultiOrg");
            CreateAornData("MultiOrg");
        }

        private void CreateAornData(string orgType)
        {
            var organisationName = InsertTprDataHelper.InsertTprData(_dbConfig.TPRDbConnectionString, _registrationDataHelper.AornNumber, _objectContext.GetGatewayPaye(0), orgType);
            _objectContext.UpdateOrganisationName(organisationName);
        }
    }
}
