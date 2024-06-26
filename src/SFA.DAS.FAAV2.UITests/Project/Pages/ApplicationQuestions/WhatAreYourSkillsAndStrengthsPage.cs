namespace SFA.DAS.FAAV2.UITests.Project.Pages.ApplicationQuestions;

public class WhatAreYourSkillsAndStrengthsPage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "What are your skills and strengths?";

    private static By SkillsAndStrengths => By.CssSelector("#SkillsAndStrengths");

    public FAA_ApplicationOverviewPage SelectYesAndCompleteSection()
    {
        formCompletionHelper.EnterText(SkillsAndStrengths, faaDataHelper.Strengths);

        SelectRadioOptionByForAttribute("IsSectionCompleted");

        Continue();

        return new(context);
    }
}
