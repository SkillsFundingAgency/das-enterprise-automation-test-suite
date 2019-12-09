using OpenQA.Selenium;
using SFA.DAS.RAA_V2.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class WageTypePage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "How much would you like to pay the apprentice?";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly EmployerDataHelper _dataHelper;
        #endregion

        private By WageAdditionalInformation => By.CssSelector("#WageAdditionalInformation");

        public WageTypePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _dataHelper = context.Get<EmployerDataHelper>();
            VerifyPage();
        }

        public PreviewYourVacancyPage SelectNationalMinimumWage()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(RadioLabels, "wage-type-national-minimum-wage");
            _formCompletionHelper.EnterText(WageAdditionalInformation, _dataHelper.OptionalMessage);
            _formCompletionHelper.Click(Continue);
            return new PreviewYourVacancyPage(_context);
        }
    }
}
