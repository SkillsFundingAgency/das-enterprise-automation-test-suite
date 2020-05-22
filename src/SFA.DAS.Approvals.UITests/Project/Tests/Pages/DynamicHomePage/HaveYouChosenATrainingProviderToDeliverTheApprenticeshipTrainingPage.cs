using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage
{
    public class HaveYouChosenATrainingProviderToDeliverTheApprenticeshipTrainingPage : BasePage
    {
        protected override string PageTitle => "Have you chosen a training provider to deliver the apprenticeship training?";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion
        private By ClickYesContinue => By.Id("have-you-chosen-a-training-provider-button");
        public HaveYouChosenATrainingProviderToDeliverTheApprenticeshipTrainingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }
        public WillTheApprenticeshipTrainingStartInTheNextSixMonthsPage YesToTrainingProviderToDeliver()
        {
            _formCompletionHelper.SelectRadioOptionByText(RadioLabels, "Yes");
            _formCompletionHelper.Click(ClickYesContinue);
            return new WillTheApprenticeshipTrainingStartInTheNextSixMonthsPage(_context);
        }
    }
}