using SFA.DAS.FrameworkHelpers;
using System.Linq;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class EmailDomainHelper
    {
        private readonly string[] _tags;

        public EmailDomainHelper(string[] tags) => _tags = tags;

        internal string GetEmailDomain()
        {
            return _tags.Any(x => x.ContainsCompareCaseInsensitive("perftest")) ? "dasperfautomation.com" :
                  _tags.Any(x => x.ContainsCompareCaseInsensitive("mailinator")) ? "mailinator.com" : "dasautomation.com";
        }
    }
}
