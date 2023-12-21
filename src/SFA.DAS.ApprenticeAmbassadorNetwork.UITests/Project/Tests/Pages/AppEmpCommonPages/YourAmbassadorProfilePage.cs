namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;

public class YourAmbassadorProfilePage(ScenarioContext context) : AanBasePage(context)
{
    protected override string PageTitle => "Your ambassador profile";

    private static By SummaryValue => By.CssSelector(".govuk-summary-list__value");

    public void VerifyYourAmbassadorProfile(string value) => VerifyPage(() => pageInteractionHelper.FindElements(SummaryValue), value);
}