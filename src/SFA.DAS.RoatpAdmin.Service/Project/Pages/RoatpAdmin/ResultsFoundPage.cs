using System;

namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class ResultsFoundPage(ScenarioContext context) : RoatpAdminBasePage(context)
{
    protected override string PageTitle => $"Details for";

    private static By OnBoardingStatus => By.XPath("//strong[text()='On-boarding']");

    private static By ActiveStatus => By.XPath("//strong[text()='Active']");

    private static By ProviderType => By.XPath("(//td[@class='govuk-table__cell'])[1]");

    private static By OrganisationType => By.XPath("(//td[@class='govuk-table__cell'])[3]");

    private static By ApplicationDeterminedDate => By.XPath("(//td[@class='govuk-table__cell  govuk-!-width-two-thirds'])[2]");

    private static By RefineSearch => By.LinkText("Refine search");

    private static string MainAndEmployerStatus => "On-boarding";

    private static string SupportingStatus => "Active";

    private static string ApplicationDetermineDate => "30 Nov 1980";

    private static By StatusChange => By.XPath("(//a[@class='govuk-link'])[1]");
    private static By ProviderTypeChange => By.XPath("(//a[@class='govuk-link'])[2]");
    private static By OrganisationTypeChange => By.XPath("(//a[@class='govuk-link'])[3]");
    private static By ApprenticeshipUnitsChange => By.XPath("(//a[@class='govuk-link'])[4]");

    public void VerifyProvideType(string providerType) => pageInteractionHelper.VerifyText(ProviderType, providerType);

    public void VerifyOrganisationType() => pageInteractionHelper.VerifyText(OrganisationType, objectContext.GetOrganisationType());

    public void VerifyApplicationDeterminedDate() => pageInteractionHelper.VerifyText(ApplicationDeterminedDate, DateTime.Now.ToString("dd MMM yyyy"));

    public void VerifyApplicationDeterminedDateNotUpdated() => pageInteractionHelper.VerifyText(ApplicationDeterminedDate, ApplicationDetermineDate);

    public SearchPage GoToSearchPage()
    {
        formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("/providers"));
        return new SearchPage(context);
    }

    //public ChangeLegalNamePage ClickChangeLegalNameLink()
    //{
    //    formCompletionHelper.ClickElement(() => 
    //    return new ChangeLegalNamePage(context);
    //}

    //public ChangeUkprnPage ClickChangeUkprnLink()
    //{
    //    formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("change-ukprn"));
    //    return new ChangeUkprnPage(context);
    //}

    public ChangeStatusPage ClickChangeStatusLink()
    {
        formCompletionHelper.ClickElement(StatusChange);
        return new ChangeStatusPage(context);
    }

    public ChangeProviderTypePage ClickChangeProviderTypeLink()
    {
        formCompletionHelper.ClickElement(ProviderTypeChange);
        return new ChangeProviderTypePage(context);
    }

    public ChangeOrganisationTypePage ClickChangeOrganisationTypeLink()
    {
        formCompletionHelper.ClickElement(OrganisationTypeChange);
        return new ChangeOrganisationTypePage(context);
    }

    public OfferApprenticeshipsUnitsPage ClickChangeOfferApprenticeshipUnitLink()
    {
        formCompletionHelper.ClickElement(ApprenticeshipUnitsChange);
        return new OfferApprenticeshipsUnitsPage(context);
    }

    //public ChangeCompanyNumberPage ClickChangeCompanyNumberLink()
    //{
    //    formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("change-company-number"));
    //    return new ChangeCompanyNumberPage(context);
    //}

    //public ChangeCharityRegistrationNumberPage ClickChangeCharityNumberLink()
    //{
    //    formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("change-charity-registration-number"));
    //    return new ChangeCharityRegistrationNumberPage(context);
    //}

    //public ChangeApplicationDateDeterminedPage ClickChangeApplicationDateDeterminedLink()
    //{
    //    formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("change-application-date-determined"));
    //    return new ChangeApplicationDateDeterminedPage(context);
    //}

    //public bool VerifyMultipleMatchingResults() => VerifyElement(RefineSearch);

    //public void VerifyOneProviderNameResultFound() => pageInteractionHelper.VerifyText(PageHeader, $"1 result found for '{objectContext.GetProviderName()}'");

    //public void VerifyOneProviderUkprnResultFound() => pageInteractionHelper.VerifyText(PageHeader, $"1 result found for '{objectContext.GetUkprn()}'");

    //public void VerifyNoProviderUkprnResultFound() => pageInteractionHelper.VerifyText(PageHeader, $"No results found for '{objectContext.GetUkprn()}'");

    public ResultsFoundPage VerifyProviderStatusAsOnBoarding()
    {
        pageInteractionHelper.VerifyText(OnBoardingStatus, MainAndEmployerStatus);

        return this;
    }

    public ResultsFoundPage VerifyProviderStatusAsActive()
    {
        pageInteractionHelper.VerifyText(ActiveStatus, SupportingStatus);

        return this;
    }
}