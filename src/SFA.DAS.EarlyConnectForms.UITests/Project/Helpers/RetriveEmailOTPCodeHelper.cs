using Mailosaur;
using Mailosaur.Models;
using NUnit.Framework.Constraints;
using SFA.DAS.FrameworkHelpers;
using System;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Helpers
{
    public class RetriveEmailOTPCodeHelper
    {
        public RetriveEmailOTPCodeHelper(string email)
        {
            var apiKey = "yvODYD5LfqCcF7hG6hjsS3999aYqC0L5";
            var serverId = "szs3qaml";

            var mailosaur = new MailosaurClient(apiKey);

            var criteria = new SearchCriteria()
            {
                Subject = "Confirm your email address – Department for education"

            };
            var emailMessage = mailosaur.Messages.Get(serverId, criteria);
            Console.WriteLine(emailMessage.Html.Codes[0].Value);
            AuthCodes = emailMessage.Html.Codes[0].Value;
        }

        public string AuthCodes { get; set; }

    }
}
