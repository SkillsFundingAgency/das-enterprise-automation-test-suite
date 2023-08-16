
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

//pas login changes (do not remove this class)
public class SelectYourOrganisationPage : ProviderLoginBasePage
{
    private static By Organisaitons => By.CssSelector("#organisation .govuk-radios__item");

    private static By OrganisationLabel => By.CssSelector(".govuk-label--s");

    public SelectYourOrganisationPage(ScenarioContext context) : base(context) { }

    protected override string PageTitle => "Select your organisation";

    public ProviderHomePage SelectOrganisation(string ukprn)
    {
        var option = pageInteractionHelper.GetElementByText(Organisaitons, $"UKPRN: {ukprn}");

        formCompletionHelper.ClickElement(option.FindElement(OrganisationLabel));

        Continue();

        return new ProviderHomePage(context);
    }
}