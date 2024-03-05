using System;
using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class CreateYourEmployerAccountPage : RegistrationBasePage
    {
        protected override string PageTitle => "Create your employer account";

        #region Constants
        public static string UserDetailsItemText => "Add your user detail";
        public static string OrganisationAndPAYEItemText => "Add a PAYE scheme";
        public static string AccountNameItemText => "Set your account name";
        public static string EmployerAgreementItemText => "Your employer agreement";
        public static string TrainingProviderItemText => "Training provider";
        public static string TrainingProviderPermissionsItemText => "Training provider permissions";
        #endregion

        public CreateYourEmployerAccountPage(ScenarioContext context) : base(context) => VerifyPage();

        public ChangeYourUserDetailsPage GoToAddYouUserDetailsLink()
        {
            formCompletionHelper.ClickLinkByText("Add your user details");
            return new ChangeYourUserDetailsPage(context);
        }

        public HowMuchIsYourOrgAnnualPayBillPage GoToAddPayeLink()
        {
            formCompletionHelper.ClickLinkByText("Add a PAYE scheme");
            return new HowMuchIsYourOrgAnnualPayBillPage(context);
        }

        public SetYourEmployerAccountNamePage GoToSetYourAccountNameLink()
        {
            formCompletionHelper.ClickLinkByText("Set your account name");
            return new SetYourEmployerAccountNamePage(context);
        }

        public AboutYourAgreementPage GoToYourEmployerAgreementLink()
        {
            formCompletionHelper.ClickLinkByText("Your employer agreement");
            return new AboutYourAgreementPage(context);
        }

        public AddATrainingProviderPage GoToTrainingProviderLink()
        {
            formCompletionHelper.ClickLinkByText("Training provider");
            return new AddATrainingProviderPage(context);
        }

        public YourTrainingProvidersPage GoToTrainingProviderPermissionsLink()
        {
            formCompletionHelper.ClickLinkByText("Training provider permissions");
            return new YourTrainingProvidersPage(context);
        }      

        public CreateYourEmployerAccountPage VerifyStepCannotBeStartedYet(string listItemText)
        {
            By stepSelector = By.XPath($"//span[contains(text(), '{listItemText}')]");

            var element = pageInteractionHelper.FindElement(stepSelector);
            string tagName = element.TagName.ToLower();

            Assert.AreNotEqual("a", tagName, "The text has an anchor tag");

            return this;
        }

        public bool CheckIsPageCurrent()
        {
            return pageInteractionHelper.Verify(() =>
            {
                var result = IsPageCurrent;

                return !result.Item1 ? throw new Exception(
                    MessageHelper.GetExceptionMessage("IsPageCurrent", "Create your employer account", result.Item2))
                : true;

            }, null);
        }
    }
}
