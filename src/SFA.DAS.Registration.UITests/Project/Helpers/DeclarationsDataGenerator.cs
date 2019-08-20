using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{

    public class EnglishFractionDataGenerator : EmpRefFilterDefinition, IMongoDbDataGenerator
    {
        private readonly MongoDbDataHelper _helper;
        private readonly string _fraction;
        private readonly string _calculatedAt;

        public EnglishFractionDataGenerator(MongoDbDataHelper helper, decimal fraction, DateTime calculatedAt) : base(helper)
        {
            _helper = helper;
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
                { "empref", _helper.EmpRef },
                { "fractionCalculations", fractionCalculations }
            };

            return new BsonDocument[] { fractions };
        }
    }

    public class DeclarationsDataGenerator : EmpRefFilterDefinition, IMongoDbDataGenerator
    {
        private readonly MongoDbDataHelper _helper;
        private readonly List<dynamic> _declarations;

        public DeclarationsDataGenerator(MongoDbDataHelper helper, List<dynamic> declaration) : base(helper)
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
            BsonDocument levydeclaration  = new BsonDocument
            {
                { "empref",_helper.EmpRef},
                { "declarations", declarations}
            };

            return new BsonDocument[] { levydeclaration };
        }
    }
}
