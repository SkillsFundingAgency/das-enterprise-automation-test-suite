using MongoDB.Bson;
using System;

namespace SFA.DAS.MongoDb.DataGenerator.Helpers
{
    public class EnglishFractionDataGenerator : EmpRefFilterDefinition, IMongoDbDataGenerator
    {
        private readonly string _fraction;
        private readonly string _calculatedAt;

        public EnglishFractionDataGenerator(MongoDbDataHelper helper, decimal fraction, DateTime calculatedAt) : base(helper)
        {
            _fraction = fraction.ToString();
            _calculatedAt = calculatedAt.ToString("yyyy-MM-dd");
        }

        public string CollectionName() => "fractions";

        public BsonDocument[] Data()
        {
            BsonDocument value = new BsonDocument
            {
                {"region", "England" },
                {"value", _fraction }
            };

            BsonArray fractionCalculations = new BsonArray
            {
                new BsonDocument
                {
                    { "calculatedAt", _calculatedAt },
                    { "fractions", new BsonArray { value } }
                }
            };

            BsonDocument fractions = new BsonDocument
            {
                { "empref", mongoDbDatahelper.EmpRef },
                { "fractionCalculations", fractionCalculations }
            };

            return new BsonDocument[] { fractions };
        }
    }
}
