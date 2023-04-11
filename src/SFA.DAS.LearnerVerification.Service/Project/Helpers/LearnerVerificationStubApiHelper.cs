using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.LearnerVerification.Service.Project.Helpers
{
    public class LearnerVerificationStubApiHelper
    {
        public LearnerVerificationStubApiHelper(ScenarioContext context)
        {
            var lvConfig = context.GetLearnerVerificationProcessConfig<LearnerVerificationConfig>();
        }
    }

}
