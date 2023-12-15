using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_IncreaseVacancyWagePage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Increase vacancy wage";

        #region Helpers and Context       
        private readonly FAADataHelper _faaDataHelper;
        #endregion

        private By CurrentWage => By.CssSelector("#vacancy-wage");
        private By AmountLowerBound => By.CssSelector("#AmountLowerBound");
        private By AmountUpperBound => By.CssSelector("#AmountUpperBound");
        private By RangeUnit => By.CssSelector("#RangeUnit");
        private By CustomWageLabel => By.CssSelector("#custom-wage-label");


        public RAA_IncreaseVacancyWagePage(ScenarioContext context) : base(context) => _faaDataHelper = context.Get<FAADataHelper>();

        public RAA_IncreaseVacancyWagePreviewPage SaveAndReturn()
        {
            string currentwage;

            if (pageInteractionHelper.IsElementDisplayed(CustomWageLabel))
            {
                currentwage = RegexHelper.GetVacancyCurrentWage(pageInteractionHelper.GetText(AmountLowerBound));
            }
            else
            {
                currentwage = RegexHelper.GetVacancyCurrentWage(pageInteractionHelper.GetText(CurrentWage));

                formCompletionHelper.SelectRadioOptionByText("Custom wage");

                formCompletionHelper.SelectRadioOptionByText("Wage range");
            }

            int.TryParse(currentwage, out int newMinWage);

            newMinWage = newMinWage == 0 ? 200 : (newMinWage + RAAV1DataHelper.RandomNumber);

            int newMaxWage = newMinWage + RAAV1DataHelper.RandomNumber;

            _faaDataHelper.NewCustomMinWagePerWeek = newMinWage.ToString();
            _faaDataHelper.NewCustomMaxWagePerWeek = newMaxWage.ToString();

            formCompletionHelper.EnterText(AmountLowerBound, newMinWage.ToString());

            formCompletionHelper.EnterText(AmountUpperBound, newMaxWage.ToString());

            formCompletionHelper.SelectFromDropDownByValue(RangeUnit, "Weekly");

            formCompletionHelper.ClickButtonByText("Save and return");

            return new RAA_IncreaseVacancyWagePreviewPage(context);
        }
    }
}
