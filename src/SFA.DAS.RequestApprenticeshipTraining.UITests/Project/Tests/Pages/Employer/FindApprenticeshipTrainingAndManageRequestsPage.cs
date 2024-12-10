using DnsClient;
using Mailosaur.Models;
using OpenQA.Selenium;
using SFA.DAS.FAT.UITests.Project;
using SFA.DAS.FAT.UITests.Project.Tests.Pages;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.Employer;

public class FindApprenticeshipTrainingAndManageRequestsPage(ScenarioContext context) : RatProjectBasePage(context)
{
    protected override string PageTitle => "Find apprenticeship training and manage requests";

    private static By FindAppTraining => By.CssSelector("a[href*='/courses']");

    public TrainingRequestDetailPage SelectActiveRequest()
    {
        string trainingCourseName = objectContext.GetTrainingCourseName();

        var link = By.LinkText(trainingCourseName);

        string href = pageInteractionHelper.FindElement(link).GetHrefAttribute();

        SetDebugInformation($"Active request href - {href}");

        var requestId = GenerateGuidRegexHelper.FindGuidRegex().Match(href).Value;

        SetDebugInformation($"Found request id - {requestId}");

        formCompletionHelper.Click(link);

        ratDataHelper.TrainingCourse = trainingCourseName;

        ratDataHelper.RequestId = requestId;

        return new(context, trainingCourseName);
    }

    public ApprenticeshipTrainingCoursesPage GoToApprenticeshipTrainingCourses()
    {
        formCompletionHelper.Click(FindAppTraining);

        return new(context);
    }
}
