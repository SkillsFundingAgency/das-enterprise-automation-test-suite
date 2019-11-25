using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_IncreaseVacancyWagePage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Increase vacancy wage";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private RegexHelper _regexHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        private By CurrentWage => By.CssSelector("#vacancy-wage");
        private By AmountLowerBound => By.CssSelector("#AmountLowerBound");
        private By AmountUpperBound => By.CssSelector("#AmountUpperBound");
        private By RangeUnit => By.CssSelector("#RangeUnit");
        private By CustomWageLabel => By.CssSelector("#custom-wage-label");


        public RAA_IncreaseVacancyWagePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _regexHelper = context.Get<RegexHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public RAA_IncreaseVacancyWagePreviewPage SaveAndReturn()
        {
            string currentwage;

            if (_pageInteractionHelper.IsElementDisplayed(CustomWageLabel))
            {
                currentwage = _regexHelper.GetVacancyCurrentWage(_pageInteractionHelper.GetText(AmountLowerBound));
            }
            else
            {
                currentwage = _regexHelper.GetVacancyCurrentWage(_pageInteractionHelper.GetText(CurrentWage));
                
                formCompletionHelper.SelectRadioOptionByText("Custom wage");

                formCompletionHelper.SelectRadioOptionByText("Wage range");
            }

            int.TryParse(currentwage, out int newMinWage);

            newMinWage = newMinWage == 0 ? 200 : (newMinWage + dataHelper.RandomNumber);

            int newMaxWage = newMinWage + dataHelper.RandomNumber;

            formCompletionHelper.EnterText(AmountLowerBound, newMinWage.ToString());

            formCompletionHelper.EnterText(AmountUpperBound, newMaxWage.ToString());

            formCompletionHelper.SelectFromDropDownByValue(RangeUnit, "Weekly");

            formCompletionHelper.ClickButtonByText("Save and return");

            return new RAA_IncreaseVacancyWagePreviewPage(_context);
        }
    }
}
