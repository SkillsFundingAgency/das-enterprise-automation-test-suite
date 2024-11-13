using Dynamitey;
using Mailosaur.Operations;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Employer;

public class ChangeEmployerName : RegistrationBasePage
{
    protected override string PageTitle => "Change your name";

    private static By FirstName => By.CssSelector("input#EmployerContactFirstName");

    private static By LastName => By.CssSelector("input#EmployerContactLastName");

    protected override By ContinueButton => By.CssSelector("button.govuk-button[id='continue'][type='submit']");

    public ChangeEmployerName(ScenarioContext context) : base(context) => VerifyPage();

    public CreateYourApprenticeshipServiceAccount ChangeName(string fName, string lName)
    {
        formCompletionHelper.EnterText(FirstName, $"Updated {fName}");

        formCompletionHelper.EnterText(LastName, $"Updated {lName}");

        Continue();

        return new CreateYourApprenticeshipServiceAccount(context);
    }
}

public class ReadTheEmployerAgreementPage : RegistrationBasePage
{
    protected override string PageTitle => "Read the employer agreement";

    private static By FirstName => By.CssSelector("input#EmployerContactFirstName");

    private static By LastName => By.CssSelector("input#EmployerContactLastName");

    protected override By ContinueButton => By.CssSelector("button.govuk-button[id='continue'][type='submit']");

    private static By ReturnToPreviousPage => By.LinkText("Return to previous page");

    public ReadTheEmployerAgreementPage(ScenarioContext context, string orgName) : base(context)
    {
        VerifyPage();

        VerifyPage(PageHeader, $"Agreement between {orgName.ToUpperInvariant()} and");
    }

    public CreateYourApprenticeshipServiceAccount ReturnToCreateYourApprenticeshipServiceAccountr()
    {
        formCompletionHelper.Click(ReturnToPreviousPage);

        return new CreateYourApprenticeshipServiceAccount(context);
    }
}
