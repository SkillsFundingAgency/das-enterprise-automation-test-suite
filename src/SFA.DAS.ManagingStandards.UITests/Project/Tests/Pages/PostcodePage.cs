namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class PostcodePage : ManagingStandardsBasePage
{
    protected override string PageTitle => "What is the postcode of this training venue?";

    private static By PostCodeField = By.Id("Postcode");
    public PostcodePage(ScenarioContext context) : base(context) { }

    public ChooseTheAddressPage EnterPostcodeAndContinue()
    {
        formCompletionHelper.EnterText(PostCodeField, managingStandardsDataHelpers.PostCode);
        Continue();
        return new ChooseTheAddressPage(context);
    }
}
