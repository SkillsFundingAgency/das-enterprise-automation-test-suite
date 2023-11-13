using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.FlexiPayments.E2ETests.Project.Tests.TestSupport;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.TestDataExport.Helper;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Helpers
{

    public class ReadApprenticeDataHelper
    {
        private readonly ScenarioContext _context;

        public ReadApprenticeDataHelper(ScenarioContext context) => _context = context;

        internal List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)> ReadApprenticeData(Table table)
        {
            List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)> listOfApprentice = new();

            foreach (var row in table.Rows) listOfApprentice.Add(ReadApprenticeData(row));

            _context.Set(listOfApprentice);

            return listOfApprentice;
        }

        private (ApprenticeDataHelper, ApprenticeCourseDataHelper) ReadApprenticeData(TableRow data)
        {
            var objectContext = _context.Get<ObjectContext>();

            var inputData = data.CreateInstance<FlexiPaymentsInputDataModel>();

            var apprenticeDatahelper = new ApprenticeDataHelper(new ApprenticePPIDataHelper(_context.ScenarioInfo.Tags, inputData.DateOfBirth), objectContext, _context.Get<CommitmentsSqlDataHelper>(), inputData.AgreedPrice, inputData.TrainingPrice, inputData.EndpointAssessmentPrice);

            var apprenticeCourseDataHelper = new ApprenticeCourseDataHelper(new RandomCourseDataHelper(), inputData.StartDate, inputData.DurationInMonths, inputData.TrainingCode);

            objectContext.SetULNKeyInformation((inputData.ULNKey, apprenticeDatahelper.ApprenticeULN));

            return (apprenticeDatahelper, apprenticeCourseDataHelper);
        }
    }
}
