//using NUnit.Framework;
//using OpenQA.Selenium;
//using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
//using System;
//using TechTalk.SpecFlow;

//namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
//{
//    public class EditTrainingDetailsPage : AddAndEditApprenticeDetailsBasePage
//    {
//        protected override By PageHeader => By.CssSelector("#draftApprenticeshipSection2 > h1");
//        protected override string PageTitle => "Edit training details";
//        private static By EditDeliveryModelLink => By.CssSelector("#change-delivery-model-link");
//        private static By DeliveryModelLabel => By.XPath("//*[@id='draftApprenticeshipSection2']/div[2]/p[2]");

//        protected override By AddButtonSelector => By.XPath("//button[text()='Save']");

//        public EditTrainingDetailsPage(ScenarioContext context) : base(context)
//        {
//        }

//        public bool IsEditDeliveryModelLinkVisible() => pageInteractionHelper.IsElementDisplayed(EditDeliveryModelLink);
//        public bool ConfirmDeliveryModelLabelText(string deliveryModel)
//        {
//            if (pageInteractionHelper.VerifyText(DeliveryModelLabel, deliveryModel) == true)
//            {
//                return true;
//            }
//            else return false;
//        }

//        public SelectDeliveryModelPage ClickEditDeliveryModelLink()
//        {
//            formCompletionHelper.ClickElement(EditDeliveryModelLink);
//            return new SelectDeliveryModelPage(context);
//        }

//        public ConfirmApprenticeshipDeliveryModelPage ClickEditDeliveryModel()
//        {
//            formCompletionHelper.ClickElement(EditDeliveryModelLink);
//            return new ConfirmApprenticeshipDeliveryModelPage(context);
//        }

//        public ApproveApprenticeDetailsPage SaveEditedTrainingDetails()
//        {
//            formCompletionHelper.ClickElement(AddButtonSelector);
//            return new ApproveApprenticeDetailsPage(context);
//        }

//        public EditTrainingDetailsPage ValidateDeliveryModelDisplayed(string deliveryModel)
//        {
//            string expected = deliveryModel;
//            string actual = GetDeliveryModel();
//            Assert.IsTrue(actual.Contains(deliveryModel), $"Incorrect delivery model is displayed, expected {expected} but actual was {actual}");
//            return this;
//        }

//        public string GetDeliveryModel() => pageInteractionHelper.GetText(DeliveryModelLabel);

//        public EditTrainingDetailsPage ValidateDeliveryModelNotDisplayed()
//        {
//            string actual = GetDeliveryModel();
//            if (actual.Contains("Regular") || actual.Contains("Flexi-job agency") || actual.Contains("Portable flexi-job"))
//            {
//                throw new Exception("Edit Apprentice Training details page references delivery model");
//            }
//            else return this;
//        }

//    }
//}