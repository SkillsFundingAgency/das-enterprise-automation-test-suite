

namespace SFA.DAS.Registration.UITests.Project.Helpers;

public class TprSqlDataHelper(DbConfig dbConfig, ObjectContext objectContext, AornDataHelper aornDataHelper)
{
    public (string paye, string aornNumber, string orgName) CreateAornData(bool isSingleOrg) => isSingleOrg ? CreateSingleOrgAornData() : CreateMultiOrgAORNData();

    public (string paye, string aornNumber, string orgName) CreateSingleOrgAornData() => CreateAornData("SingleOrg");

    public (string paye, string aornNumber, string orgName) CreateMultiOrgAORNData() => CreateAornData("MultiOrg");

    private (string paye, string aornNumber, string orgName) CreateAornData(string orgType)
    {
        var aornNumber = aornDataHelper.AornNumber;

        var paye = objectContext.GetGatewayPaye(0);

        var organisationName = new InsertTprDataHelper(objectContext, dbConfig).InsertTprData(aornNumber, paye, orgType);

        objectContext.UpdateOrganisationName(organisationName);

        objectContext.UpdateAornNumber(aornNumber, 0);

        return (paye, aornNumber, organisationName);
    }
}
