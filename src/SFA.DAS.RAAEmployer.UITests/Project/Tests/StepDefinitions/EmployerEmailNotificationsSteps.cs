using NUnit.Framework;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Login.Service.Project;
using SFA.DAS.MailosaurAPI.Service.Project.Helpers;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;
using SFA.DAS.RAA.DataGenerator;

namespace SFA.DAS.RAAEmployer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerEmailNotificationsSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext objectContext;
        private readonly MailosaurApiHelper mailosaurApiHelper;
        protected readonly VacancyTitleDatahelper vacancyTitleDataHelper;
        private readonly string employerEmail;
        private readonly string providerEmail;
        private readonly string applicantEmail;
        private readonly string foundationApplicantEmail;
        protected bool isFoundationAdvert;

        public EmployerEmailNotificationsSteps(ScenarioContext context)
        {
            _context = context;
            objectContext = context.Get<ObjectContext>();
            mailosaurApiHelper = context.Get<MailosaurApiHelper>();
            employerEmail = objectContext.GetRegisteredEmail();
            var providerConfig = context.Get<dynamic>("providerconfigkey");
            providerEmail = providerConfig.Username;
            vacancyTitleDataHelper = context.Get<VacancyTitleDatahelper>();
            applicantEmail = context.GetUser<FAAApplyUser>().Username;
            foundationApplicantEmail = context.GetUser<FAAFoundationUser>().Username;
            isFoundationAdvert = context.ContainsKey("isFoundationAdvert") && (bool)context["isFoundationAdvert"];
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
                    emailText = "DfE has rejected this advert. We’ve left a comment to explain why.";
                    subject = $"Rejected by DfE: make changes to {vacancyTitleDataHelper.VacancyTitle}";
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

                case ("approved advert", "employer"):
                    emailText = "DfE has approved this advert. It’s now live on Find an apprenticeship.";
                    subject = $"Approved by DfE: {vacancyTitleDataHelper.VacancyTitle} apprenticeship is now live on Find an apprenticeship";
                    userEmail = employerEmail;
                    break;

                case ("employer approved vacancy", "provider"):
                    emailText = "The employer has approved this vacancy. It’ll now be sent to DfE – you’ll get an email after we’ve reviewed it.";
                    subject = $"Approved by employer: {vacancyTitleDataHelper.VacancyTitle} apprenticeship now sent to DfE";
                    userEmail = providerEmail;
                    break;

                case ("employer rejected vacancy", "provider"):
                    emailText = "This vacancy has been reviewed and was rejected";
                    subject = $"Rejected: Updates needed to your vacancy (VAC{objectContext.GetVacancyReference()})";
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
                    emailText = "You’ve withdrawn your application for:";
                    subject = $"Application withdrawn: {vacancyTitleDataHelper.VacancyTitle}";
                    userEmail = isFoundationAdvert ? foundationApplicantEmail : applicantEmail;
                    break;

                case ("shared application", "employer"):
                    emailText = $"has sent you a new application to review for {vacancyTitleDataHelper.VacancyTitle}";
                    subject = "New apprenticeship application to review";
                    userEmail = employerEmail;
                    break;

                case ("employer listed you as training provider", "provider"):
                    emailText = $"An employer’s listed you as the training provider on this vacancy. Contact the employer if you were not expecting this.";
                    subject = "An employer’s listed you as the training provider on a vacancy";
                    userEmail = providerEmail;
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
