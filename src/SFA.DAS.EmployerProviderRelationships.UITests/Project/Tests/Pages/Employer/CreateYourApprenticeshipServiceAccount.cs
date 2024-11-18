

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Employer;

public class CreateYourApprenticeshipServiceAccount : RegistrationBasePage
{
    protected override string PageTitle => "Create your apprenticeship service account";

    private static By ChangeNameSelector => By.LinkText("Change name");

    private static By ReadEmpAgreement => By.PartialLinkText("employer agreement between you and the Department for");

    private static By Decline => By.CssSelector("a[href*='createaccount/decline']");

    private static By HasAcceptedTerms => By.CssSelector(".govuk-checkboxes__label[for='HasAcceptedTerms']");

    private static By Accept => By.CssSelector("#main-content button.govuk-button[type='submit']");

    public CreateYourApprenticeshipServiceAccount(ScenarioContext context) : base(context) => VerifyPage();

    public ChangeEmployerName ChangeName()
    {
        formCompletionHelper.Click(ChangeNameSelector);

        return new ChangeEmployerName(context);
    }

    public ReadTheEmployerAgreementPage ReadAgreement(string orgName)
    {
        formCompletionHelper.Click(ReadEmpAgreement);

        return new ReadTheEmployerAgreementPage(context, orgName);
    }

    public ApprenticeshipServiceAccountCreatedPage CreateAccount()
    {
        formCompletionHelper.Click(HasAcceptedTerms);

        formCompletionHelper.Click(Accept);

        return new ApprenticeshipServiceAccountCreatedPage(context);
    }

    public DoNotCreateAccountPage DoNotCreateAccount()
    {
        formCompletionHelper.Click(Decline);

        return new DoNotCreateAccountPage(context);
    }
}
