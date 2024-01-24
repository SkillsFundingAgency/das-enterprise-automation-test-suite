using Microsoft.VisualBasic;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;

public class YourAmbassadorProfilePage(ScenarioContext context) : AanBasePage(context)
{
    protected override string PageTitle => "Your ambassador profile";

    private static By ChangeForPersonalDetailsLink => By.XPath("//a[contains(@href,'/edit-personal-information')]");
    private static By ChangeForInterestInNetworkLink => By.XPath("//a[contains(@href,'/edit-area-of-interest')]");
    private static By ChangeForApprenticeshipInformationLink => By.XPath("//a[contains(@href,'/edit-apprenticeship-information')]");
    private static By ChangeForContactDetailsLink => By.XPath("//a[contains(@href,'/edit-contact-detail')]");
    private static By SummaryValue => By.CssSelector(".govuk-summary-list__value");

    public void VerifyYourAmbassadorProfile(string value) => VerifyPage(() => pageInteractionHelper.FindElements(SummaryValue), value);

    public YourPersonalDetailsPage AccessChangeForPersonalDetails()
    {
        formCompletionHelper.ClickElement(ChangeForPersonalDetailsLink);
        return new YourPersonalDetailsPage(context);
    }

    public InterestIinTheNetworkPage AccessChangeForInterestInNetwork()
    {
        formCompletionHelper.ClickElement(ChangeForInterestInNetworkLink);
        return new InterestIinTheNetworkPage(context);
    }

    public YourApprenticeshipInformationPage AccessChangeForApprenticeshipInformation()
    {
        formCompletionHelper.ClickElement(ChangeForApprenticeshipInformationLink);
        return new YourApprenticeshipInformationPage(context);
    }

    public ContactDetailsPage AccessChangeForContactDetails()
    {
        formCompletionHelper.ClickElement(ChangeForContactDetailsLink);
        return new ContactDetailsPage(context);
    }
}