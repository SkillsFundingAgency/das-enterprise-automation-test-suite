using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    internal class TprSqlDataHelper(DbConfig dbConfig, ObjectContext objectContext, AornDataHelper aornDataHelper)
    {
        public void CreateSingleOrgAornData() => CreateAornData("SingleOrg");

        public void CreateMultiOrgAORNData()
        {
            CreateAornData("MultiOrg");
            CreateAornData("MultiOrg");
        }

        private void CreateAornData(string orgType)
        {
            var aornNumber = aornDataHelper.AornNumber;

            var organisationName = new InsertTprDataHelper(objectContext, dbConfig).InsertTprData(aornNumber, objectContext.GetGatewayPaye(0), orgType);

            objectContext.UpdateOrganisationName(organisationName);

            objectContext.UpdateAornNumber(aornNumber, 0);
        }
    }
}
