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
        public static string TrainingProviderItemText => "Add a training provider and set their permissions";
        #endregion

        public CreateYourEmployerAccountPage(ScenarioContext context) : base(context) => VerifyPage();

        public ChangeYourUserDetailsPage GoToAddYouUserDetailsLink()
        {
            formCompletionHelper.ClickLinkByText(UserDetailsItemText);
            return new ChangeYourUserDetailsPage(context);
        }

        public HowMuchIsYourOrgAnnualPayBillPage GoToAddPayeLink()
        {
            formCompletionHelper.ClickLinkByText(OrganisationAndPAYEItemText);
            return new HowMuchIsYourOrgAnnualPayBillPage(context);
        }

        public CannotAddPayeSchemePage GoToAddPayeLinkWhenAlreadyAdded()
        {
            formCompletionHelper.ClickLinkByText(OrganisationAndPAYEItemText);
            return new CannotAddPayeSchemePage(context);
        }

        public SetYourEmployerAccountNamePage GoToSetYourAccountNameLink()
        {
            formCompletionHelper.ClickLinkByText(AccountNameItemText);
            return new SetYourEmployerAccountNamePage(context);
        }

        public AboutYourAgreementPage GoToYourEmployerAgreementLink()
        {
            formCompletionHelper.ClickLinkByText(EmployerAgreementItemText);
            return new AboutYourAgreementPage(context);
        }

        public AddATrainingProviderPage GoToTrainingProviderLink()
        {
            formCompletionHelper.ClickLinkByText(TrainingProviderItemText);
            return new AddATrainingProviderPage(context);
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
                    MessageHelper.GetExceptionMessage("IsPageCurrent", PageTitle, result.Item2))
                : true;

            }, null);
        }
    }
}
