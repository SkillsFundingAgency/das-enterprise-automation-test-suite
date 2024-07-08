namespace SFA.DAS.FAA.UITests.Project.Tests.Pages.ApplicationQuestions;

public class WhatAreYourSkillsAndStrengthsPage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "What are your skills and strengths?";

    protected override By SubmitSectionButton => By.CssSelector("button.govuk-button[type='submit']");

    private static By SkillsAndStrengths => By.CssSelector("#SkillsAndStrengths");

    public FAA_ApplicationOverviewPage SelectYesAndCompleteSection()
    {
        formCompletionHelper.EnterText(SkillsAndStrengths, faaDataHelper.Strengths);

        return SelectSectionCompleted();
    }

    public new FAA_ApplicationOverviewPage SelectSectionCompleted()
    {
        SelectRadioOptionByForAttribute("IsSectionComplete");

        formCompletionHelper.Click(SubmitSectionButton);

        return new(context);
    }
}
