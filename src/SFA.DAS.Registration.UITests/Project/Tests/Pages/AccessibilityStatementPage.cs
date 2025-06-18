namespace SFA.DAS.Registration.UITests.Project.Tests.Pages;

public class AccessibilityStatementPage : RegistrationBasePage
{
    protected override string PageTitle => "Accessibility statement";

    protected override bool CanAnalyzePage => false;

    public AccessibilityStatementPage(ScenarioContext context) : base(context) => VerifyPage();
}