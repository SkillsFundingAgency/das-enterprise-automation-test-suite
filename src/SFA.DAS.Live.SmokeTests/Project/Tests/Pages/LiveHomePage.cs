namespace SFA.DAS.Live.SmokeTests.Project.Tests.Pages;

public class LiveHomePage(ScenarioContext context) : HomePage(context)
{
    private static By HeaderSelector => By.CssSelector(".govuk-header__container a[href*='www.gov.uk']");

    private static By LauncherIframe => By.CssSelector("iframe[id='launcher']");

    private static By LauncherButton => By.CssSelector("button[data-testid='launcher']");

    private static By WebWidgetIframe => By.CssSelector("iframe[id='webWidget']");

    private static By WebWidgetTitle => By.CssSelector("h1[id='widgetHeaderTitle']");

    private static By FindApprenticeshipTrainingLink => By.LinkText("Find apprenticeship training and manage requests");

    public LiveHomePage VerifyHeaders() { VerifyElement(HeaderSelector); return this; }

    public void AccessHelpLauncher()
    {
        frameHelper.SwitchFrameAndAction(() =>
        {
            formCompletionHelper.ClickElement(pageInteractionHelper.FindElement(LauncherButton), false);
        },
        LauncherIframe);

        frameHelper.SwitchFrameAndAction(() =>
        {
            VerifyPage(WebWidgetTitle, "Apprenticeship Service Support");
        },
        WebWidgetIframe);
    }

    public FindApprenticeshipTrainingSearchPage GoToFatHomePage()
    {
        tabHelper.OpenInNewTab(() => formCompletionHelper.Click(FindApprenticeshipTrainingLink));

        return new FindApprenticeshipTrainingSearchPage(context);
    }
}