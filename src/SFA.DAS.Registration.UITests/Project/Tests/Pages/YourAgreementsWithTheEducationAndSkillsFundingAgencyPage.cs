namespace SFA.DAS.Registration.UITests.Project.Tests.Pages;

public class YourAgreementsWithTheEducationAndSkillsFundingAgencyPage : RegistrationBasePage
{
    protected override string PageTitle => "Your agreements with the Department for Education";

    #region Locators
    private static By UpdateTheseDetailsLink => By.LinkText("Update these details");

    private static By ExpandButton => By.CssSelector(".govuk-accordion__section-button");

    #endregion

    public YourAgreementsWithTheEducationAndSkillsFundingAgencyPage(ScenarioContext context, Action action) : base(context) => VerifyPage(PageHeader, PageTitle, action);

    public ReviewYourDetailsPage ClickUpdateTheseDetailsLinkInReviewYourDetailsPage()
    {
        ShowSection();

        formCompletionHelper.Click(UpdateTheseDetailsLink);

        return new ReviewYourDetailsPage(context);
    }

    public bool VerifyIfUpdateTheseDetailsLinkIsPresent()
    {
        ShowSection();

        return pageInteractionHelper.IsElementDisplayed(UpdateTheseDetailsLink);
    }

    private void ShowSection()
    {
        var e = pageInteractionHelper.FindElement(ExpandButton);

        var expand = e.GetDomAttribute(AttributeHelper.AriaExpanded);

        if (expand != null && expand == "false") formCompletionHelper.Click(ExpandButton);
    }
}

