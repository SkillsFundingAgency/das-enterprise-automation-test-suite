using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_BasicVacancyDetails : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Enter basic vacancy details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ApprenticeShipOfflineVacancy => By.Id("apprenticeship-offline-vacancy");
        private By ApprenticeShipOnlineVacancy => By.Id("apprenticeship-online-vacancy");
        private By OfflineApplicationProcess => By.Id("apprenticheship-offline-application-instructions");
        private By OfflineVacancyUrl => By.Id("apprenticeship-offline-application-url");
        private By SaveAndContinueButton => By.Id("createVacancyButton");
        private By VacancyShortDescription => By.CssSelector("#ShortDescription");
        private By VacancyTitle => By.CssSelector("#Title");

        public RAA_BasicVacancyDetails(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public RAA_BasicVacancyDetails EnterVacancyTitle()
        {
            formCompletionHelper.EnterText(VacancyTitle, dataHelper.VacancyTitle);
            return this;
        }

        public RAA_BasicVacancyDetails EnterVacancyShortDescription()
        {
            formCompletionHelper.EnterText(VacancyShortDescription, dataHelper.VacancyShortDescription);
            return this;
        }

        public RAA_BasicVacancyDetails ClickOnVacancyType(VacancyType vacancyType)
        {
            if (vacancyType == VacancyType.Traineeship)
                formCompletionHelper.SelectRadioOptionByText("Traineeship");
            else
                formCompletionHelper.SelectRadioOptionByText("Apprenticeship");  
            return this;
        }

        public RAA_BasicVacancyDetails CickDisabilityConfident(string answer)
        {
            if (answer == "Yes") formCompletionHelper.SelectCheckBoxByText("The employer is signed up to the Disability Confident scheme");
            return this;
        }

        public RAA_EnterTrainingDetails ClickSaveAndContinueButton()
        {
            formCompletionHelper.Click(SaveAndContinueButton);
            return new RAA_EnterTrainingDetails(_context);
        }

        public RAA_BasicVacancyDetails ApplicationMethod(string onlineoffline)
        {
            if (onlineoffline == "Online")
            {
                formCompletionHelper.SelectRadioOptionByText("Candidates will apply on this website");
            }
            else if (onlineoffline == "Offline")
            {
                formCompletionHelper.SelectRadioOptionByText("Candidates will apply through an external website");
                formCompletionHelper.EnterText(OfflineVacancyUrl, dataHelper.VacancyWebsiteUrl);
                formCompletionHelper.EnterText(OfflineApplicationProcess, dataHelper.ApplicationProcess);
            }
            return this;
        }

    }
}
