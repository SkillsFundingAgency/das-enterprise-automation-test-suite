namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;

public class ApprenticeMessagePage : AppEmpCommonBasePage
{
    protected override string PageTitle => ApprenticeName;

    private readonly string ApprenticeName;

    private static By CodeOfConduct => By.CssSelector("input[id='hasAgreedToCodeOfConduct']");

    private static By SendMessageButton => By.CssSelector("[id='sendMessage']");

    public ApprenticeMessagePage(ScenarioContext context, bool isRegionalChair) : base(context, false)
    {
        VerifyPage(() => pageInteractionHelper.FindElement(EventTag), isRegionalChair ? ["Regional chair", "Regional Chair"] : ["Apprentice"]);
    }

    public ApprenticeMessagePage(ScenarioContext context, string ApprenticeName) : base(context, false)
    {
        this.ApprenticeName = ApprenticeName;

        VerifyPage();
    }

    public ApprenticeMessagePage GoToApprenticeMessagePage((string id, string fullname) apprentice)
    {
        GoToId(apprentice.id);

        return new ApprenticeMessagePage(context, apprentice.fullname);
    }

    public SucessfullySentMessagePage SendMessage(string message)
    {
        SelectRadioOptionByText(message);

        SelectCheckBoxByText("my details including my name");

        formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(CodeOfConduct));

        formCompletionHelper.Click(SendMessageButton);

        return new SucessfullySentMessagePage(context);
    }
}
