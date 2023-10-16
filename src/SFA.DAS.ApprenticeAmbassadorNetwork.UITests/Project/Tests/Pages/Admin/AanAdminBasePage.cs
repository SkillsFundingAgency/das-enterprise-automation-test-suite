using NUnit.Framework;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin;

public abstract class AanAdminBasePage : AanBasePage
{
    protected readonly AanAdminDatahelper aanAdminDatahelper;

    protected override By ContinueButton => By.CssSelector("#continue");

    private static By SearchTerm => By.CssSelector("input#SearchTerm");

    private static By SearchList => By.CssSelector("#SearchTerm__listbox li");

    protected override By PageHeader => By.CssSelector("#main-content");

    public AanAdminBasePage(ScenarioContext context, bool verifyPage = true) : base(context, verifyPage)
    {
        aanAdminDatahelper = context.GetValue<AanAdminDatahelper>();
    }

    protected void SelectAutoDropDown(string text)
    {
        formCompletionHelper.EnterText(SearchTerm, text);

        context.Get<RetryAssertHelper>().RetryOnNUnitException(() =>
        {
            if (pageInteractionHelper.FindElements(SearchList).Count <= 1)
            {
                Assert.Fail($"Auto pop up not found for text : {text}");
            }

        }, RetryTimeOut.GetTimeSpan(new int[] { 10, 5, 5, 5 }));

        formCompletionHelper.ClickElement(() =>
        {
            var element = RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(SearchList));

            SetDebugInformation($"Clicked an auto dropdown element : '{element?.Text}'");

            return element;
        });
    }
}
