using SFA.DAS.FlexiPayments.E2ETests.Project.Helpers;
using System;
using System.ComponentModel;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Tests.TestSupport
{
    public  class FlexiPaymnetsApprenticeshipsDataModel
    {
        public DateTime? StartDate;

        public int ULNKey { get; set; }
        public Boolean IsPilot { get; set; }
        public string StartDateStr { set { StartDate = value == "Today" ? DateTime.Today : DataHelpers.TryParseDate(value); } }
        public DateTime PlannedEndDate { get; set; }
        public double AgreedPrice { get; set; }
        public FundingType FundingType { get; set; }
        public double FundingBandMaximum { get; set; }
    }

    public enum FundingType
    {
        [Description("Levy")]
        Levy = 0,
        [Description("Non Levy")]
        NonLevy = 1,
        [Description("Transfer")]
        transfer = 2
    }
}
