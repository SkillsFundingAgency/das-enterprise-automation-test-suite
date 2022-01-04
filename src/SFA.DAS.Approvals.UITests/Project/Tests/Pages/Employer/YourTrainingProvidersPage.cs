using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class YourTrainingProvidersPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Your training providers";

        private By AddANewTrainingProviderButton => By.LinkText("Add a training provider");
        private By SetPermissionsLink => By.LinkText("Set permissions");
        private By ChangePermissionsLink => By.LinkText("Change permissions");

        public YourTrainingProvidersPage(ScenarioContext context) : base(context)  { }

        public EnterYourTrainingProviderNameReferenceNumberUKPRNPage SelectAddANewTrainingProvider()
        {
            formCompletionHelper.ClickElement(AddANewTrainingProviderButton);
            return new EnterYourTrainingProviderNameReferenceNumberUKPRNPage(context);
        }

        public SetPermissionsForTrainingProviderPage SelectSetPermissions(string orgName)
        {
            if (string.IsNullOrEmpty(orgName))
                formCompletionHelper.ClickElement(SetPermissionsLink);
            else
                tableRowHelper.SelectRowFromTable("Set permissions", orgName);

            return new SetPermissionsForTrainingProviderPage(context);
        }

        public SetPermissionsForTrainingProviderPage SelectChangePermissions()
        {
            formCompletionHelper.ClickElement(ChangePermissionsLink);
            return new SetPermissionsForTrainingProviderPage(context);
        }
    }
}