using SFA.DAS.FAAV2.UITests.Project.Tests.Pages;

namespace SFA.DAS.FAAV2.UITests.Project.Pages.ApplicationOverview;

public class CheckYourApplicationBeforeSubmittingPage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "Check your application before submitting";

    protected override By ContinueButton => By.CssSelector("button.govuk-button[data-module='govuk-button']");

    public ApplicationSubmittedPage SubmitApplication()
    {
        SelectCheckBoxByText("I understand that I won't be able to make any changes after I submit my application");

        Continue();

        return new(context);
    }
}

