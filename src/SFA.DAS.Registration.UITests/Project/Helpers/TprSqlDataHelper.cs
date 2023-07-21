using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    internal class TprSqlDataHelper
    {
        private readonly DbConfig _dbConfig;
        private readonly ObjectContext _objectContext;
        private readonly AornDataHelper _aornDataHelper;

        public TprSqlDataHelper(DbConfig dbConfig, ObjectContext objectContext, AornDataHelper aornDataHelper)
        {
            _dbConfig = dbConfig;
            _objectContext = objectContext;
            _aornDataHelper = aornDataHelper;
        }

        public void CreateSingleOrgAornData() => CreateAornData("SingleOrg");

        public void CreateMultiOrgAORNData()
        {
            CreateAornData("MultiOrg");
            CreateAornData("MultiOrg");
        }

        private void CreateAornData(string orgType)
        {
            var aornNumber = _aornDataHelper.AornNumber;
            
            var organisationName = InsertTprDataHelper.InsertTprData(_dbConfig.TPRDbConnectionString, aornNumber, _objectContext.GetGatewayPaye(0), orgType);
            
            _objectContext.UpdateOrganisationName(organisationName);
            
            _objectContext.UpdateAornNumber(aornNumber, 0);
        }
    }
}
