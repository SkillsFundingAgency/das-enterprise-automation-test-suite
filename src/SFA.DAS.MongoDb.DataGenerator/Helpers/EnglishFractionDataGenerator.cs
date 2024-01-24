using MongoDB.Bson;
using System;

namespace SFA.DAS.MongoDb.DataGenerator.Helpers
{
    public class EnglishFractionDataGenerator(MongoDbDataHelper helper, decimal fraction, DateTime calculatedAt) : EmpRefFilterDefinition(helper), IMongoDbDataGenerator
    {
        private readonly string _fraction = fraction.ToString();
        private readonly string _calculatedAt = calculatedAt.ToString("yyyy-MM-dd");

        public string CollectionName() => "fractions";

        public BsonDocument[] Data()
        {
            BsonDocument value = new()
            {
                {"region", "England" },
                {"value", _fraction }
            };

            BsonArray fractionCalculations =
            [
                new BsonDocument
                {
                    { "calculatedAt", _calculatedAt },
                    { "fractions", new BsonArray { value } }
                }
            ];

            BsonDocument fractions = new()
            {
                { "empref", mongoDbDatahelper.EmpRef },
                { "fractionCalculations", fractionCalculations }
            };

            return [fractions];
        }
    }
}
