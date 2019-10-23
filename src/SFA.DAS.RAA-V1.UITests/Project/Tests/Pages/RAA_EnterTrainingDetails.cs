using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages
{
    public class RAA_EnterTrainingDetails : BasePage
    {
        protected override string PageTitle => "Enter Training Details";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly RAAV1DataHelper _dataHelper;
        private readonly IWebDriver _webDriver;
        #endregion

        private By TrainingTypeFramework => By.Id("training-type-frameworks");
        private By TrainingTypeStandards => By.Id("training-type-standards");
        private By StandardsDropDownMenu => By.Id("StandardId");
        private By FrameworkDropDown => By.Id("s2id_FrameworkCodeName");
        private By FrameWorkDropdownTextEntry => By.CssSelector(".select2-input");
        private By FWkApprenticeshipLevelIntermediateButton => By.CssSelector("#apprenticeship-level-intermediate");
        private By ContactNameField => By.Id("ContactName");
        private By ContactumberField => By.CssSelector("#ContactNumber");
        private By EmailField => By.CssSelector("#ContactEmail");
        private By SaveAndContinueButton => By.Id("createVacancyButton");
        private By Iframe => By.CssSelector("iframe");
        private By TraineeshipDropdown => By.Id("s2id_SectorCodeName");
        private By TraineeshipSelector => By.CssSelector("#s2id_autogen1_search");
        private By TrainingBody => By.XPath("//body");


        public RAA_EnterTrainingDetails(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<RAAV1DataHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _webDriver = context.GetWebDriver();
            VerifyPage();
        }

        public RAA_EnterTrainingDetails SelectApprenticeshipType(string frameworkOrStanndard)
        {
            switch (frameworkOrStanndard)
            {
                case "Framework":
                    _formCompletionHelper.EnterSpace(TrainingTypeFramework);
                    _formCompletionHelper.Click(FrameworkDropDown);
                    _formCompletionHelper.SendKeys(FrameWorkDropdownTextEntry,Keys.ArrowDown);
                    _formCompletionHelper.SendKeys(FrameWorkDropdownTextEntry,Keys.ArrowDown);
                    _formCompletionHelper.SendKeys(FrameWorkDropdownTextEntry,Keys.Enter);
                    _formCompletionHelper.EnterSpace(FWkApprenticeshipLevelIntermediateButton);
                    break;

                case "Standard":
                    _formCompletionHelper.EnterSpace(TrainingTypeStandards);
                    _formCompletionHelper.Click(StandardsDropDownMenu);
                    _formCompletionHelper.SelectFromDropDownByValue(StandardsDropDownMenu, "208");
                    break;

                case "Traineeship":
                    _formCompletionHelper.Click(TraineeshipDropdown);
                    _formCompletionHelper.SendKeys(TraineeshipSelector, Keys.ArrowDown);
                    _formCompletionHelper.SendKeys(TraineeshipSelector, Keys.ArrowDown);
                    _formCompletionHelper.SendKeys(TraineeshipSelector, Keys.Enter);
                    break;
            }
            return this;
        }

        public RAA_EnterTrainingDetails EnterTrainingToBeProvided()
        {
            _webDriver.SwitchTo().Frame(_webDriver.FindElement(Iframe));
            _formCompletionHelper.EnterText(TrainingBody, _dataHelper.TrainingDetails);
            _webDriver.SwitchTo().DefaultContent();
            return this;
        }

        public RAA_EnterTrainingDetails EnterContactName()
        {
            _formCompletionHelper.EnterText(ContactNameField, _dataHelper.TrainingContactName);
            return this;
        }

        public RAA_EnterTrainingDetails ContactTelephone()
        {
            _formCompletionHelper.EnterText(ContactumberField, _dataHelper.TrainingContactNumber);
            return this;
        }

        public RAA_EnterTrainingDetails EnterEmailDetails()
        {
            _formCompletionHelper.EnterText(EmailField, _dataHelper.TrainingEmail);
            return this;
        }

        public RAA_EnterTrainingDetails ClickOnSaveAndContinue()
        {
            _formCompletionHelper.Click(SaveAndContinueButton);
            return this;
        }
    }
}
