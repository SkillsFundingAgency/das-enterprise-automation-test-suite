namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class YourContactInformationForThisStandardPage : ManagingStandardsBasePage
{
    protected override string PageTitle => "Your contact information for this standard";

    private static By EmailAddressTextBox => By.Id("ContactUsEmail");
    private static By TelephoneNumberTextBox => By.Id("ContactUsPhoneNumber");
    private static By ContactPageTextBox => By.Id("ContactUsPageUrl");
    private static By YourWebsitePageTextBox => By.Id("StandardInfoUrl");
    private static By SaveAndContinueButton => By.Id("submit");

    public YourContactInformationForThisStandardPage(ScenarioContext context) : base(context)
    {
    }

    public ManageAStandard_TeacherPage UpdateContactInformation()
    {
        formCompletionHelper.EnterText(EmailAddressTextBox, managingStandardsDataHelpers.EmailAddress);
        formCompletionHelper.EnterText(TelephoneNumberTextBox, managingStandardsDataHelpers.ContactNumber);
        formCompletionHelper.EnterText(ContactPageTextBox, managingStandardsDataHelpers.ContactWebsite);
        formCompletionHelper.EnterText(YourWebsitePageTextBox, managingStandardsDataHelpers.Website);
        formCompletionHelper.Click(SaveAndContinueButton);
        return new ManageAStandard_TeacherPage(context);
    }

}
