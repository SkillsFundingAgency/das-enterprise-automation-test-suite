namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public abstract class EmployerFeedbackBasePage : ProvideFeedbackBasePage
{
    protected static By Labels => By.CssSelector(".multiple-choice label");

    protected EmployerFeedbackBasePage(ScenarioContext context, bool verifypage = true) : base(context, verifypage) { }

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