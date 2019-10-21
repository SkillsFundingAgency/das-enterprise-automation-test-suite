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
        protected override string PageTitle => "FIND AN APPRENTICESHIP";
        protected override By PageHeader => _pageTitle;
        #region Constants
        private const string ExpectedPageTitle = "FIND AN APPRENTICESHIP";
        private const string InvalidPostCodeMessage = "You must enter a full and valid postcode";
        private const string EmptyPostCodeMessage = "The Postcode field is required.";
        private const string MessageForInvalidInterestSelection = "The interest field is required.";
        private const string DefaultValueFromMilesDropDown = "5 miles";
        private string PostcodeFromTestScnario = "";
        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        #region Page Object Elements
        private readonly By _pageTitle = By.XPath("//h1[@class='heading-xl hero-heading__heading']");
        private readonly By _selectInterestDropDown = By.XPath("//div[@class='grid-column-two-thirds']//select[@id='Route']");
        private readonly By _postCodeBox = By.XPath("//div[@class='grid-column-two-thirds']//input[@id='Postcode']");
        private readonly By _selectMilesDropDown = By.XPath("//div[@class='grid-column-two-thirds']//select[@id='Distance']");
        private readonly By _searchButton = By.XPath("//button[@class='button button-apprentice']");
        private readonly By _messageForInvalidPostcode = By.Id("Postcode-error");
        private readonly By _messageForInvalidInterestSelection = By.Id("Route-error");
        private readonly By _defaultValueFromInterestDropDown = By.XPath("//div[@class='grid-column-two-thirds']//select[@id='Distance']/option[@selected='selected']");
        #endregion

        public FindAnApprenticeShipPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            base.VerifyPage();
        }

        internal void SelectAValidInterest(String interestValue)
        {
            _formCompletionHelper.SelectFromDropDownByText(_selectInterestDropDown, interestValue);
        }

        internal void EnterPostCode(String postCode)
        {
            PostcodeFromTestScnario = postCode;
            _formCompletionHelper.EnterText(_postCodeBox, postCode);
        }

        internal void SelectMiles(String noOfMiles)
        {
            _formCompletionHelper.SelectFromDropDownByText(_selectMilesDropDown, noOfMiles);
        }

        internal void ClickOnSearchButton()
        {
            _formCompletionHelper.ClickElement(_searchButton);
        }

        internal void VerifyInvalidPostcodeMessage()
        {
            if (PostcodeFromTestScnario.Length > 0)
            {
                _pageInteractionHelper.VerifyText(_messageForInvalidPostcode, InvalidPostCodeMessage);
            }
            else
            {
                _pageInteractionHelper.VerifyText(_messageForInvalidPostcode, EmptyPostCodeMessage);

            }
        }

        internal void VerifyTheMessageForNonSelectionOfInterest()
        {
            _pageInteractionHelper.VerifyText(_messageForInvalidInterestSelection, MessageForInvalidInterestSelection);
        }

        internal void VerifyDefaultValueFromMilesDropDown()
        {
            _pageInteractionHelper.VerifyText(_defaultValueFromInterestDropDown,DefaultValueFromMilesDropDown);
        }

    }
}
