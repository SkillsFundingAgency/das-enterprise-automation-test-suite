using MongoDB.Bson;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.MongoDb.DataGenerator.Helpers
{
    public partial class EmpRefLinksDataGenerator : EmpRefFilterDefinition, IMongoDbDataGenerator
    {
        private readonly string _empRefLink;

        public EmpRefLinksDataGenerator(MongoDbDataHelper helper) : base(helper)
        {
            _empRefLink = GeneratedRegexHelper.UrlEscapeRegex().Replace(mongoDbDatahelper.EmpRef, "%2");
        }

        public string CollectionName() => "emprefs";

        public BsonDocument[] Data()
        {

            BsonDocument selfHref = new() { { "href", $"/epaye/{_empRefLink}" } };
            BsonDocument declarationsHref = new() { { "href", $"/epaye/{_empRefLink}/declarations" } };
            BsonDocument franctionsHref = new() { { "href", $"/epaye/{_empRefLink}/fractions" } };
            BsonDocument empCheckHref = new() { { "href", $"/epaye/{_empRefLink}/employed" } };


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
