using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_WithdrawSuccessfulPage : BasePage
    {
        protected override string PageTitle => $"You've successfully withdrawn from {_dataHelper.VacancyTitle}";

        protected override By PageHeader => By.CssSelector("#SuccessMessageText");

        #region Helpers and Context
        private readonly VacancyTitleDatahelper _dataHelper;
        #endregion

        public FAA_WithdrawSuccessfulPage(ScenarioContext context) : base(context)
        {
            _dataHelper = context.Get<VacancyTitleDatahelper>();
            VerifyPage();
        }
    }
}
