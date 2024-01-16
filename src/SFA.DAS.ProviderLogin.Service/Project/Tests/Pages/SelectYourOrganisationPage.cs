
using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport.CheckPage;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

public class CheckSelectYourOrganisationPage(ScenarioContext context) : CheckPageTitleLongerTimeOut(context)
{
    protected override string PageTitle => SelectYourOrganisationPage.SyoPageTitle;

    protected override By Identifier => PageHeader;
}

public class SelectYourOrganisationPage(ScenarioContext context) : ProviderLoginBasePage(context)
{
    private static By Organisaitons => By.CssSelector("#organisation .govuk-radios__item");

    private static By OrganisationLabel => By.CssSelector(".govuk-label--s");

    protected override string PageTitle => SyoPageTitle;

    public static string SyoPageTitle => "Select your organisation";

    public ProviderHomePage SelectOrganisation(string ukprn)
    {
        var option = pageInteractionHelper.GetElementByText(Organisaitons, $"UKPRN: {ukprn}");

        formCompletionHelper.ClickElement(option.FindElement(OrganisationLabel));

        Continue();

        return new ProviderHomePage(context);
    }
}