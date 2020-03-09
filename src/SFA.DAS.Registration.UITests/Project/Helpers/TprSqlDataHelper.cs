using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.MongoDb.DataGenerator;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    internal class TprSqlDataHelper
    {
        private readonly string _tPRDbConnectionString;
        private readonly ObjectContext _objectContext;
        private readonly RegistrationDataHelper _registrationDataHelper;

        public TprSqlDataHelper(TprConfig tprConfig, ObjectContext objectContext, RegistrationDataHelper registrationDataHelper)
        {
            _tPRDbConnectionString = tprConfig.RE_TPRDbConnectionString;
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
            var organisationName = InsertTprDataHelper.InsertTprData(_tPRDbConnectionString, _registrationDataHelper.AornNumber, _objectContext.GetGatewayPaye(), orgType);
            _objectContext.UpdateOrganisationName(organisationName);
        }
    }
}
