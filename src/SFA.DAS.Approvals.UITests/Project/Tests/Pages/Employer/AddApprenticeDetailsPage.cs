using System;
using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class AddApprenticeDetailsPage : AddAndEditApprenticeDetailsBasePage
    {
        protected override string PageTitle => "Add apprentice details";

        private By SaveAndContinueButton => By.CssSelector("#main-content .govuk-button");

        private By DeliveryModelLabel => By.XPath("//p[text()='Delivery model']");

        private By DeliveryModelType => By.XPath("//p[text()='Delivery model'] // following-sibling :: p");

        private By EditDeliverModelLink => By.Name("ChangeDeliveryModel");

        public AddApprenticeDetailsPage(ScenarioContext context) : base(context) { }

        public ApproveApprenticeDetailsPage SubmitValidApprenticeDetails(bool isMF, int apprenticeNo = 0)
        {
            var courseStartDate = SetEIJourneyTestData(apprenticeNo);

            EnterApprenticeMandatoryValidDetails();

            EnterDob();

            ClickStartMonth();

            if (isMF == false) EnterStartDate(courseStartDate);

            EnterEndDate(apprenticeCourseDataHelper.CourseEndDate);

            EnterTrainingCostAndEmpReference();

            formCompletionHelper.ClickElement(SaveAndContinueButton);

            if (IsSelectStandardWithMultipleOptions()) new SelectAStandardOptionpage(context).SelectAStandardOption();

            return new ApproveApprenticeDetailsPage(context);
        }

        public YouCantApproveThisApprenticeRequestUntilPage DraftDynamicHomePageSubmitValidApprenticeDetails()
        {
            EnterApprenticeMandatoryValidDetails();

            formCompletionHelper.ClickElement(SaveAndContinueButton);

            return new YouCantApproveThisApprenticeRequestUntilPage(context);
        }

        private DateTime SetEIJourneyTestData(int apprenticeNo)
        {
            if (objectContext.IsEIJourney())
            {
                var eiApprenticeDetailList = objectContext.GetEIApprenticeDetailList();

                var eiApprenticeDetail = eiApprenticeDetailList[apprenticeNo];

                objectContext.SetEIAgeCategoryAsOfAug2021(eiApprenticeDetail.AgeCategoryAsOfAug2021);
                objectContext.SetEIStartMonth(eiApprenticeDetail.StartMonth);
                objectContext.SetEIStartYear(eiApprenticeDetail.StartYear);

                apprenticeDataHelper.DateOfBirthDay = 1;
                apprenticeDataHelper.DateOfBirthMonth = 8;
                apprenticeDataHelper.DateOfBirthYear = (objectContext.GetEIAgeCategoryAsOfAug2021().Equals("Aged16to24")) ? 2005 : 1994;
                apprenticeDataHelper.ApprenticeFirstname = RandomDataGenerator.GenerateRandomFirstName();
                apprenticeDataHelper.ApprenticeLastname = RandomDataGenerator.GenerateRandomLastName();
                apprenticeDataHelper.TrainingCost = "7500";

                return new DateTime(objectContext.GetEIStartYear(), objectContext.GetEIStartMonth(), 1);
            }

            if (objectContext.IsSameApprentice()) apprenticeCourseDataHelper.CourseStartDate = apprenticeCourseDataHelper.GenerateCourseStartDate(Helpers.DataHelpers.ApprenticeStatus.WaitingToStart);

            return apprenticeCourseDataHelper.CourseStartDate;
        }

        public void ValidateFlexiJobContent()
        {
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(DeliveryModelLabel));
            StringAssert.StartsWith("Flexi-job agency", pageInteractionHelper.GetText(DeliveryModelType), "Incorrect Delivery Model displayed");
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(EditDeliverModelLink));
        }
    }
}
