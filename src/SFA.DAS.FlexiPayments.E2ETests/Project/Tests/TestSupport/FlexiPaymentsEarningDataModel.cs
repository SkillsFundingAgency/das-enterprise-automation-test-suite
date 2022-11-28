using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Tests.TestSupport
{
    public  class FlexiPaymentsEarningDataModel
    {
        public int ULNKey { get; set; }
        public double? TotalOnProgramPayment { get; set; }
        public double? MonthlyOnProgramPayment { get; set; }
        public int? NumberOfDeliveryMonths { get; set; }
    }
}
