namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentOpportunity;

public class AO_ApprovedStandardDetailsPage : EPAO_BasePage
{
    protected override string PageTitle => "Abattoir worker";

    public AO_ApprovedStandardDetailsPage(ScenarioContext context) : base(context) => VerifyPage();
      
    public AO_ApprovedStandardDetailsPage IsApprovedStandardDetailsPageDisplayed() => this;
}
