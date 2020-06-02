using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_BasicVacancyDetailsPage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Enter basic vacancy details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        #endregion

        private By ApprenticeShipOfflineVacancy => By.Id("apprenticeship-offline-vacancy");
        private By ApprenticeShipOnlineVacancy => By.Id("apprenticeship-online-vacancy");
        private By OfflineApplicationProcess => By.Id("apprenticheship-offline-application-instructions");
        private By OfflineVacancyUrl => By.Id("apprenticeship-offline-application-url");
        private By SaveAndContinueButton => By.Id("createVacancyButton");
        private By VacancyShortDescription => By.CssSelector("#ShortDescription");
        private By VacancyTitle => By.CssSelector("#Title");

        public RAA_BasicVacancyDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        public RAA_BasicVacancyDetailsPage EnterVacancyTitle()
        {
            formCompletionHelper.EnterText(VacancyTitle, vacancyTitledataHelper.VacancyTitle);
            return this;
        }

        public RAA_BasicVacancyDetailsPage EnterVacancyShortDescription()
        {
            formCompletionHelper.EnterText(VacancyShortDescription, rAAV1DataHelper.VacancyShortDescription);
            SetVacancyShortDescription(rAAV1DataHelper.VacancyShortDescription);
            return this;
        }

        public RAA_BasicVacancyDetailsPage ClickOnVacancyType(VacancyType vacancyType)
        {
            if (vacancyType == VacancyType.Traineeship)
            {
                formCompletionHelper.SelectRadioOptionByText("Traineeship");
            }
            else
            {
                formCompletionHelper.SelectRadioOptionByText("Apprenticeship");
            }
            return this;
        }

        public RAA_BasicVacancyDetailsPage CickDisabilityConfident(string answer)
        {
            if (answer == "Yes") formCompletionHelper.SelectCheckBoxByText("The employer is signed up to the Disability Confident scheme");
            return this;
        }

        public RAA_EnterTrainingDetailsPage ClickSaveAndContinueButton()
        {
            formCompletionHelper.Click(SaveAndContinueButton);
            return new RAA_EnterTrainingDetailsPage(_context);
        }

        public RAA_BasicVacancyDetailsPage ApplicationMethod(string onlineoffline)
        {
            if (onlineoffline == "Online")
            {
                formCompletionHelper.SelectRadioOptionByText("Candidates will apply on this website");
            }
            else if (onlineoffline == "Offline")
            {
                formCompletionHelper.SelectRadioOptionByText("Candidates will apply through an external website");
                formCompletionHelper.EnterText(OfflineVacancyUrl, rAAV1DataHelper.VacancyWebsiteUrl);
                formCompletionHelper.EnterText(OfflineApplicationProcess, rAAV1DataHelper.ApplicationProcess);
            }
            return this;
        }

        private void SetVacancyShortDescription(string value)
        {
            _objectContext.SetVacancyShortDescription(value);
        }
    }
}
