using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider
{
    public class ProviderEditStepsHelper
    {
        private readonly ScenarioContext _context;

        private readonly ReplaceApprenticeDatahelper _replaceApprenticeDatahelper;

        private readonly ProviderCommonStepsHelper _providerCommonStepsHelper;

        public ProviderEditStepsHelper(ScenarioContext context)
        {
            _context = context;

            _replaceApprenticeDatahelper = new ReplaceApprenticeDatahelper(context);

            _providerCommonStepsHelper = new ProviderCommonStepsHelper(context);
        }

        public ProviderEditApprenticeCoursePage ProviderEditApprentice() => _providerCommonStepsHelper.CurrentApprenticeDetails().EditApprentice();

        public ProviderApproveApprenticeDetailsPage CheckCoursesAreStandardsAndEditApprentice() => EditApprentice(CurrentCohortDetails(), true);

        public ProviderApproveApprenticeDetailsPage EditApprentice() => EditApprentice(CurrentCohortDetails());

        public ProviderApproveApprenticeDetailsPage EditApprentice(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage) => EditApprentice(providerApproveApprenticeDetailsPage, false);

        public ProviderApproveApprenticeDetailsPage EditApprentice(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage, bool shouldCheckCoursesAreStandards)
        {
            return EditApprenticeFunc(providerApproveApprenticeDetailsPage, false, (editPage) =>
            {
                if (shouldCheckCoursesAreStandards)
                    editPage = editPage.ClickEditCourseLink().ConfirmOnlyStandardCoursesAreSelectableAndContinue();

                return editPage;
            });
        }

        public ProviderApproveApprenticeDetailsPage EditFlexiPilotApprentice(bool isPilotLearner)
        {
            return EditApprenticeFunc(CurrentCohortDetails(), isPilotLearner, (editPage) =>
            {
                return editPage.ClickEditSimplifiedPaymentsPilotLink().MakePaymentsPilotSelectionAndContinueToEditApprenticeDetailsPage(isPilotLearner);
            });
        }


        public ProviderApproveApprenticeDetailsPage EditSpecificFlexiPaymentsPilotApprentice(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage, int learnerToEdit, bool isPilotLearner)
        {
            int apprentice = learnerToEdit - 1;

            _replaceApprenticeDatahelper.ReplaceApprenticeDataInContext(apprentice);

            var providerEditApprenticeDetailsPage = providerApproveApprenticeDetailsPage.SelectEditApprentice(apprentice);

            return providerEditApprenticeDetailsPage.ClickEditSimplifiedPaymentsPilotLink()
                .MakePaymentsPilotSelectionAndContinueToEditApprenticeDetailsPage(isPilotLearner)
                .EnterUlnAndSave();
        }

        public ProviderApproveApprenticeDetailsPage EditAllDetailsOfApprentice(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage)
        {
            var totalNoOfApprentices = GetNoOfApprentices();

            for (int i = 0; i < totalNoOfApprentices; i++)
            {
                _replaceApprenticeDatahelper.ReplaceApprenticeDataInContext(i);

                var providerEditApprenticeDetailsPage = providerApproveApprenticeDetailsPage.SelectEditApprentice(i);

                providerApproveApprenticeDetailsPage = providerEditApprenticeDetailsPage.EditAllApprenticeDetailsExceptCourse()
                    .ClickEditCourseLink()
                    .ProviderSelectsAStandardForEditApprenticeDetails()
                    .ClickSave();
            }
            return providerApproveApprenticeDetailsPage;
        }

        private ProviderApproveApprenticeDetailsPage EditApprenticeFunc(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage, bool isPilotLearner, Func<ProviderEditApprenticeDetailsPage, ProviderEditApprenticeDetailsPage> func)
        {
            var totalNoOfApprentices = GetNoOfApprentices();

            for (int i = 0; i < totalNoOfApprentices; i++)
            {
                foreach (var uln in providerApproveApprenticeDetailsPage.ApprenticeUlns().ToList())
                {
                    if (uln.Text.Equals("-"))
                    {
                        _replaceApprenticeDatahelper.ReplaceApprenticeDataInContext(i);

                        var editPage = providerApproveApprenticeDetailsPage.SelectEditApprentice(i, isPilotLearner);

                        editPage = func(editPage);

                        providerApproveApprenticeDetailsPage = editPage.EnterUlnAndSave();

                        break;
                    }
                }
            }

            return providerApproveApprenticeDetailsPage;
        }

        public ProviderApproveApprenticeDetailsPage CurrentCohortDetails() => _providerCommonStepsHelper.CurrentCohortDetails();

        private int GetNoOfApprentices() => _context.Get<ObjectContext>().GetNoOfApprentices();

    }
}