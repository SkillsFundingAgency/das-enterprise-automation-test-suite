using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YouveLoggedOutPage : RegistrationBasePage
    {
        protected override string PageTitle => "You've signed out";

        protected override bool TakeFullScreenShot => false;

        #region Locators
        protected override By ContinueButton => By.LinkText("Continue");
        #endregion

        public YouveLoggedOutPage(ScenarioContext context) : base(context) => pageInteractionHelper.Verify(() =>
        {
            var result = IsPageCurrent;

            return result.Item1 ? result.Item1 : throw new Exception(MessageHelper.GetExceptionMessage("Page", PageTitle, result.Item2));

        }, () => pageInteractionHelper.WaitUntilAnyElements(ContinueButton));

        public CreateAnAccountToManageApprenticeshipsPage CickContinueInYouveLoggedOutPage()
        {
            Continue();
            return new CreateAnAccountToManageApprenticeshipsPage(context);
        }
    }
}
