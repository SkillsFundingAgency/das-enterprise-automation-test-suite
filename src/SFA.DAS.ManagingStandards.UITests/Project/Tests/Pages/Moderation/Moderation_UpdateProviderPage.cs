using NUnit.Framework;

namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages.Moderation;

public class Moderation_UpdateProviderPage : ManagingStandardsBasePage
{
    protected override string PageTitle => $"Update the provider description for {MS_DataHelper.ProviderName}";
    private static By UpdateDescriptionTextField => By.Id("ProviderDescription");
    private static By UpdatedText => By.CssSelector("p.app-preline");

    public Moderation_UpdateProviderPage(ScenarioContext context) : base(context) => VerifyPage();

    public Moderation_CheckProviderUpdatePage EnterUpdateDescriptionAndContinue()
    {
        formCompletionHelper.EnterText(UpdateDescriptionTextField, managingStandardsDataHelpers.UpdateProviderDescriptionText);
        Continue();
        return new Moderation_CheckProviderUpdatePage(context);
    }

    public void VerifyUpdateDescriptionText() => Assert.AreEqual(managingStandardsDataHelpers.UpdateProviderDescriptionText, pageInteractionHelper.GetText(UpdatedText));
}
