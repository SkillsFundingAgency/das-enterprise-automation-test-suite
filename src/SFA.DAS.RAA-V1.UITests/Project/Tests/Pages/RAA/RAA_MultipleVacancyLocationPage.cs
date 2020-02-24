using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_MultipleVacancyLocationPage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly RAAV1DataHelper _raadataHelper;
        private readonly string _scenarioTitle;
        #endregion

        private By EnterVacancyPostCode => By.Id("postcode-search");
        private By PostCodeResult => By.CssSelector(".ui-menu-item");
        private By NumberOfVacancy => By.Id("addresses_0__numberofpositions");
        private By NumberOfVacancy2 => By.Id("addresses_1__numberofpositions");
        private By AdditionalLocationInformation => By.Id("AdditionalLocationInformation");
        private By SaveAndContinueButton => By.Name("AddLocations");
        private By AddAnotherLocation => By.CssSelector("#add-new-location");

        public RAA_MultipleVacancyLocationPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _raadataHelper = context.Get<RAAV1DataHelper>();
            _scenarioTitle = context.ScenarioInfo.Title;
        }

        public RAA_MultipleVacancyLocationPage AddLocation(string postcode)
        {
            String[] Postcodes = postcode.Split(" ");
            string postCode1 = Postcodes[0];
            string postCode2 = Postcodes[1];
            formCompletionHelper.EnterText(EnterVacancyPostCode, postCode1);

            foreach (var letter in postCode2.ToCharArray())
            {
                formCompletionHelper.SendKeys(EnterVacancyPostCode, letter.ToString());
                List<IWebElement> postCodeResult = _pageInteractionHelper.FindElements(PostCodeResult);
                if (postCodeResult.Count == 0)
                {
                    continue;
                }
                try
                {
                    formCompletionHelper.ClickWebElement(postCodeResult[1]);
                    break;
                }
                catch (Exception ex)
                {
                    TestContext.Progress.WriteLine($"{Environment.NewLine}Scenario Title : {_scenarioTitle}{Environment.NewLine}Exception : {ex.Message}");
                }
            }
            return this;
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
        public RAA_MultipleVacancyLocationPage ConfirmIfOnLocationPage()
        {
            _pageInteractionHelper.WaitforURLToChange("/vacancy/locations");
            return this;
        }
        public void ClickSaveAndContinue()
        {
            formCompletionHelper.Click(SaveAndContinueButton);
        }
    }
}
