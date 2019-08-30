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
        protected override string PageTitle => "ENGINEERING AND MANUFACTURING";
        protected override By PageHeader => _pageTitle;
        #region Constants
        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
       // private readonly FormCompletionCampaignsHelper _formCompletionCampaignsHelper;
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
            base.VerifyPage();
        }

        internal void EnterPostCode(String postCode)
        {
            _pageInteractionHelper.WaitForElementToBeDisplayed(_postCodeBox);
            _formCompletionHelper.EnterText(_postCodeBox, postCode);
        }

        internal void SelectMiles(String noOfMiles)
        {
            _pageInteractionHelper.WaitForElementToBeDisplayed(_selectMilesDropDown);
            _formCompletionHelper.SelectFromDropDownByText(_selectMilesDropDown, noOfMiles);
        }

        internal void ClickOnSearchButton()
        {
            _pageInteractionHelper.WaitForElementToBeClickable(_searchButton);
            _formCompletionHelper.ClickElement(_searchButton);
        }

    }
}
