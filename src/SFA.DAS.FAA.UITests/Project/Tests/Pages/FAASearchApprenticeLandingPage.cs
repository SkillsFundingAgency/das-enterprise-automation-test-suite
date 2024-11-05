using Polly;
using SFA.DAS.FAA.UITests.Project.Tests.Pages.SignUp;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages;

public class FAASearchApprenticeLandingPage(ScenarioContext context) : FAASignedInLandingBasePage(context)
{
    protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

    protected override string PageTitle => "Search apprenticeships";

    private static By SettingsLink => By.LinkText("Settings");
    private static By EmailAddress => By.Id("Email");
    private static By DeleteMyAccount => By.Id("Email");



    //public FAASearchApprenticeLandingPage PerformDeleteAccount()
    //{

    //    string email = context.Get<string>("UserEmail");

    //    formCompletionHelper.Click(SettingsLink);
    //    formCompletionHelper.ClickLinkByText("Delete my account");
    //    Continue();
    //    formCompletionHelper.EnterText(EmailAddress, email);
    //    formCompletionHelper.Click(DeleteMyAccount);

    //    return new FAASearchApprenticeLandingPage(context);
    //}


    public void PerformDeleteAccount()
        {

            string email = context.Get<string>("UserEmail");

            formCompletionHelper.Click(SettingsLink);
            formCompletionHelper.ClickLinkByText("Delete my account");
            Continue();
            formCompletionHelper.EnterText(EmailAddress, email);
            formCompletionHelper.Click(DeleteMyAccount);
        }

}
