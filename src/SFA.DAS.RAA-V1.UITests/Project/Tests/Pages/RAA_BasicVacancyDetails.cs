using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages
{
    public enum VacancyType
    {
        Apprenticeship,
        Traineeship
    }

    public class RAA_BasicVacancyDetails : BasePage
    {
        protected override string PageTitle => "Enter basic vacancy details";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly RAAV1DataHelper _dataHelper;
        private readonly IWebDriver _webDriver;
        #endregion


        private By ApprenticeShipOfflineVacancy => By.Id("apprenticeship-offline-vacancy");
        private By ApprenticeShipOnlineVacancy => By.Id("apprenticeship-online-vacancy");
        private By CheckDisabilityConfident => By.Id("is-disability-confident");
        private By OfflineApplicationProcess => By.Id("apprenticheship-offline-application-instructions");
        private By OfflineVacancyUrl => By.Id("apprenticeship-offline-application-url");
        private By SaveAndContinueButton => By.Id("createVacancyButton");
        private By VacancyShortDescription => By.CssSelector("#ShortDescription");
        private By VacancyTitle => By.CssSelector("#Title");
        private By VacancyTypeApprenticeShip => By.Id("vacancy-type-apprenticeship");
        private By VacancyTypeTraineeship => By.Id("vacancy-type-traineeship");

        public RAA_BasicVacancyDetails(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<RAAV1DataHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _webDriver = context.GetWebDriver();
            VerifyPage();
        }

        public RAA_BasicVacancyDetails EnterVacancyTitle(string v1Text, string typeOfVacancy)
        {
            var title = v1Text + typeOfVacancy + System.DateTime.Now;
            _formCompletionHelper.EnterText(VacancyTitle, title);
            return this;
        }

        public RAA_BasicVacancyDetails EnterVacancyShortDescription()
        {
            _formCompletionHelper.Click(VacancyShortDescription);
            _formCompletionHelper.EnterText(VacancyShortDescription, _dataHelper.VacancyShortDescription);
            return this;
        }

        public RAA_BasicVacancyDetails ClickOnVacancyType(VacancyType vacancyType)
        {
            if (vacancyType == VacancyType.Traineeship)
                _formCompletionHelper.EnterSpace(VacancyTypeTraineeship);
            else
                _formCompletionHelper.EnterSpace(VacancyTypeApprenticeShip);
            return this;
        }

        public RAA_BasicVacancyDetails CickDisabilityConfident(string answer)
        {
            if (answer == "Yes") _formCompletionHelper.EnterSpace(CheckDisabilityConfident);
            return this;
        }

        public RAA_EnterTrainingDetails ClickSaveAndContinueButton()
        {
            _formCompletionHelper.Click(SaveAndContinueButton);
            return new RAA_EnterTrainingDetails(_context);
        }

        public RAA_BasicVacancyDetails ApplicationMethod(string onlineoffline)
        {
            if (onlineoffline == "Online")
            {
                _formCompletionHelper.EnterSpace(ApprenticeShipOnlineVacancy);
            }
            else if (onlineoffline == "Offline")
            {
                _formCompletionHelper.EnterSpace(ApprenticeShipOfflineVacancy);
                _formCompletionHelper.Click(OfflineVacancyUrl);
                _formCompletionHelper.EnterText(OfflineVacancyUrl, _dataHelper.VacancyWebsiteUrl);
                _formCompletionHelper.Click(OfflineApplicationProcess);
                _formCompletionHelper.EnterText(OfflineApplicationProcess, _dataHelper.ApplicationProcess);
            }

            return this;
        }

    }
}
