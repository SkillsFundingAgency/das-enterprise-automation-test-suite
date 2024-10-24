using OpenQA.Selenium;
using SFA.DAS.FAT.UITests.Project;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.Employer;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.Provider;

public class EmployerRequestsForApprenticeshipTrainingPage(ScenarioContext context) : RatProjectBasePage(context)
{
    protected override string PageTitle => "Employer requests for apprenticeship training";

    #region Locators
    private static By StandardRow => By.CssSelector(".das-search-results__list-item");

    private static By ViewRequestLink => By.CssSelector(".das-search-results__list-item a");
    #endregion

    public SelectRequestToSharePage SelectStandard()
    {
        string trainingRequestName = objectContext.GetTrainingCourseName();

        SetDebugInformation($"Finding request for - {trainingRequestName}");

        var standards = pageInteractionHelper.FindElements(StandardRow).Select(x => x.Text.Replace("\r\n", " ")).ToList();

        SetDebugInformation($"Found {standards.Count} requests");

        var standardIndex = standards.FindIndex(x => x.ContainsCompareCaseInsensitive(trainingRequestName));

        SetDebugInformation($"Found index {standardIndex} for {standards[standardIndex]}");

        var viewRequests = pageInteractionHelper.FindElements(ViewRequestLink);

        SetDebugInformation($"Found {viewRequests.Count} view requests link");

        var viewRequestElement = viewRequests[standardIndex];

        formCompletionHelper.ClickElement(viewRequestElement);

        return new (context);
    }
}
