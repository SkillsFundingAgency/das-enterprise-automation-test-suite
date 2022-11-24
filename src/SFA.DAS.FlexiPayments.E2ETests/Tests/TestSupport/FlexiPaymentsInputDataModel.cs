using System;

namespace SFA.DAS.FlexiPayments.E2ETests.Tests.TestSupport
{
    public class FlexiPaymentsInputDataModel
    {
        public string ULN { get; set; }
        public string TrainingCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime ActualStartDate { get; set; }
        public DateTime PlannedEndDate { get; set; }
        public string AgreedPrice { get; set; }
    }
}
