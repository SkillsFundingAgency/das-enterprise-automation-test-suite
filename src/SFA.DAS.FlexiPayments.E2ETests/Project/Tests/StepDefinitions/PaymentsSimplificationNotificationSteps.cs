using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.MailosaurAPI.Service.Project.Helpers;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Tests.StepDefinitions
{
    [Binding]
    public class PaymentsSimplificationNotificationSteps(ScenarioContext context)
    {
        private readonly ScenarioContext context = context;

        [When(@"Employer is notified that a provider has requested a price change through email")]
        public void EmployerIsNotifiedThatAProviderHasRequestedAPriceChangeThroughEmail()
        {
            var tabHelper = context.Get<TabHelper>();

            var objectContext = context.Get<ObjectContext>();

            var providerConfig = context.GetProviderConfig<ProviderConfig>();

            var mailosaurApiHelper = context.Get<MailosaurApiHelper>();

            var emailText = $"{providerConfig.Name} has requested a change to the total agreed apprenticeship price for";

            string subject = $"{providerConfig.Name} requested a price change";

            var email = objectContext.GetRegisteredEmail();

            var emailMessage = mailosaurApiHelper.GetEmailBody(email, subject, emailText);

            StringAssert.Contains(emailText, emailMessage.Text.Body);

            var link = mailosaurApiHelper.GetLinkFromMessage(emailMessage, $"/{objectContext.GetHashedAccountId()}/apprentices/");

            tabHelper.OpenInNewTab(link);
        }
    }
}
