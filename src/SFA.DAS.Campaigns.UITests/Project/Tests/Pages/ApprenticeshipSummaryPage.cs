using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    internal sealed class ApprenticeshipSummaryPage : BasePage
    {
        #region Constants
        private const string PageTitle = "";
        private const string ExpectedApprenticeshipSummaryHeader = "Apprenticeship summary";
        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        #region Page Object Elements
        private readonly By _apprenticeshipSummaryHeader = By.XPath("(//div[@class='column-full']/child::h2)[1]");
        private readonly By _signInToApplyButton = By.XPath("//a[@id='apply-button']");
        #endregion

        public ApprenticeshipSummaryPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        protected override bool VerifyPage()
        {
            return _pageInteractionHelper.VerifyPage(this.GetPageHeading(), PageTitle);
        }

        internal bool IsPageMatching()
        {
            return _pageInteractionHelper.VerifyPage(this.GetPageHeading(), PageTitle);
        }

        internal void verifyApprenticeSummaryPageHeader()
        {
            _pageInteractionHelper.VerifyPage(_apprenticeshipSummaryHeader, ExpectedApprenticeshipSummaryHeader);
        }

        internal void clickObSignInToApplyButton()
        {
            _formCompletionHelper.ClickElement(_signInToApplyButton);
        }

    }
}
