using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    internal sealed class FindAnApprenticeShipViaMyInterestsPage : BasePage
    {
        #region Constants
        private const string ExpectedPageTitle = "ENGINEERING AND MANUFACTURING";
        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly FormCompletionCampaignsHelper _formCompletionCampaignsHelper;
        #endregion

        #region Page Object Elements
        private readonly By _pageTitle = By.XPath("//h1[@class='heading-xl hero-heading__heading']");
        private readonly By _postCodeBox = By.Id("Postcode");
        private readonly By _selectMilesDropDown = By.Id("Distance");
        private readonly By _searchButton = By.XPath("//button[@class='button button--shadow']");
        #endregion

        public FindAnApprenticeShipViaMyInterestsPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _formCompletionCampaignsHelper = context.Get<FormCompletionCampaignsHelper>();
            VerifyPage();
        }

        protected override bool VerifyPage()
        {
            return _pageInteractionHelper.VerifyPage(_pageTitle, ExpectedPageTitle);
        }

        internal void enterPostCode(String postCode)
        {
            _pageInteractionHelper.WaitForElementToBeDisplayed(_postCodeBox);
            _formCompletionHelper.EnterText(_postCodeBox, postCode);
        }

        internal void selectMiles(String noOfMiles)
        {
            _pageInteractionHelper.WaitForElementToBeDisplayed(_selectMilesDropDown);
            _formCompletionCampaignsHelper.SelectFromDropDownByText(_selectMilesDropDown, noOfMiles);
        }

        internal void clickOnSearchButton()
        {
            _pageInteractionHelper.WaitForElementToBeClickable(_searchButton);
            _formCompletionHelper.ClickElement(_searchButton);
        }

    }
}
