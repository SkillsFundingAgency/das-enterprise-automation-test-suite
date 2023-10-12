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

    protected void EnterAutoSelect(string text)
    {
        void WaitForElementToChange(string value) => pageInteractionHelper.WaitForElementToChange(SearchTerm, AttributeHelper.AriaExpanded, value);

        formCompletionHelper.ClickElement(() =>
        {
            formCompletionHelper.EnterText(SearchTerm, text);

            WaitForElementToChange("true");

            pageInteractionHelper.WaitUntilAnyElements(SearchList);

            if (pageInteractionHelper.FindElements(SearchList).All(x => x.Text.Contains(text)))
            {
                throw new WebDriverException($"Auto pop up not found for text : {text}");
            }

            SetDebugInformation($"verified all elements : '{SearchList}' contains {text}'");

            return RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(SearchList));
        });

        SetDebugInformation($"Clicked an auto dropdown element using : {text}");

        WaitForElementToChange("false");

        formCompletionHelper.Click(SearchTerm);
    }
}

