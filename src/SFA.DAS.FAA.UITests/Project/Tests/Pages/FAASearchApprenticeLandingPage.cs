using NUnit.Framework;
using Polly;
using SFA.DAS.FAA.UITests.Project.Tests.Pages.SignUp;
using System.Collections.Generic;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages;

public class FAASearchApprenticeLandingPage(ScenarioContext context) : FAASignedInLandingBasePage(context)
{
    protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

    protected override string PageTitle => "Search apprenticeships";

    private static By SettingsLink => By.LinkText("Settings");
    private static By EmailAddress => By.Id("Email");
    private static By DeleteMyAccount => By.CssSelector(".govuk-button.govuk-button--warning");
    private static By DeleteConfirmatioBanner => By.CssSelector(".govuk-notification-banner__heading");

    public void PerformDeleteAccount()
        {
            string email = context.Get<string>("UserEmail");
        
        formCompletionHelper.Click(SettingsLink);
            formCompletionHelper.ClickLinkByText("Delete my account");
            Continue();
            formCompletionHelper.EnterText(EmailAddress, email);
            formCompletionHelper.Click(DeleteMyAccount);
        Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(DeleteConfirmatioBanner), "Find an apprenticeship account deleted.");
    }

}
