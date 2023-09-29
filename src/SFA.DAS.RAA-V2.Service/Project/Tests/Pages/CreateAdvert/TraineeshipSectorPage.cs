using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;

public class TraineeshipSectorPage : Raav2BasePage
{
    private static By SectorId => By.CssSelector("#SelectedRouteId");
    protected override string PageTitle => "Select the traineeship sector";
    protected override By ContinueButton => By.CssSelector(".govuk-button.save-button");
    public TraineeshipSectorPage(ScenarioContext context, bool verifypage = true) : base(context, verifypage)
    {
    }
        
    public SummaryOfTheApprenticeshipPage EnterTrainingTitle()
    {
        EnterTrainingTitleAction();

        return new SummaryOfTheApprenticeshipPage(context);
    }

    private void EnterTrainingTitleAction()
    {
        formCompletionHelper.SelectFromDropDownByText(SectorId, rAAV2DataHelper.SectorName);

        formCompletionHelper.Click(PageHeader);

        formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ContinueButton));
    }
}