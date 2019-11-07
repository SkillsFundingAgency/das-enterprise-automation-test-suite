using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.FAA
{
    public class FAA_WithdrawSuccessful : BasePage
    {
        protected override string PageTitle => $"You've successfully withdrawn from {_dataHelper.VacancyTitle}";

        protected override By PageHeader => By.CssSelector("#SuccessMessageText");

        #region Helpers and Context
        private readonly RAADataHelper _dataHelper;
        #endregion

        public FAA_WithdrawSuccessful(ScenarioContext context) : base(context)
        {
            _dataHelper = context.Get<RAADataHelper>();
            VerifyPage();
        }
    }
}
