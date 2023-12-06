using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.StubPages;

public class StubAddYourUserDetailsPage : RoatpApplyBasePage
{
    protected override string PageTitle => "Add your user details";

    private static By FirstNameInput => By.CssSelector($"#FirstName");
    private static By LastNameInput => By.CssSelector($"#LastName");
    protected override By ContinueButton => By.CssSelector("[id='main-content'] button.govuk-button");

    public StubAddYourUserDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

    public ConfirmYourIdentityPage EnterNameAndContinue()
    {
        formCompletionHelper.EnterText(FirstNameInput, applyCreateUserDataHelpers.GivenName);
        formCompletionHelper.EnterText(LastNameInput, applyCreateUserDataHelpers.FamilyName);
        Continue();
        return new ConfirmYourIdentityPage(context);
    }
}
