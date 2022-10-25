using System;
using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class AddPersonalDetailsPage : AddAndEditApprenticeDetailsBasePage
    {
        protected override string PageTitle => "Add personal details";

        private By SaveAndContinueButton => By.CssSelector("#main-content .govuk-button");

        public AddPersonalDetailsPage(ScenarioContext context) : base(context) { }

        public AddTrainingDetailsPage SubmitValidApprenticeDetails()
        {
            EnterApprenticeMandatoryValidDetails();

            EnterDob();

            formCompletionHelper.ClickElement(SaveAndContinueButton);

            return new AddTrainingDetailsPage(context);
        }

        public AddTrainingDetailsPage DraftDynamicHomePageAddValidApprenticeDetails()
        {
            EnterApprenticeMandatoryValidDetails();

            formCompletionHelper.ClickElement(SaveAndContinueButton);

            return new AddTrainingDetailsPage(context);
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

        public AddTrainingDetailsPage ContinueToAddTrainingDetailsPage()
        {
            formCompletionHelper.ClickElement(SaveAndContinueButton);
            return new AddTrainingDetailsPage(context);
        }
    }
}
