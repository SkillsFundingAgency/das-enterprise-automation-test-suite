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
        private readonly By _selectInterestDropDown = By.Id("header-route");
        private readonly By _postCodeBox = By.Id("header-postcode");
        private readonly By _selectMilesDropDown = By.Id("header-distance");
        private readonly By _searchButton = By.Id("search-apprenticeship");
        private readonly By _messageForInvalidPostcode = By.Id("header-postcode-error");
        private readonly By _messageForInvalidInterestSelection = By.Id("header-route-error");
        private readonly By _defaultValueFromInterestDropDown = By.Id("header-distance");
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
