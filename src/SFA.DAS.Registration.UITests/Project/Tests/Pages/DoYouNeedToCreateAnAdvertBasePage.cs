using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public abstract class DoYouNeedToCreateAnAdvertBasePage : BasePage
    {
        protected override string PageTitle => "Do you need to create an advert for this apprenticeship?";
        protected override By PageHeader => By.Id("heading-continue-setup-create-advert");

        #region Helpers and Context
        protected readonly FormCompletionHelper formCompletionHelper;
        #endregion

        protected override By ContinueButton => By.Id("accept");
        protected By NoRadioButtonOption => By.Id("choice2-no");
        protected By YesRadioButtonOption => By.Id("choice1-yes");

        public DoYouNeedToCreateAnAdvertBasePage(ScenarioContext context) : base(context)
        {
            formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }
    }
}
