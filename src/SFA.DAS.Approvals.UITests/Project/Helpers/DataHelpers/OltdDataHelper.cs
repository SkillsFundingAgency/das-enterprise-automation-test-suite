using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers
{
    public class OltdApprenticeDetails
    {
        public int NewStartDate { get; set; }
        public int NewEndDate { get; set; }
        public bool DisplayOverlapErrorOnStartDate { get; set; }
        public bool DisplayOverlapErrorOnEndDate { get; set; }
    }
}