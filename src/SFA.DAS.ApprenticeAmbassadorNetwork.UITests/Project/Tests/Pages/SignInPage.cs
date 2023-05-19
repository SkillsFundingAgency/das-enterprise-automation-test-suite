using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages;

public class SignInPage : AanBasePage
{
    protected override string PageTitle => "Sign in to My apprenticeship";

    private By UsernameField => By.Id("Username");

    private By PasswordField => By.Id("Password");

    private By SignInButton => By.XPath("//button[@value='Sign in']");

    public SignInPage(ScenarioContext context) : base(context) => VerifyPage();

    public void SubmitValidUserDetails(string username, string password)
    {
        formCompletionHelper.EnterText(UsernameField, username);
        formCompletionHelper.EnterText(PasswordField, password);
        formCompletionHelper.ClickElement(SignInButton);
    }

}
