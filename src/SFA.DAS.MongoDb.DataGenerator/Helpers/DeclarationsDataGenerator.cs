using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace SFA.DAS.MongoDb.DataGenerator.Helpers
{
    public class DeclarationsDataGenerator : EmpRefFilterDefinition, IMongoDbDataGenerator
    {
        private readonly List<dynamic> _declarations;

        public DeclarationsDataGenerator(MongoDbDataHelper helper, List<dynamic> declaration) : base(helper)
        {
            _declarations = declaration;
        }

        public string CollectionName()
        {
            return "declarations";
        }

        public BsonDocument[] Data()
        {
            BsonArray declarations = new BsonArray();

            foreach (var declaration in _declarations)
            {
                BsonDocument payrollperiod = new BsonDocument
                {
                    {"year", declaration.Year  },
                    {"month", declaration.Month }
                };

                var submissionDate = (declaration.SubmissionDate as DateTime?)?.ToString("yyyy-MM-dd");

                long.TryParse(DateTime.Now.ToString("yssfffffff"), out long id);

                declarations.Add(new BsonDocument
                {
                    { "id", id },
                    { "submissionTime", $"{submissionDate}T12:00:00.000" },
                    { "payrollPeriod" ,payrollperiod },
                    { "levyDueYTD", declaration.LevyDueYTD },
                    { "levyAllowanceForFullYear", declaration.LevyAllowanceForFullYear  }
                });
            }

            BsonDocument levydeclaration = new BsonDocument
            {
                { "empref",mongoDbDatahelper.EmpRef},
                { "declarations", declarations}
            };

            return new BsonDocument[] { levydeclaration };
        }
    }
}
