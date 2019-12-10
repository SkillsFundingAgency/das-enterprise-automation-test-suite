using SFA.DAS.RAA_V2.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class ApplicationProcessPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "How would you like to receive applications?";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public ApplicationProcessPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public VacancyPreviewPart2Page ApplicationMethodFAA()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(RadioLabels, "application-method-faa");
            _formCompletionHelper.Click(Continue);
            return new VacancyPreviewPart2Page(_context);
        }

    }
}
