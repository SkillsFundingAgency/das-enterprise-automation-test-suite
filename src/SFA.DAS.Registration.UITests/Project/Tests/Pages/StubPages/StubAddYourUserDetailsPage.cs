namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages;

public class StubAddYourUserDetailsPage(ScenarioContext context) : StubAddYourUserDetailsBasePage(context)
{
    public ConfirmYourUserDetailsPage EnterNameAndContinue(RegistrationDataHelper dataHelper)
    {
        EnterNameAndContinue(dataHelper.FirstName, dataHelper.LastName);

        return new ConfirmYourUserDetailsPage(context);
    }
}
