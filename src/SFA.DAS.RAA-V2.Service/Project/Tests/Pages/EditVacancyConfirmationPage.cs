using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class EditVacancyConfirmationPage : BasePage
    {
        protected override string PageTitle => $"The vacancy '{_vacancyTitle}' has been updated.";

        #region Helpers and Context
        private readonly string _vacancyTitle;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        private By Info => By.CssSelector(".info-summary");

        public EditVacancyConfirmationPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _vacancyTitle = context.Get<RAAV2DataHelper>().VacancyTitle;
            VerifyPage(() => _pageInteractionHelper.FindElements(Info));
        }
    }
}
