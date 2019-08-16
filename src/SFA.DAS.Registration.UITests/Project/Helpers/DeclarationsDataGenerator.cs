using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class DeclarationsDataGenerator : IMongoDbDataGenerator
    {
        private readonly MongoDbDataHelper _helper;
        private readonly List<dynamic> _declarations;

        public DeclarationsDataGenerator()
        {
        }

        public DeclarationsDataGenerator(MongoDbDataHelper helper, List<dynamic> declaration)
        {
            _helper = helper;
            _declarations = declaration;
        }

        public string CollectionName()
        {
            return "declarations";
        }

        public BsonDocument[] Data()
        {
            List<BsonDocument> bsonElements = new List<BsonDocument>();

            foreach (var declaration in _declarations)
            {
                BsonDocument payrollperiod = new BsonDocument
                {
                    {"year", declaration.Year  },
                    {"month", declaration.Month }
                };

                var submissionDate = (declaration.SubmissionDate as DateTime?)?.ToString("yyyy-MM-dd");
                BsonDocument declarations = new BsonDocument
                {
                    { "id", DateTime.Now.ToString("HHmmssfffff") },
                    { "submissionTime", $"{submissionDate}T12:00:00.000" },
                    { "payrollPeriod" ,payrollperiod },
                    {"levyDueYTD", declaration.LevyDueYTD },
                    {"levyAllowanceForFullYear", declaration.LevyAllowanceForFullYear  }
                };

                bsonElements.Add(new BsonDocument
                {
                    { "empref",_helper.EmpRef},
                    {"declarations", declarations}
                });
            }

            return bsonElements.ToArray();
        }

        public FilterDefinition<BsonDocument> FilterDefinition()
        {
            return Builders<BsonDocument>.Filter.Eq("empref", _helper.EmpRef);
        }
    }
}
