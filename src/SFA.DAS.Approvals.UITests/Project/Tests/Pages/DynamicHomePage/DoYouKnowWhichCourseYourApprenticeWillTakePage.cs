using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage
{
    public class DoYouKnowWhichCourseYourApprenticeWillTakePage : BasePage
    {
        protected override string PageTitle => "Do you know which course your apprentice will take?";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion
        private By ClickYesContinue => By.Id("which-course-your-apprentice-will-take-button");
        public DoYouKnowWhichCourseYourApprenticeWillTakePage (ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

       public HaveYouChosenATrainingProviderToDeliverTheApprenticeshipTrainingPage YesToCourse()
        {
            _formCompletionHelper.SelectRadioOptionByText(RadioLabels, "Yes");
            _formCompletionHelper.Click(ClickYesContinue);
            return new HaveYouChosenATrainingProviderToDeliverTheApprenticeshipTrainingPage(_context);
       }
    }
}
