namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.DiscretionaryExclusionSubSection;

public class AP_DDE_5_HmrcChallengesPage : EPAO_BasePage
{
    protected override string PageTitle => "HMRC challenges to tax returns";

    public AP_DDE_5_HmrcChallengesPage(ScenarioContext context) : base(context) => VerifyPage();

    public AP_DDE_6_ContractsWithdrawnFromYouPage SelectNoOptionAndContinueInHmrcChallengesPage()
    {
        SelectRadioOptionByForAttribute("A_DEL-23_1");
        Continue();
        return new(context);
    }
}
