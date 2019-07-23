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
        private const string PageTitle = "FIND AN APPRENTICESHIP";
        private const string InvalidPostCodeMessage = "You must enter a full and valid postcode";
        private const string EmptyPostCodeMessage = "The Postcode field is required.";
        private const string MessageForInvalidInterestSelection = "The interest field is required.";
        private const string DefaultValueFromMilesDropDown = "5 miles";
        private string PostcodeFromTestScnario = "";
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
        private readonly By _messageForInvalidPostcode = By.XPath("//span[@id='Postcode-error']");
        private readonly By _messageForInvalidInterestSelection = By.XPath("//span[@id='Route-error']");
        private readonly By _defaultValueFromInterestDropDown = By.XPath("//div[@class='grid-column-two-thirds']//select[@id='Distance']/option[@selected='selected']");
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
            _pageInteractionHelper.WaitForElementToBeDisplayed(_selectInterestDropDown);
            _formCompletionCampaignsHelper.SelectFromDropDownByText(_selectInterestDropDown, interestValue);
        }

        internal void enterPostCode(String postCode)
        {
            PostcodeFromTestScnario = postCode;
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

        internal void verifyInvalidPostcodeMessage()
        {
            if (PostcodeFromTestScnario.Length > 0)
            {
                _pageInteractionHelper.WaitForElementToBeDisplayed(_messageForInvalidPostcode);
                _pageInteractionHelper.VerifyText(_messageForInvalidPostcode, InvalidPostCodeMessage);
            }
            else
            {
                _pageInteractionHelper.WaitForElementToBeDisplayed(_messageForInvalidPostcode);
                _pageInteractionHelper.VerifyText(_messageForInvalidPostcode, EmptyPostCodeMessage);

            }
        }

        internal void verifyTheMessageForNonSelectionOfInterest()
        {
            _pageInteractionHelper.WaitForElementToBeDisplayed(_messageForInvalidInterestSelection);
            _pageInteractionHelper.VerifyText(_messageForInvalidInterestSelection, MessageForInvalidInterestSelection);
        }

        internal void verifyDefaultValueFromMilesDropDown()
        {
            _pageInteractionHelper.WaitForElementToBePresent(_defaultValueFromInterestDropDown);
            _pageInteractionHelper.VerifyText(_defaultValueFromInterestDropDown,DefaultValueFromMilesDropDown);
        }

    }
}
