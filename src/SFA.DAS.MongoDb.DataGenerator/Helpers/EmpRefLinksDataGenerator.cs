using MongoDB.Bson;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.MongoDb.DataGenerator.Helpers
{
    public partial class EmpRefLinksDataGenerator : EmpRefFilterDefinition, IMongoDbDataGenerator
    {
        private readonly string _empRefLink;

        private static string Href => AttributeHelper.Href;

        public EmpRefLinksDataGenerator(MongoDbDataHelper helper) : base(helper)
        {
            _empRefLink = GeneratedRegexHelper.UrlEscapeRegex().Replace(mongoDbDatahelper.EmpRef, "%2");
        }

        public string CollectionName() => "emprefs";

        public BsonDocument[] Data()
        {

            BsonDocument selfHref = new() { { Href, $"/epaye/{_empRefLink}" } };
            BsonDocument declarationsHref = new() { { Href, $"/epaye/{_empRefLink}/declarations" } };
            BsonDocument franctionsHref = new() { { Href, $"/epaye/{_empRefLink}/fractions" } };
            BsonDocument empCheckHref = new() { { Href, $"/epaye/{_empRefLink}/employed" } };


            BsonDocument links = new()
            {
                { "self" , selfHref},
                { "declarations" , declarationsHref },
                { "fractions", franctionsHref },
                { "employment-check" ,empCheckHref }
            };

            BsonDocument scenarioName = new() { { "nameLine1", mongoDbDatahelper.Name } };

            BsonDocument name = new() { { "name", scenarioName } };

            BsonDocument empRefLinks = new()
            {
                {"_links" , links },
                {"empref", mongoDbDatahelper.EmpRef },
                {"employer", name}
            };

            return [empRefLinks];
        }
    }
}
