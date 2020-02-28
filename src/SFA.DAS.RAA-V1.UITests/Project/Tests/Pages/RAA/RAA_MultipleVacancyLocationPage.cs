using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_MultipleVacancyLocationPage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Vacancy location";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By EnterVacancyLocation => By.Id("postcode-search");
        private By AddressResults => By.CssSelector(".ui-menu-item");
        private By NumberOfVacancy => By.Id("addresses_0__numberofpositions");
        private By NumberOfVacancy2 => By.Id("addresses_1__numberofpositions");
        private By AdditionalLocationInformation => By.Id("AdditionalLocationInformation");
        private By SaveAndContinueButton => By.Name("AddLocations");
        private By AddAnotherLocation => By.CssSelector("#add-new-location");

        public RAA_MultipleVacancyLocationPage(ScenarioContext context) : base(context) => _context = context;

        public RAA_MultipleVacancyLocationPage AddLocation(string text)
        {
            formCompletionHelper.EnterText(EnterVacancyLocation, text);

            formCompletionHelper.ClickElement(() =>
            {
                pageInteractionHelper.WaitUntilAnyElements(AddressResults);

                return pageInteractionHelper.FindElement(AddressResults);
            });

            return new RAA_MultipleVacancyLocationPage(_context);
        }

        public RAA_MultipleVacancyLocationPage ClickAddAnotherLocationLink()
        {
            formCompletionHelper.Click(AddAnotherLocation);
            return this;
        }

        public RAA_MultipleVacancyLocationPage EnterAdditionalLocationInformation()
        {
            formCompletionHelper.EnterText(AdditionalLocationInformation, dataHelper.AdditionalLocationInformation);
            return this;
        }

        public RAA_MultipleVacancyLocationPage EnterNumberOfVacancy()
        {
            formCompletionHelper.EnterText(NumberOfVacancy, dataHelper.NumberOfVacancy);
            return this;
        }

        public RAA_MultipleVacancyLocationPage EnterNumberOfVacancy2()
        {
            formCompletionHelper.EnterText(NumberOfVacancy2, dataHelper.NumberOfVacancy);
            return this;
        }
        public void ClickSaveAndContinue()
        {
            formCompletionHelper.Click(SaveAndContinueButton);
        }
    }
}
