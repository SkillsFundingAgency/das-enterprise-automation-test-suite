using NUnit.Framework;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.MailosaurAPI.Service.Project.Helpers;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAEmployer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerEmailNotificationsSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext objectContext;
        private readonly MailosaurApiHelper mailosaurApiHelper;
        private readonly string employerEmail;
        private readonly string providerEmail;

        public EmployerEmailNotificationsSteps(ScenarioContext context)
        {
            _context = context;
            objectContext = context.Get<ObjectContext>();
            mailosaurApiHelper = context.Get<MailosaurApiHelper>();
            employerEmail = objectContext.GetRegisteredEmail();
            var providerConfig = context.Get<dynamic>("providerconfigkey");
            providerEmail = providerConfig.Username;
        }

        [Then(@"the '(.*)' receives '(.*)' email notification")]
        public void ThenTheEmployerReceivesEmailNotification(string userType, string notificationType)
        {
            string emailText = null;
            string subject = null;
            string userEmail = null;

            switch (notificationType, userType)
            {
                case ("new application", "employer"):
                    emailText = "There has been 1 new application";
                    subject = $"You have a new application for VAC{objectContext.GetVacancyReference()}";
                    userEmail = employerEmail;
                    break;

                case ("rejected advert", "employer"):
                    emailText = "The apprenticeship advert needs some changes";
                    subject = $"Rejected: Updates needed to your apprenticeship advert (VAC{objectContext.GetVacancyReference()})";
                    userEmail = employerEmail;
                    break;

                case ("rejected vacancy", "provider"):
                    emailText = "The vacancy needs some changes";
                    subject = $"Rejected: Updates needed to your vacancy (VAC{objectContext.GetVacancyReference()})";
                    userEmail = providerEmail;
                    break;

                case ("employer review", "employer"):
                    emailText = "Your advert needs to be reviewed";
                    subject = $"Review your advert (VAC{objectContext.GetVacancyReference()})";
                    userEmail = employerEmail;
                    break;

                default:
                    Assert.Fail($"Unknown notification type: {notificationType}");
                    break;
            }

            var emailMessage = mailosaurApiHelper.GetEmailBody(userEmail, subject, emailText);
            StringAssert.Contains(emailText, emailMessage.Text.Body);
        }
    }
}
