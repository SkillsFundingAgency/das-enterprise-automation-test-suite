using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    internal sealed class FindAnApprenticeShipPage : BasePage
    {
        #region Constants
        private const string PageTitle = "";
        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly FormCompletionCampaignsHelper _formCompletionCampaignsHelper;
        #endregion

        #region Page Object Elements
        private readonly By _selectInterestDropDown = By.XPath("//div[@class='grid-column-two-thirds']//select[@id='Route']");
        private readonly By _postCodeBox = By.XPath("//div[@class='grid-column-two-thirds']//input[@id='Postcode']");
        private readonly By _selectMilesDropDown = By.XPath("//div[@class='grid-column-two-thirds']//select[@id='Distance']");
        private readonly By _searchButton = By.XPath("//button[@class='button button-apprentice']");
        #endregion

        public FindAnApprenticeShipPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _formCompletionCampaignsHelper = context.Get<FormCompletionCampaignsHelper>();
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

        internal void selectAValidInterest(String interestValue)
        {
            _formCompletionCampaignsHelper.SelectFromDropDownByText(_selectInterestDropDown, interestValue);
        }

        internal void enterPostCode(String postCode)
        {
            _formCompletionHelper.EnterText(_postCodeBox, postCode);
        }

        internal void selectMiles(String noOfMiles)
        {
            _formCompletionCampaignsHelper.SelectFromDropDownByText(_selectMilesDropDown, noOfMiles);
        }

        internal void clickOnSearchButton()
        {
            _formCompletionHelper.ClickElement(_searchButton);
        }

    }
}
