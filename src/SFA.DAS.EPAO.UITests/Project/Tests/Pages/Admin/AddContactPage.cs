namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public class AddContactPage : OrganisationSectionsBasePage
{
    protected override string PageTitle => "Add a contact";

    private static By FirstName => By.CssSelector("#FirstName");

    private static By LastName => By.CssSelector("#LastName");

    private static By Email => By.CssSelector("#Email");

    private static By PhoneNumber => By.CssSelector("#PhoneNumber");

    public AddContactPage(ScenarioContext context) : base(context) => VerifyPage();

    public ContactDetailsPage AddContact()
    {
        formCompletionHelper.EnterText(FirstName, ePAOAdminDataHelper.GivenNames);
        formCompletionHelper.EnterText(LastName, ePAOAdminDataHelper.FamilyName);
        formCompletionHelper.EnterText(Email, ePAOAdminDataHelper.Email);
        formCompletionHelper.EnterText(PhoneNumber, ePAOAdminDataHelper.PhoneNumber);
        Continue();
        return new(context);
    }
}
