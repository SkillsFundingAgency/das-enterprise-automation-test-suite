
using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

public class SelectYourOrganisationPage(ScenarioContext context) : BasePage(context)
{
    private static By Organisaitons => By.CssSelector("#organisation .govuk-radios__item");

    private static By OrganisationLabel => By.CssSelector(".govuk-label--s");

    protected override string PageTitle => SyoPageTitle;

    protected override By PageHeader => SyoPageIdentifier;

    public static string SyoPageTitle => "Select your organisation";

    public static By SyoPageIdentifier => By.CssSelector(SyoPageIdentifierCss);

    public static string SyoPageIdentifierCss => ".govuk-heading-xl";

    public ProviderHomePage SelectOrganisation(string ukprn)
    {
        var option = pageInteractionHelper.GetElementByText(Organisaitons, $"UKPRN: {ukprn}");

        formCompletionHelper.ClickElement(option.FindElement(OrganisationLabel));

        Continue();

        return new ProviderHomePage(context);
    }
}