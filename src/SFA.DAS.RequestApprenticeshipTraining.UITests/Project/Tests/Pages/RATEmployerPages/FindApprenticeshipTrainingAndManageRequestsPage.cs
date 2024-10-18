using OpenQA.Selenium;
using SFA.DAS.FAT.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.RATEmployerPages;

public class FindApprenticeshipTrainingAndManageRequestsPage(ScenarioContext context) : RatProjectBasePage(context)
{
    protected override string PageTitle => "Find apprenticeship training and manage requests";

    public TrainingRequestDetailPage SelectActiveRequest()
    {
        string trainingRequestName = objectContext.GetTrainingCourseName();

        formCompletionHelper.Click(By.LinkText(trainingRequestName));

        return new(context, trainingRequestName);
    }
}