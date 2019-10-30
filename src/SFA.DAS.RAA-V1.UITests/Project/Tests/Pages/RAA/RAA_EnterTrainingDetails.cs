using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_EnterTrainingDetails : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Enter training details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly IWebDriver _webDriver;
        #endregion

        private By StandardsDropDownMenu => By.Id("StandardId");
        private By FrameworkDropDown => By.Id("s2id_FrameworkCodeName");
        private By FrameWorkDropdownTextEntry => By.CssSelector(".select2-input");
        private By ContactNameField => By.Id("ContactName");
        private By ContactumberField => By.CssSelector("#ContactNumber");
        private By EmailField => By.CssSelector("#ContactEmail");
        private By SaveAndContinueButton => By.Id("createVacancyButton");
        private By Iframe => By.CssSelector("iframe");
        private By TraineeshipDropdown => By.Id("s2id_SectorCodeName");
        private By TrainingBody => By.XPath("//body");


        public RAA_EnterTrainingDetails(ScenarioContext context) : base(context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
        }

        public RAA_EnterTrainingDetails SelectApprenticeshipType(string frameworkOrStanndard)
        {
            void SelectRandomCourse(By locator)
            {
                for (int i = 0; i < dataHelper.RandomCourse; i++)
                {
                    formCompletionHelper.SendKeys(locator, Keys.ArrowDown);
                }
                formCompletionHelper.SendKeys(locator, Keys.Enter);
            }

            switch (frameworkOrStanndard)
            {
                case "Framework":
                    formCompletionHelper.SelectRadioOptionByText("Framework");
                    formCompletionHelper.Click(FrameworkDropDown);
                    SelectRandomCourse(FrameWorkDropdownTextEntry);
                    formCompletionHelper.SelectRadioOptionByText("Intermediate");
                    break;

                case "Standard":
                    formCompletionHelper.SelectRadioOptionByText("Standard");
                    formCompletionHelper.Click(StandardsDropDownMenu);
                    formCompletionHelper.SelectFromDropDownByValue(StandardsDropDownMenu, "208");
                    break;

                case "Traineeship":
                    formCompletionHelper.Click(TraineeshipDropdown);
                    SelectRandomCourse(FrameWorkDropdownTextEntry);
                    break;
            }
            return this;
        }

        public RAA_EnterTrainingDetails EnterTrainingToBeProvided()
        {
            _webDriver.SwitchTo().Frame(_webDriver.FindElement(Iframe));
            formCompletionHelper.EnterText(TrainingBody, dataHelper.TrainingDetails);
            _webDriver.SwitchTo().DefaultContent();
            return this;
        }

        public RAA_EnterTrainingDetails EnterContactName()
        {
            formCompletionHelper.EnterText(ContactNameField, dataHelper.TrainingContactName);
            return this;
        }

        public RAA_EnterTrainingDetails ContactTelephone()
        {
            formCompletionHelper.EnterText(ContactumberField, dataHelper.TrainingContactNumber);
            return this;
        }

        public RAA_EnterTrainingDetails EnterEmailDetails()
        {
            formCompletionHelper.EnterText(EmailField, dataHelper.TrainingEmail);
            return this;
        }

        public RAA_EnterFurtherDetailsPage GotoFurtherDetailsPage()
        {
            formCompletionHelper.Click(SaveAndContinueButton);
            return new RAA_EnterFurtherDetailsPage(_context);
        }

        public RAA_EnterOpportunityDetails GotoOpportunityDetailsPage()
        {
            formCompletionHelper.Click(SaveAndContinueButton);
            return new RAA_EnterOpportunityDetails(_context);
        }
    }
}
