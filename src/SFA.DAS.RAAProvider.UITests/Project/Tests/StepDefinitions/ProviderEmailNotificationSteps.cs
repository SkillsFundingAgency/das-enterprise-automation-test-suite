using NUnit.Framework;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.MailosaurAPI.Service.Project.Helpers;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAProvider.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderEmailNotificationsSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext objectContext;
        private readonly MailosaurApiHelper mailosaurApiHelper;
        private readonly string employerEmail;
        private readonly string providerEmail;

        public ProviderEmailNotificationsSteps(ScenarioContext context)
        {
            _context = context;
            objectContext = context.Get<ObjectContext>();
            mailosaurApiHelper = context.Get<MailosaurApiHelper>();
            var providerConfig = context.Get<dynamic>("providerconfigkey");
            providerEmail = providerConfig.Username;
        }

        [Then(@"the provider receives '(.*)' email notification")]
        public void ThenTheEmployerReceivesEmailNotification(string notificationType)
        {
            string emailText = null;
            string subject = null;

            switch (notificationType)
            {
                case "new application":
                    emailText = "There has been 1 new application";
                    subject = $"You have a new application for VAC{objectContext.GetVacancyReference()}";
                    break;

                case "rejected vacancy":
                    emailText = "The apprenticeship advert needs some changes";
                    subject = $"Rejected: Updates needed to your apprenticeship advert (VAC{objectContext.GetVacancyReference()})";
                    break;

                default:
                    Assert.Fail($"Unknown notification type: {notificationType}");
                    break;
            }

            var emailMessage = mailosaurApiHelper.GetEmailBody(providerEmail, subject, emailText);
            StringAssert.Contains(emailText, emailMessage.Text.Body);
        }
    }
}
