using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper
{
    public class NonLevyReservationStepsHelper
    {
        private ApproveApprenticeDetailsPage _approveApprenticeDetailsPage;
        private readonly ManageFundingEmployerStepsHelper _employerReservationStepsHelper;
        private readonly ScenarioContext _context;
        
        private readonly SetApprenticeDetailsHelper _setApprenticeDetailsHelper;

        public NonLevyReservationStepsHelper(ScenarioContext context)
        {
            _context = context;
            _employerReservationStepsHelper = new ManageFundingEmployerStepsHelper(_context);
            _setApprenticeDetailsHelper = new SetApprenticeDetailsHelper(context);
        }

        public ApproveApprenticeDetailsPage NonLevyEmployerAddsApprenticesUsingReservations(List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)> listOfApprentice, bool shouldConfirmOnlyStandardCoursesSelectable)
        {
            var addPersonalDetailsPage = NonLevyEmployerAddsProviderDetails();

            foreach (var apprentice in listOfApprentice)
            {
                _context.Replace(apprentice.Item1);
                _context.Replace(apprentice.Item2);

                bool IslastItem = listOfApprentice.IndexOf(apprentice) == listOfApprentice.Count - 1;

                _approveApprenticeDetailsPage = NonLevyEmployerAddsApprenticeDetails(addPersonalDetailsPage, shouldConfirmOnlyStandardCoursesSelectable);

                if (!IslastItem) addPersonalDetailsPage = AddAnotherApprentice(_approveApprenticeDetailsPage);
            }
            
            return SetApprenticeDetails(listOfApprentice.Count);
        }

        public ApproveApprenticeDetailsPage NonLevyEmployerAddsApprenticesUsingReservations(int numberOfApprentices, bool shouldConfirmOnlyStandardCoursesSelectable)
        {
            var listOfApprentice = _context.Get<List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)>>().Take(numberOfApprentices).ToList();

            return NonLevyEmployerAddsApprenticesUsingReservations(listOfApprentice.Take(numberOfApprentices).ToList(), shouldConfirmOnlyStandardCoursesSelectable);
        }

        private AddPersonalDetailsPage AddAnotherApprentice(ApproveApprenticeDetailsPage approveApprenticeDetailsPage)
        {
            var page = approveApprenticeDetailsPage.SelectAddAnApprenticeUsingReservation().ChooseCreateANewReservationRadioButton().ClickSaveAndContinueButton();

            return _employerReservationStepsHelper.CreateReservation(page).AddAnotherApprentice().EmployerSelectsAStandard();
        }

        private ApproveApprenticeDetailsPage NonLevyEmployerAddsApprenticeDetails(AddPersonalDetailsPage addPersonalDetailsPage, bool shouldConfirmOnlyStandardCoursesSelectable)
        {
            var trainingDetailsPage = addPersonalDetailsPage.SubmitValidPersonalDetails();

            if (shouldConfirmOnlyStandardCoursesSelectable) trainingDetailsPage = addPersonalDetailsPage.ClickEditCourseLink().ConfirmOnlyStandardCoursesAreSelectable();

            return trainingDetailsPage.SubmitValidTrainingDetails(true);
        }

        private AddPersonalDetailsPage NonLevyEmployerAddsProviderDetails()
        {
            return _employerReservationStepsHelper.CreateReservation(_employerReservationStepsHelper.GoToReserveFunding())
                .AddApprentice()
                .StartNowToAddTrainingProvider()
                .SubmitValidUkprn()
                .ConfirmProviderDetailsAreCorrect()
                .NonLevyEmployerAddsApprentices()
                .EmployerSelectsAStandard();
        }

        private ApproveApprenticeDetailsPage SetApprenticeDetails(int numberOfApprentices) => _setApprenticeDetailsHelper.SetApprenticeDetails(_approveApprenticeDetailsPage, numberOfApprentices);

    }
}