using SFA.DAS.FlexiPayments.E2ETests.Project.Helpers;
using SFA.DAS.MongoDb.DataGenerator.Helpers;
using System;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Tests.TestSupport
{
    public class FlexiPaymentsInputDataModel
    {
        public DateTime StartDate;
        public DateTime EndDate;
        public int ULNKey { get; set; }
        public string TrainingCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string StartDateStr { set { StartDate = value == "Today" ? DateTime.Today : DataHelpers.TryParse(value); } }
        public int DurationInMonths { set { EndDate = DateTime.Now.AddMonths(value);  } }
        public string AgreedPrice { get; set; }
    }
}
