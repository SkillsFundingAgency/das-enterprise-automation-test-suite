using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    internal class ApprenticeshipServiceEmployerSupportToolPage : SupportConsoleBasePage
    {
        protected override string PageTitle => "Apprenticeship service employer support tool";

        #region Locators
        protected override By PageHeader => By.CssSelector(".govuk-heading-l");
        private By StartNowButton => By.CssSelector(".govuk-button--start");
        #endregion


        public ApprenticeshipServiceEmployerSupportToolPage(ScenarioContext context) : base(context)
        {
                
        }

        public IdamsPage ClickStartNowButton()
        {
            formCompletionHelper.Click(StartNowButton);
            return new IdamsPage(context);
        }
    }
}
