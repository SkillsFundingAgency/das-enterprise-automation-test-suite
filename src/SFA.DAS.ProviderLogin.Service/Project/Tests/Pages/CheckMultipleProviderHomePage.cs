using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport.CheckPage;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

public abstract class CheckMultipleProviderHomePage(ScenarioContext context) : CheckPageTitleShorterTimeOut(context)
{
    public abstract string[] PageIdentifierCss { get; }

    public abstract string[] PageTitles { get; }

    protected override By Identifier => By.CssSelector($"{string.Join(", ", PageIdentifierCss.Select(x => x).ToList())}");

    protected bool ActualDisplayedPage(string page) => ActualDisplayedPage().Contains(page);

    private string ActualDisplayedPage()
    {
        string displayedPage = string.Empty;

        IsPageDisplayed(() =>
        {
            SetDebugInformation($"Check that {string.Join(" OR ", PageTitles.Select(x => $"'{x}'"))} is displayed using Page title");

            (bool result, string actualPage) = checkPageInteractionHelper.VerifyPage(() => checkPageInteractionHelper.FindElements(Identifier), PageTitles.ToList());

            displayedPage = actualPage;

            return result;
        });

        return displayedPage;
    }
}
