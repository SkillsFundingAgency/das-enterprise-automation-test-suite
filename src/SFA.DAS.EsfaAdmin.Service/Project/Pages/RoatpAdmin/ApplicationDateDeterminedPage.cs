using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EsfaAdmin.Service.Project.Pages.RoatpAdmin;

public class ApplicationDateDeterminedPage : RoatpAdminBasePage
{
    protected override string PageTitle => "What is the application determined date for this organisation?";

    protected override By ContinueButton => By.CssSelector(".govuk-button[value='Continue']");

    private static By Day => By.CssSelector("#Day");

    private static By Month => By.CssSelector("#Month");

    private static By Year => By.CssSelector("#Year");

    public ApplicationDateDeterminedPage(ScenarioContext context) : base(context) { }

    public ConfirmDetailsPage EnterDob()
    {
        formCompletionHelper.EnterText(Day, 30);
        formCompletionHelper.EnterText(Month, 11);
        formCompletionHelper.EnterText(Year, 1980);
        Continue();
        return new ConfirmDetailsPage(context);
    }

}
