namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public abstract class ProvideFeedbackBasePage : VerifyBasePage
{
    protected override By PageHeader => By.CssSelector(".govuk-heading-xl, .heading-xlarge, .govuk-heading-l, .govuk-panel__title, .govuk-fieldset__heading");

    protected static By Labels => By.CssSelector(".multiple-choice label");

    protected ProvideFeedbackBasePage(ScenarioContext context, bool verifypage = true) : base(context)
    {
        if (verifypage) VerifyPage();
    }

    protected void OpenFeedbackUsingSurveyCode() => tabHelper.GoToUrl(UrlConfig.ProviderFeedback_BaseUrl, objectContext.GetUniqueSurveyCode());

    protected void SelectOptionAndContinue() => SelectOptionAndContinue(Labels);

    protected void SelectOptionAndContinue(By selector)
    {
        List<string> checkboxList = pageInteractionHelper.FindElements(selector).Select(x => x.Text).Where(y => !string.IsNullOrEmpty(y)).ToList();

        for (int i = 0; i <= 2; i++)
        {
            var randomoption = RandomDataGenerator.GetRandomElementFromListOfElements(checkboxList);
            formCompletionHelper.SelectCheckBoxByText(selector, randomoption);
            checkboxList.Remove(randomoption);
        }

        Continue();
    }
}