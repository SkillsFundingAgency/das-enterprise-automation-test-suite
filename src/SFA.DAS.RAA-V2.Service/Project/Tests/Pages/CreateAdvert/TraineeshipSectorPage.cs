using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;

public class TraineeshipSectorPage(ScenarioContext context, bool verifypage = true) : Raav2BasePage(context, verifypage)
{
    private static By SectorId => By.CssSelector("#SelectedRouteId");
    protected override string PageTitle => "Select the traineeship sector";
    protected override By ContinueButton => By.CssSelector(".govuk-button.save-button");

    public SummaryOfTheApprenticeshipPage EnterTrainingTitle()
    {
        EnterTrainingTitleAction();

        return new SummaryOfTheApprenticeshipPage(context);
    }

    private void EnterTrainingTitleAction()
    {
        formCompletionHelper.SelectFromDropDownByText(SectorId, RAAV2DataHelper.SectorName);

        formCompletionHelper.Click(PageHeader);

        formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ContinueButton));
    }
}