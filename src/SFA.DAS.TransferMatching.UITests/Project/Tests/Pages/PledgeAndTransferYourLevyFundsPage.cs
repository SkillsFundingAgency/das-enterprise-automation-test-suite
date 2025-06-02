using FluentAssertions;
using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages;

public class PledgeAndTransferYourLevyFundsPage(ScenarioContext context) : TransferMatchingBasePage(context)
{
    protected override string PageTitle => "Pledge and transfer your levy funds";
    private static By Help => By.LinkText("Help");
    private static By AccessibilityStatement => By.LinkText("Accessibility statement");
    private static By Feedback => By.LinkText("Feedback");
    private static By Privacy => By.LinkText("Privacy");
    private static By Cookies => By.LinkText("Cookies");
    private static By BuiltBy => By.LinkText("Education and Skills Funding Agency");
    private static By CrownCopyright => By.LinkText("© Crown copyright");
    private static By ZenHelpWidgetScript => By.Id("ze-snippet");
    private static By StartCreatePledgesSelector => By.CssSelector("[href*='/pledges/create?']");

    public CreateATransferPledgePage StartCreatePledge()
    {
        formCompletionHelper.Click(StartCreatePledgesSelector);
        return new CreateATransferPledgePage(context);
    }

    public AccessibilityStatementPage GoToAccessibilityStatementPage()
    {
        formCompletionHelper.ClickElement(AccessibilityStatement);
        return new AccessibilityStatementPage(context);
    }

    public PledgeAndTransferYourLevyFundsPage ValidateFooter()
    {
        pageInteractionHelper.IsElementDisplayed(Help).Should().BeTrue();
        pageInteractionHelper.IsElementDisplayed(Feedback).Should().BeTrue();
        pageInteractionHelper.IsElementDisplayed(Privacy).Should().BeTrue();
        pageInteractionHelper.IsElementDisplayed(AccessibilityStatement).Should().BeTrue();
        pageInteractionHelper.IsElementDisplayed(Cookies).Should().BeTrue();
        pageInteractionHelper.IsElementDisplayed(BuiltBy).Should().BeTrue();
        pageInteractionHelper.IsElementDisplayed(CrownCopyright).Should().BeTrue();

        return this;
    }

    public PledgeAndTransferYourLevyFundsPage ValidateHelpWidget()
    {
        pageInteractionHelper.IsElementPresent(ZenHelpWidgetScript).Should().BeTrue();

        return this;
    }
}