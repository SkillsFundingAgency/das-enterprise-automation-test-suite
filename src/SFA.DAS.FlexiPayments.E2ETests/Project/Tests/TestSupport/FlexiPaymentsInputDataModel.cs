using SFA.DAS.FlexiPayments.E2ETests.Project.Helpers;
using System;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Tests.TestSupport
{
    public class FlexiPaymentsInputDataModel
    {
        public DateTime StartDate;
        public int ULNKey { get; set; }
        public string TrainingCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string StartDateStr { set { StartDate = value == "Today" ? DateTime.Today : DataHelpers.TryParse(value); } }
        public int DurationInMonths { get; set; }
        public string AgreedPrice { get; set; }
        public bool PilotStatus { get; set; } = false;
    }
}
