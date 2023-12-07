using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Login.Service.Project.Tests.Pages;

public abstract class StubAddYourUserDetailsBasePage : VerifyBasePage
{
    protected override string PageTitle => "Add your user details";

    private static By FirstNameInput => By.CssSelector($"#FirstName, #GivenName");
    private static By LastNameInput => By.CssSelector($"#LastName, #FamilyName");
    protected override By ContinueButton => By.CssSelector("[id='main-content'] button.govuk-button");

    public StubAddYourUserDetailsBasePage(ScenarioContext context) : base(context) => VerifyPage();

    protected void EnterNameAndContinue(string firstName, string lastName)
    {
        formCompletionHelper.EnterText(FirstNameInput, firstName);
        formCompletionHelper.EnterText(LastNameInput, lastName);
        Continue();
    }
}
