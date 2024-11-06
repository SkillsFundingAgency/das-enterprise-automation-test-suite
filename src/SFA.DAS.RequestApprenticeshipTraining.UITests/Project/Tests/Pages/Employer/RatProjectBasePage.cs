using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.Employer;

public abstract class RatProjectBasePage : VerifyBasePage
{
    protected readonly RatDataHelper ratDataHelper;

    protected RatProjectBasePage(ScenarioContext context, bool verifyPage = true) : base(context) 
    {
        if (verifyPage) VerifyPage();

        ratDataHelper = context.GetValue<RatDataHelper>();
    }

    protected override By ContinueButton => By.CssSelector("[id='main-content'] button.govuk-button[type='submit']");
}