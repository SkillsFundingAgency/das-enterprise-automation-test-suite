using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages
{
    public class MultipleVacancyLocationPage : BasePage
    {
        protected override string PageTitle => "";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        private readonly RAAV1DataHelper _dataHelper;
        #endregion

        private By EnterVacancyPostCode => By.Id("postcode-search");
        private By ClickOnPostCodeResult => By.CssSelector(".ui-menu-item");
        private By NumberOfVacancy => By.Id("addresses_0__numberofpositions");
        private By NumberOfVacancy2 => By.Id("addresses_1__numberofpositions");
        private By AdditionalLocationInformation => By.Id("AdditionalLocationInformation");
        private By SaveAndContinueButton => By.Name("AddLocations");
        private By AddAnotherLocation => By.CssSelector("#add-new-location");

        public MultipleVacancyLocationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<RAAV1DataHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public MultipleVacancyLocationPage ClickAddAnotherLocationLink()
        {
            _formCompletionHelper.Click(AddAnotherLocation);
            return this;
        }

        public MultipleVacancyLocationPage EnterPostCode(string postcode)
        {
            _formCompletionHelper.EnterText(EnterVacancyPostCode, postcode);
            return this;
        }

        public MultipleVacancyLocationPage ClickOnTheFirstAddress()
        {
            _formCompletionHelper.Click(ClickOnPostCodeResult);
            return this;
        }

        public MultipleVacancyLocationPage EnterAdditionalLocationInformation()
        {
            _formCompletionHelper.EnterText(AdditionalLocationInformation, _dataHelper.AdditionalLocationInformation);
            return this;
        }

        public MultipleVacancyLocationPage EnterNumberOfVacancy()
        {
            _formCompletionHelper.EnterText(NumberOfVacancy, _dataHelper.NumberOfVacancy);
            return this;
        }
        public MultipleVacancyLocationPage EnterNumberOfVacancy2()
        {
            _formCompletionHelper.EnterText(NumberOfVacancy2, _dataHelper.NumberOfVacancy);
            return this;
        }
        public MultipleVacancyLocationPage ConfirmIfOnLocationPage()
        {
            _pageInteractionHelper.WaitforURLToChange("/vacancy/locations");
            return this;
        }

        public MultipleVacancyLocationPage ClickSaveAndContinue()
        {
            _formCompletionHelper.Click(SaveAndContinueButton);
            return this;
        }
    }
}
