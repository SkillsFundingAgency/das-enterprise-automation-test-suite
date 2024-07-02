using Mailosaur;
using Mailosaur.Models;
using System;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Helpers
{
    public class RetriveEmailOTPCodeHelper
    {
        public RetriveEmailOTPCodeHelper()
        {
            var apiKey = "yvODYD5LfqCcF7hG6hjsS3999aYqC0L5";
            var serverId = "szs3qaml";

            var mailosaur = new MailosaurClient(apiKey);

            var criteria = new SearchCriteria()
            {
                Subject = "Confirm your email address – Department for education"
               
            };
            var email = mailosaur.Messages.Get(serverId, criteria);

          //  Console.WriteLine("Subject: " + email.Html.Codes.Count); 
            Console.WriteLine(email.Html.Codes[0].Value);

            AuthCodes = email.Html.Codes[0].Value;

        }

        public string AuthCodes { get; set; }
      
    }
}
