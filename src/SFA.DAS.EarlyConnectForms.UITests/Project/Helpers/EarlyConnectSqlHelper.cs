using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;
using System.Linq;

public class EarlyConnectSqlHelper(ObjectContext objectContext, DbConfig config) : SqlDbHelper(objectContext, config.EarlyConnectConnectionString)
{
    public string GetAnEducationalOrganisation()
    {
        //var query = "select [Name] from EducationalOrganisation";

        //var names = GetListOfData(query).Select(x => (string)x[0]).ToList();

        List<string> names = ["Bishop ", "Cramlington ", "North East Futures ", "Haydon Bridge High School", "East Durham College"];

        var name = RandomDataGenerator.GetRandomElementFromListOfElements(names);

        objectContext.SetDebugInformation($"'{name}' is selected from the table [Name]");

        return name;
    }
}
