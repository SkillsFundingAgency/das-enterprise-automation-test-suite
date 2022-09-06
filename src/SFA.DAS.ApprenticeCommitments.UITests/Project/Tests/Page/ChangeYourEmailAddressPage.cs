using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ChangeYourEmailAddressPage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => $"Change your email address";
        private By NewEmailAddress => By.CssSelector("#NewEmailAddress");
        private By ConfirmEmailAddress => By.CssSelector("#ConfirmEmailAddress");
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button[type='submit']");

        public ChangeYourEmailAddressPage(ScenarioContext context) : base(context, verifyserviceheader: false)  { }

        public YouHaveUpdatedYourEmailAddressPage UpdateEmailAddress()
        {
            formCompletionHelper.EnterText(Password, objectContext.GetApprenticePassword());
            Continue();
            return new YouHaveUpdatedYourEmailAddressPage(context);
        }

        public WeHaveSentYouAnEmailPage RequestToUpdateEmailAddress()
        {
            var newEmail = $"New_{objectContext.GetApprenticeEmail()}";
            objectContext.SetApprenticeChangedEmail(newEmail);
            formCompletionHelper.EnterText(NewEmailAddress, newEmail);
            formCompletionHelper.EnterText(ConfirmEmailAddress, newEmail);
            Continue();
            return new WeHaveSentYouAnEmailPage(context);
        }
    }
}
