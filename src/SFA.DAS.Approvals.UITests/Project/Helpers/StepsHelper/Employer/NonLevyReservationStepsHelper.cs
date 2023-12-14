using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer
{
    public class NonLevyReservationStepsHelper
    {
        private ApproveApprenticeDetailsPage _approveApprenticeDetailsPage;
        private readonly ManageFundingEmployerStepsHelper _employerReservationStepsHelper;
        private readonly ScenarioContext _context;

        private readonly SetApprenticeDetailsHelper _setApprenticeDetailsHelper;
        protected readonly ReplaceApprenticeDatahelper _replaceApprenticeDatahelper;

        public NonLevyReservationStepsHelper(ScenarioContext context)
        {
            _context = context;
            _employerReservationStepsHelper = new ManageFundingEmployerStepsHelper(_context);
            _setApprenticeDetailsHelper = new SetApprenticeDetailsHelper(context);
            _replaceApprenticeDatahelper = new ReplaceApprenticeDatahelper(context);
        }

        public ApproveApprenticeDetailsPage NonLevyEmployerAddsApprenticesUsingReservations(List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)> listOfApprentice, bool shouldConfirmOnlyStandardCoursesSelectable)
        {
            int noOfApprentice = listOfApprentice.Count;

            AddApprenticeDetailsPage addApprenticeDetailsPage;

            for (int i = 0; i < noOfApprentice; i++)
            {
                _replaceApprenticeDatahelper.ReplaceApprenticeDataInContext(i);

                if (i == 0)
                {
                    addApprenticeDetailsPage = NonLevyEmployerAddsProviderDetails().EmployerAddsApprentices().EmployerSelectsAStandard();
                }
                else
                {
                    addApprenticeDetailsPage = AddAnotherApprentice(_approveApprenticeDetailsPage);
                }

                _approveApprenticeDetailsPage = NonLevyEmployerAddsApprenticeDetails(addApprenticeDetailsPage, shouldConfirmOnlyStandardCoursesSelectable);
            }


            return SetApprenticeDetails(listOfApprentice.Count);
        }

        public ApproveApprenticeDetailsPage NonLevyEmployerAddsApprenticesUsingReservations(int numberOfApprentices, bool shouldConfirmOnlyStandardCoursesSelectable)
        {
            var listOfApprentice = _context.Get<List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)>>().Take(numberOfApprentices).ToList();

            return NonLevyEmployerAddsApprenticesUsingReservations(listOfApprentice.Take(numberOfApprentices).ToList(), shouldConfirmOnlyStandardCoursesSelectable);
        }

        private static AddApprenticeDetailsPage AddAnotherApprentice(ApproveApprenticeDetailsPage approveApprenticeDetailsPage)
        {
            var page = approveApprenticeDetailsPage.SelectAddAnApprenticeUsingReservation().ChooseCreateANewReservationRadioButton().ClickSaveAndContinueButton();

            return ManageFundingEmployerStepsHelper.CreateReservation(page).AddAnotherApprentice().EmployerSelectsAStandard();
        }

        private static ApproveApprenticeDetailsPage NonLevyEmployerAddsApprenticeDetails(AddApprenticeDetailsPage addApprenticeDetailsPage, bool shouldConfirmOnlyStandardCoursesSelectable)
        {
            if (shouldConfirmOnlyStandardCoursesSelectable) addApprenticeDetailsPage.ClickEditCourseLink().ConfirmOnlyStandardCoursesAreSelectable();

            return addApprenticeDetailsPage.SubmitValidApprenticeDetails(true);
        }

        private StartAddingApprenticesPage NonLevyEmployerAddsProviderDetails()
        {
            return ManageFundingEmployerStepsHelper.CreateReservation(_employerReservationStepsHelper.GoToReserveFunding())
                .AddApprentice()
                .StartNowToAddTrainingProvider()
                .SubmitValidUkprn()
                .ConfirmProviderDetailsAreCorrect();
        }

        private ApproveApprenticeDetailsPage SetApprenticeDetails(int numberOfApprentices) => _setApprenticeDetailsHelper.SetApprenticeDetails(_approveApprenticeDetailsPage, numberOfApprentices);

    }
}