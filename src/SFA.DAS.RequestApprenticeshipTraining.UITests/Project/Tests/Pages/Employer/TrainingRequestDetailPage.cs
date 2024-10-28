using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.Employer;

public class TrainingRequestDetailPage : RatProjectBasePage
{
    protected override string PageTitle => trainingRequestName;

    private static string trainingRequestName;

    private static By CancelRequest => By.LinkText("cancel your request");

    private static By SummaryAnswers => By.CssSelector(".govuk-heading-m, .govuk-summary-list__value");

    public TrainingRequestDetailPage(ScenarioContext context, string requestName) : base(context, false)
    {
        trainingRequestName = requestName;

        VerifyPage();
    }

    public CancelYourRequestPage CancelYourRequest()
    {
        formCompletionHelper.Click(CancelRequest);

        return new(context);
    }

    public void VerifyProviderResponse()
    {
        MultipleVerifyPage(
        [
            () => VerifyFromMultipleElements(SummaryAnswers, ratDataHelper.ProviderEmail),
            () => VerifyFromMultipleElements(SummaryAnswers, ratDataHelper.ProviderName)
        ]);
    }
}