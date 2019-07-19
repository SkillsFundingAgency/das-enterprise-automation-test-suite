using SFA.DAS.CreateAccount.UITests.Project.Framework.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Apprentices
{
    class AddApperentieceFillFormPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "FirstName")] private IWebElement _firstNameInput;
        [FindsBy(How = How.Id, Using = "LastName")] private IWebElement _lastNameInput;
        [FindsBy(How = How.Id, Using = "DateOfBirth_Day")] private IWebElement _birthDayDayInput;
        [FindsBy(How = How.Id, Using = "DateOfBirth_Month")] private IWebElement _birthDayMonthInput;
        [FindsBy(How = How.Id, Using = "DateOfBirth_Year")] private IWebElement _birthDayYearInput;
        [FindsBy(How = How.Id, Using = "StartDate_Month")] private IWebElement _startDateMonthInput;
        [FindsBy(How = How.Id, Using = "StartDate_Year")] private IWebElement _startDateYearInput;
        [FindsBy(How = How.Id, Using = "EndDate_Month")] private IWebElement _endDateMonthInput;
        [FindsBy(How = How.Id, Using = "EndDate_Year")] private IWebElement _endDateYearthInput;
        [FindsBy(How = How.Id, Using = "Cost")] private IWebElement _costInput;
        [FindsBy(How = How.XPath, Using = ".//*[@type=\'submit\']")] private IWebElement _addButton;
        [FindsBy(How = How.Id, Using = "select2-TrainingCode-container")] private IWebElement _trainingSelectElement;
        [FindsBy(How = How.XPath, Using = ".//*[@class=\'select2-results\']//li[3]")] private IWebElement _trainingSelectResultComponent;

        public AddApperentieceFillFormPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        public AddApperentieceFillFormPage FillUserName(string firstName, string lastName)
        {
            formCompletionHelper.EnterText(_firstNameInput, firstName);
            formCompletionHelper.EnterText(_lastNameInput, lastName);
            return this;
        }

        public AddApperentieceFillFormPage FillBirthDay(string day, string month, string year)
        {
            formCompletionHelper.EnterText(_birthDayDayInput, day);
            formCompletionHelper.EnterText(_birthDayMonthInput, month);
            formCompletionHelper.EnterText(_birthDayYearInput, year);
            return this;
        }

        public AddApperentieceFillFormPage SelectTrainingCource()
        {
            _trainingSelectElement.Click();
            _trainingSelectResultComponent.Click();
            return this;
        }

        public AddApperentieceFillFormPage FillStartDate(string month, string year)
        {
            formCompletionHelper.EnterText(_startDateMonthInput, month);
            formCompletionHelper.EnterText(_startDateYearInput, year);
            return this;
        }

        public AddApperentieceFillFormPage FillEndDate(string month, string year)
        {
            formCompletionHelper.EnterText(_endDateMonthInput, month);
            formCompletionHelper.EnterText(_endDateYearthInput, year);
            return this;
        }

        public AddApperentieceFillFormPage FillCost(string cost)
        {
            formCompletionHelper.EnterText(_costInput, cost);
            return this;
        }

        public void Add()
        {
            formCompletionHelper.ClickElement(_addButton);
        }
    }
}