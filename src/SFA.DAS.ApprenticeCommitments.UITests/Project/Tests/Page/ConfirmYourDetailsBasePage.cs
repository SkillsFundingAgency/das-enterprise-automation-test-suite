using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using System.Collections.Generic;
using System;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public abstract class ConfirmYourDetailsBasePage : ApprenticeCommitmentsBasePage
    {
        private By DeliveryModel => By.XPath("//th[text()='Delivery model']/following-sibling::td");
        private By ApprenticeshipInfo => By.XPath("//th[text()='Apprenticeship']/following-sibling::td");
        private By LevelInfo => By.XPath("//th[text()='Level']/following-sibling::td");
        private By EstimatedDurationInfo => By.XPath("//th[text()='Estimated duration']/following-sibling::td");
        private By PlannedStartDateInfo => By.XPath("//th[text()='Planned start date for training']/following-sibling::td");
        private By PlannedStartDateInfoForPortable => By.XPath("//th[text()='Planned training start date']/following-sibling::td");
        private By PlannedEndDate => By.XPath("//th[text()='Planned training end date']/following-sibling::td");
        private By JobEndDate => By.XPath("//th[text()='Job end date']/following-sibling::td");
        protected By GreenTickText => By.CssSelector(".app-notification-banner");
        protected By EmployerHelpSectionLink => By.XPath("//span[@class='govuk-details__summary-text' and contains(text(),\"Help if you do not recognise your employer's name\")]");
        protected By EmployerHelpSectionText => By.XPath($"//div[contains(text(),\"{objectContext.GetEmployerName()} is your employer's legal name registered with Companies House.  You may know them by their trading name instead.\")]");
        protected By ProviderHelpSectionLink => By.XPath("//span[@class='govuk-details__summary-text' and contains(text(),\"Help if you do not recognise your training provider's name\")]");
        protected By ProviderHelpSectionText => By.XPath($"//div[contains(text(),\"{objectContext.GetProviderName()} is your training provider's legal name registered with Companies House.\")]");
        protected By ChangeMyAnswerLink => By.XPath("//a[text()='I want to change my answer']");

        public ConfirmYourDetailsBasePage(ScenarioContext context) : base(context, false) => VerifyPage(TopBlueBannerHeader, $"{objectContext.GetFirstName()} {objectContext.GetLastName()}");

        public ApprenticeOverviewPage SelectYesAndContinueToOverviewPage()
        {
            SelectYesRadioOption();
            return new ApprenticeOverviewPage(context);
        }

        public YouCantConfirmYourEmployerPage SelectNoToConfirmEmployer()
        {
            SelectNoRadioOption();
            return new YouCantConfirmYourEmployerPage(context);
        }

        public YouCantConfirmYourEmployerPage SelectNoToConfirmEmployerPostChangingAnswer()
        {
            SelectNoRadioOptionAndConfirm();
            return new YouCantConfirmYourEmployerPage(context);
        }

        public YouCantConfirmYourTrainingProviderPage SelectNoToConfirmTrainingProvider()
        {
            SelectNoRadioOption();
            return new YouCantConfirmYourTrainingProviderPage(context);
        }

        public YouCantConfirmYourTrainingProviderPage SelectNoToConfirmTrainingProviderPostChangingAnswer()
        {
            SelectNoRadioOptionAndConfirm();
            return new YouCantConfirmYourTrainingProviderPage(context);
        }

        public YouCantConfirmYourDetailsPage SelectNoToConfirmYourDetails()
        {
            SelectNoRadioOption();
            return new YouCantConfirmYourDetailsPage(context);
        }

        public YouCantConfirmYourDetailsPage SelectNoToConfirmYourDetailsPostChangingAnswer()
        {
            SelectNoRadioOptionAndConfirm();
            return new YouCantConfirmYourDetailsPage(context);
        }

        public void ChangeMyAnswerAction()
        {
            formCompletionHelper.Click(ChangeMyAnswerLink);
            VerifyPage(GreenTickText, "You can now change your answer");
        }

        public string GetDeliveryModelInfo() => pageInteractionHelper.GetText(DeliveryModel);

        public string GetApprenticeshipInfo() => pageInteractionHelper.GetText(ApprenticeshipInfo);

        public string GetApprenticeshipLevelInfo() => pageInteractionHelper.GetText(LevelInfo);

        public string GetApprenticeshipEstimatedDurationInfo() => pageInteractionHelper.GetText(EstimatedDurationInfo);

        public string GetApprenticeshipPlannedStartDateInfo() => pageInteractionHelper.GetText(PlannedStartDateInfo);

        public string GetPortableApprenticeshipPlannedStartDateInfo() => pageInteractionHelper.GetText(PlannedStartDateInfoForPortable);

        public string GetPortableApprenticeshipPlannedEndDateInfo() => pageInteractionHelper.GetText(PlannedEndDate);

        public string GetPortableApprenticeshipPlannedJobEndDateInfo() => pageInteractionHelper.GetText(JobEndDate);

        public void ClickOnConfirmButton() => formCompletionHelper.Click(ConfirmButton);

        public void VerifyErrorSummaryBoxAndErrorFieldText()
        {
            VerifyErrorSummaryTitle();

            MultipleVerifyPage(new List<Func<bool>>
            {
                () => VerifyPage(ErrorSummaryText,"Select an answer"),
                () => VerifyPage(FieldValidtionError,"Select an answer")
            });
        }

        private void SelectYesRadioOption() { formCompletionHelper.SelectRadioOptionByText("Yes"); Continue(); }

        private void SelectNoRadioOption() { formCompletionHelper.SelectRadioOptionByText("No"); Continue(); }

        private void SelectNoRadioOptionAndConfirm() { formCompletionHelper.SelectRadioOptionByText("No"); ClickOnConfirmButton(); }
    }
}
