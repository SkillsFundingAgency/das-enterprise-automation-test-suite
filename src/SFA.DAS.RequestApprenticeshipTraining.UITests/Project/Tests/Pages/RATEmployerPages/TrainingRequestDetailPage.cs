using OpenQA.Selenium;
using SFA.DAS.FAT.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.RATEmployerPages;

public class TrainingRequestDetailPage : FATBasePage
{
    protected override string PageTitle => trainingRequestName;

    protected override bool DoVerifyPage => false;

    private static string trainingRequestName;

    private static By CancelRequest => By.LinkText("cancel your request");

    public TrainingRequestDetailPage(ScenarioContext context, string requestName) : base(context)
    {
        trainingRequestName = requestName;

        VerifyPage();
    }

    public CancelYourRequestPage CancelYourRequest()
    {
        formCompletionHelper.Click(CancelRequest);

        return new(context);
    }
}