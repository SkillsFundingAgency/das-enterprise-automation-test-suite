namespace SFA.DAS.Registration.UITests.Project.Tests.Pages;

public class HowMuchIsYourOrgAnnualPayBillPage : RegistrationBasePage
{
    protected override string PageTitle => "How much is your organisation's annual pay bill?";
    protected override By ContinueButton => By.Id("submit-add-a-paye-scheme-button");

    public HowMuchIsYourOrgAnnualPayBillPage(ScenarioContext context) : base(context) => VerifyPage();

    public AddAPAYESchemePage SelectOptionLessThan3Million()
    {
        formCompletionHelper.SelectRadioOptionByText("Less than £3 million");
        formCompletionHelper.ClickElement(ContinueButton);
        return new AddAPAYESchemePage(context);
    }

    public AddPayeSchemeUsingGGDetailsPage SelectOptionCloseTo3Million()
    {
        formCompletionHelper.SelectRadioOptionByText("Close to £3 million");
        formCompletionHelper.ClickElement(ContinueButton);
        return new AddPayeSchemeUsingGGDetailsPage(context);
    }

    public CreateYourEmployerAccountPage GoBackToCreateYourEmployerAccountPage()
    {
        formCompletionHelper.Click(BackLink);
        return new CreateYourEmployerAccountPage(context);
    }
}
