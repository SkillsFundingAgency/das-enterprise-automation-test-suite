using NUnit.Framework;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.MailosaurAPI.Service.Project.Helpers;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Tests.StepDefinitions;

[Binding]
public class PaymentsSimplificationNotificationSteps
{
    private readonly ScenarioContext _context;
    private readonly ObjectContext objectContext;
    private readonly ProviderConfig providerConfig;
    private readonly MailosaurApiHelper mailosaurApiHelper;
    private readonly TabHelper tabHelper;
    private readonly string email;

    public PaymentsSimplificationNotificationSteps(ScenarioContext context)
    {
        _context = context;
        objectContext = context.Get<ObjectContext>();
        providerConfig = context.GetProviderConfig<ProviderConfig>();
        mailosaurApiHelper = context.Get<MailosaurApiHelper>();
        tabHelper = context.Get<TabHelper>();
        email = objectContext.GetRegisteredEmail();
    }

    [When(@"Employer is notified that a provider has requested a price change through email")]
    public void EmployerIsNotifiedThatAProviderHasRequestedAPriceChangeThroughEmail()
    {
        var emailText = $"{providerConfig.Name} has requested a change to the total agreed apprenticeship price for";

        string subject = $"{providerConfig.Name} requested a price change";

        ValidateEmployerEmailBodyAndLinkText(emailText, subject);
    }

    [Then(@"Employer is notified that the provider has approved a price change through email")]
    public void EmployerIsNotifiedThatTheProviderHasApprovedAPriceChangeThroughEmail()
    {
        var emailText = $"{providerConfig.Name} has approved the change to the total agreed apprenticeship price for";

        string subject = $"{providerConfig.Name} approved a price change";

        ValidateEmployerEmailBodyAndLinkText(emailText, subject);
    }


    [Then(@"Employer is notified that the provider has rejected a price change through email")]
    public void EmployerIsNotifiedThatTheProviderHasRejectedAPriceChangeThroughEmail()
    {
        var emailText = $"{providerConfig.Name} has declined the change to the total agreed apprenticeship price for";

        string subject = $"{providerConfig.Name} declined a price change";

        ValidateEmployerEmailBodyAndLinkText(emailText, subject);
    }

    [When(@"Employer is notified that the provider has requested a change of Start Date through email")]
    public void EmployerIsNotifiedThatTheProviderHasRequestedAChangeOfStartDateThroughEmail()
    {
        var emailText = $"{providerConfig.Name} has requested a change to the actual training start date for";

        string subject = $"{providerConfig.Name} requesting a change of start date";

        ValidateEmployerEmailBodyAndLinkText(emailText, subject);
    }


    private void ValidateEmployerEmailBodyAndLinkText(string emailText, string subject)
    {
        var emailMessage = mailosaurApiHelper.GetEmailBody(email, subject, emailText);

        StringAssert.Contains(emailText, emailMessage.Text.Body);

        var link = mailosaurApiHelper.GetLinkFromMessage(emailMessage, $"/{objectContext.GetHashedAccountId()}/apprentices/");

        tabHelper.OpenInNewTab(link);
    }
}
