namespace SFA.DAS.FAA.UITests.Project.Tests.Pages.ApplicationQuestions;

public class WhatInterestsYouAboutTThisApprenticeshipPage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "What interests you about this apprenticeship?";

    private static By AnswerText => By.CssSelector("#AnswerText");

    public FAA_ApplicationOverviewPage SelectYesAndCompleteSection()
    {
        formCompletionHelper.EnterText(AnswerText, faaDataHelper.HobbiesAndInterests);

        return SelectSectionCompleted();
    }
}
