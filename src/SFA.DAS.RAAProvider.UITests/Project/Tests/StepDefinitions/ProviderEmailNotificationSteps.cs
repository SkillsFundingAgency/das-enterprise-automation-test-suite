using NUnit.Framework;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Login.Service.Project;
using SFA.DAS.MailosaurAPI.Service.Project.Helpers;
using SFA.DAS.RAA.DataGenerator;
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
        protected readonly VacancyTitleDatahelper vacancyTitleDataHelper;
        private readonly string providerEmail;
        private readonly string applicantEmail;
        private readonly string foundationApplicantEmail;
        protected bool isFoundationAdvert;

        public ProviderEmailNotificationsSteps(ScenarioContext context)
        {
            _context = context;
            objectContext = context.Get<ObjectContext>();
            mailosaurApiHelper = context.Get<MailosaurApiHelper>();
            var providerConfig = context.Get<dynamic>("providerconfigkey");
            providerEmail = providerConfig.Username;
            vacancyTitleDataHelper = context.Get<VacancyTitleDatahelper>();
            applicantEmail = context.GetUser<FAAApplyUser>().Username;
            foundationApplicantEmail = context.GetUser<FAAFoundationUser>().Username;
            isFoundationAdvert = context.ContainsKey("isFoundationAdvert") && (bool) context["isFoundationAdvert"];
        }

        [Then(@"the '(.*)' receives '(.*)' email notification")]
        public void ThenTheEmployerReceivesEmailNotification(string userType, string notificationType)
        {
            string emailText = null;
            string subject = null;
            string userEmail = null;

            switch (notificationType, userType)
            {
                case ("new application", "provider"):
                    emailText = "There has been 1 new application";
                    subject = $"You have a new application for VAC{objectContext.GetVacancyReference()}";
                    userEmail = providerEmail;
                    break;

                case ("rejected vacancy", "provider"):
                    emailText = "The apprenticeship advert needs some changes";
                    subject = $"Rejected: Updates needed to your apprenticeship advert (VAC{objectContext.GetVacancyReference()})";
                    userEmail = providerEmail;
                    break;

                case ("new application", "applicant"):
                    emailText = "We’ve received your application for:";
                    subject = $"Application submitted: {vacancyTitleDataHelper.VacancyTitle} apprenticeship";
                    userEmail = isFoundationAdvert ? foundationApplicantEmail : applicantEmail;
                    break;

                case ("successful application", "applicant"):
                    emailText = "Congratulations, you’ve been offered an apprenticeship:";
                    subject = $"Successful application: {vacancyTitleDataHelper.VacancyTitle} apprenticeship";
                    userEmail = isFoundationAdvert ? foundationApplicantEmail : applicantEmail;
                    break;

                case ("unsuccessful application", "applicant"):
                    emailText = "An application you’ve made has been unsuccessful:";
                    subject = $"Unsuccessful application: read your feedback for {vacancyTitleDataHelper.VacancyTitle} apprenticeship";
                    userEmail = isFoundationAdvert ? foundationApplicantEmail : applicantEmail;
                    break;

                case ("withdrawn application", "applicant"):
                    emailText = "You’ve withdrawn your application for";
                    subject = $"Application withdrawn: {vacancyTitleDataHelper.VacancyTitle}";
                    userEmail = isFoundationAdvert ? foundationApplicantEmail : applicantEmail;
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
