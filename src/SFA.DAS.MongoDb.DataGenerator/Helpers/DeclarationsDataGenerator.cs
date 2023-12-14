using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace SFA.DAS.MongoDb.DataGenerator.Helpers
{
    public class DeclarationsDataGenerator(MongoDbDataHelper helper, List<dynamic> declaration) : EmpRefFilterDefinition(helper), IMongoDbDataGenerator
    {
        public string CollectionName() => "declarations";

        public BsonDocument[] Data()
        {
            BsonArray declarations = [];

            foreach (var declaration in declaration)
            {
                BsonDocument payrollperiod = new()
                {
                    {"year", declaration.Year  },
                    {"month", declaration.Month }
                };

                var submissionDate = (declaration.SubmissionDate as DateTime?)?.ToString("yyyy-MM-dd");

                _ = long.TryParse(DateTime.Now.ToString("yssfffffff"), out long id);

                declarations.Add(new BsonDocument
                {
                    { "id", id },
                    { "submissionTime", $"{submissionDate}T12:00:00.000" },
                    { "payrollPeriod" ,payrollperiod },
                    { "levyDueYTD", declaration.LevyDueYTD },
                    { "levyAllowanceForFullYear", declaration.LevyAllowanceForFullYear  }
                });
            }

            BsonDocument levydeclaration = new()
            {
                { "empref",mongoDbDatahelper.EmpRef},
                { "declarations", declarations}
            };

            return [levydeclaration];
        }
    }
}
