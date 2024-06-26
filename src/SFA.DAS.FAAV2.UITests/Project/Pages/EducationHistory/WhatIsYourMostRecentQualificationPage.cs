namespace SFA.DAS.FAAV2.UITests.Project.Pages.EducationHistory;

public class WhatIsYourMostRecentQualificationPage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "What is your most recent qualification";

    public AddQualificationSubjectPage SelectAQualificationAndContinue()
    {
        var randomOption = RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(RadioLabels).Take(5).ToList());

        formCompletionHelper.ClickElement(() => randomOption);
        Continue();
        return new(context, randomOption.Text);
    }
}
