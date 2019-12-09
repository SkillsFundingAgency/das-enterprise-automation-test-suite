using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class ChooseApprenticeshipLocationPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Where will the apprentice work?";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public ChooseApprenticeshipLocationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public ImportantDatesPage ChooseDifferentLocation()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(RadioLabels, "other-location");
            _formCompletionHelper.Click(Continue);
            return new ImportantDatesPage(_context);
        }

        public ImportantDatesPage ChooseAddress()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(RadioLabels, "OtherLocation_1");
            _formCompletionHelper.Click(Continue);
            return new ImportantDatesPage(_context);
        }
    }
}
