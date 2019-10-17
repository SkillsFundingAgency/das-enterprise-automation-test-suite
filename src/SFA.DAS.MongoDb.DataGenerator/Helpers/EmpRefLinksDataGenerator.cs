using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.RegularExpressions;

namespace SFA.DAS.MongoDb.DataGenerator.Helpers
{
    public class EmpRefLinksDataGenerator : EmpRefFilterDefinition, IMongoDbDataGenerator
    {
        private readonly string _empRefLink;

        public EmpRefLinksDataGenerator(MongoDbDataHelper helper) : base(helper)
        {
            _empRefLink = Regex.Replace(mongoDbDatahelper.EmpRef, "/", "%2");
        }

        public string CollectionName() => "emprefs";

        public BsonDocument[] Data()
        {

            BsonDocument selfHref = new BsonDocument { { "href", $"/epaye/{_empRefLink}" } };
            BsonDocument declarationsHref = new BsonDocument { { "href", $"/epaye/{_empRefLink}/declarations" } };
            BsonDocument franctionsHref = new BsonDocument { { "href", $"/epaye/{_empRefLink}/fractions" } };
            BsonDocument empCheckHref = new BsonDocument { { "href", $"/epaye/{_empRefLink}/employed" } };


            BsonDocument links = new BsonDocument
            {
                { "self" , selfHref},
                { "declarations" , declarationsHref },
                { "fractions", franctionsHref },
                { "employment-check" ,empCheckHref }
            };

            BsonDocument scenarioName = new BsonDocument { { "nameLine1", mongoDbDatahelper.Name } };

            BsonDocument name = new BsonDocument { { "name", scenarioName } };

            BsonDocument empRefLinks = new BsonDocument
            {
                {"_links" , links },
                {"empref", mongoDbDatahelper.EmpRef },
                {"employer", name}
            };

            return new BsonDocument[] { empRefLinks };
        }
    }
}
