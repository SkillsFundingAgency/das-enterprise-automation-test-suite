namespace SFA.DAS.FAA.UITests.Project.Tests.Pages;

public abstract class FAABasePage : VerifyBasePage
{
    #region Helpers and Context
    protected readonly FAADataHelper faaDataHelper;
    protected readonly FAAUserNameDataHelper fAAUserNameDataHelper;
    protected readonly AdvertDataHelper advertDataHelper;
    protected readonly VacancyTitleDatahelper vacancyTitleDataHelper;
    #endregion

    protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

    protected virtual By SubmitSectionButton => By.CssSelector("button.govuk-button[id='submit-button']");

    protected FAABasePage(ScenarioContext context, bool verifyPage = true) : base(context)
    {
        vacancyTitleDataHelper = context.Get<VacancyTitleDatahelper>();

        faaDataHelper = context.Get<FAADataHelper>();

        fAAUserNameDataHelper = context.Get<FAAUserNameDataHelper>();

        advertDataHelper = context.GetValue<AdvertDataHelper>();

        if (verifyPage) VerifyPage();
    }

    protected bool IsFoundationAdvert => context.ContainsKey("isFoundationAdvert") && (bool)context["isFoundationAdvert"];
    private static By FoundationTag => By.CssSelector(".govuk-tag--pink");
    public void CheckFoundationTag()
    {
        var expectedFoundationTag = "Foundation";
        var actualFoundationTag = pageInteractionHelper.GetText(FoundationTag).Trim();
        pageInteractionHelper.VerifyText(actualFoundationTag, expectedFoundationTag);
    }

    public FAA_ApplicationOverviewPage SelectSectionCompleted()
    {
        SelectRadioOptionByForAttribute("IsSectionCompleted");

        formCompletionHelper.Click(SubmitSectionButton);

        return new(context);
    }

    protected void GoToVacancyInFAA()
    {
        var vacancyRef = objectContext.GetVacancyReference();

        var uri = new Uri(new Uri(UrlConfig.FAA_BaseUrl), $"apprenticeship/VAC{vacancyRef}");

        tabHelper.GoToUrl(uri.AbsoluteUri);
    }

    protected FAASearchResultPage SearchUsingVacancyTitle()
    {
        var uri = new Uri(new Uri(UrlConfig.FAA_BaseUrl), $"apprenticeships?SearchTerm={vacancyTitleDataHelper.VacancyTitle}");

        tabHelper.GoToUrl(uri.AbsoluteUri);

        return new(context);
    }
}
