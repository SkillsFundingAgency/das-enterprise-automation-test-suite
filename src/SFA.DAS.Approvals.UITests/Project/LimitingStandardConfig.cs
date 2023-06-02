using SFA.DAS.ProviderLogin.Service;
using System.Collections.Generic;

namespace SFA.DAS.Approvals.UITests.Project
{
    public class LimitingStandardConfig : ProviderConfig
    {
        public List<string> DoesNotOffer { get; internal set; }
    }
}
